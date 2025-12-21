using JukeboxDiscordClient.Api;
using JukeboxDiscordClient.Api.interfaces;
using JukeboxDiscordClient.Domain;
using JukeboxDiscordClient.Domain.interfaces;
using JukeboxDiscordClient.Modules;
using Microsoft.Extensions.DependencyInjection;
using NetCord;
using NetCord.Gateway;
using NetCord.Gateway.Voice;
using NetCord.Logging;
using NetCord.Rest;
using NetCord.Services;
using NetCord.Services.ApplicationCommands;

using System.Diagnostics;

namespace JukeboxDiscordClient
{
    public class DiscordClient
    {
        private const string TOKEN = "token.txt";
        private const int BLOCK_SIZE = 1920;
        private const char PREFIX = '!';

        private GatewayClient _client;
        private Guild _guild;
        private VoiceGuildChannel _voiceChannel;
        private VoiceClient _audioClient;
        private Process _ffmpeg;
        private OpusEncodeStream _stream;
        private DiscordSettings _settings;

        private Stopwatch _stopwatch { get; } = new Stopwatch();
        private string _songPath = String.Empty;

        private static bool _paused = false;
        private static bool _playing = false;
        private static bool _looping = false;
        private static bool _endLoop = false;

        public static Task Main(string[] args) => new DiscordClient().StartAsync();

        public async Task StartAsync()
        {
            var token = File.ReadAllText(TOKEN);
            _client = new(new BotToken(token), 
                new GatewayClientConfiguration
                {
                    Logger = new ConsoleLogger(),
                    Intents = GatewayIntents.AllNonPrivileged | GatewayIntents.MessageContent,
                });

            //Register Commands
            var provider = SetupServiceProvider();
            await InstallCommandsAsync(provider);
            await _client.StartAsync();
            

            while (_client.Status == WebSocketStatus.Connecting) ;
            while (_client.Cache.Guilds.Count == 0 || _client.Cache.Guilds.First().Value == null || _client.Cache.Guilds.First().Value.Name == null) ;
        }

        public IReadOnlyCollection<Guild> GetServers()
        {
            //Todo : Better handling when no servers are available
            return _client.Cache.Guilds.Values.ToList();
        }
        
        #region Voice
        public async void ConnectToChannel(Guild selectedGuild, VoiceGuildChannel selectedChannel)
        {
            _guild = selectedGuild;
            _voiceChannel = selectedChannel;
            _audioClient = await _client.JoinVoiceChannelAsync(_guild.Id, _voiceChannel.Id);
            await _audioClient.StartAsync();
        }

        public async void DisconnectFromChannel()
        {
            await _client.UpdateVoiceStateAsync(new VoiceStateProperties(_guild.Id, null));
            _audioClient.Dispose();
        }

        
        public bool IsPlaying() 
        { 
            return _playing; 
        }

        public bool PauseSong()
        {
            if (_stopwatch.ElapsedMilliseconds <= 0)
            {
                return false;
            }

            if (!_paused)
            {
                _stopwatch.Stop();
                _ffmpeg.Kill();
            }
            else
            {
                PlaySong(_songPath, _stopwatch.ElapsedMilliseconds);
            }
            _paused = !_paused;
            return true;
        }

        public void SetLooping(bool loop)
        {
            _looping = loop;
        }

        public async void StopSong()
        {
            if (_playing)
            {
                _ffmpeg.Kill();
                _endLoop = true;
                _paused = false;
                _playing = false;
                _stopwatch.Reset();
            }
        }

        public async Task PlaySong(string path, long progressTime = 0)
        {
            if(_songPath != path)
            {
                StopSong();
                Task.WaitAll(Task.Delay(500));
                _songPath = path;
            }

            _playing = true;
            await _audioClient.EnterSpeakingStateAsync(new SpeakingProperties(SpeakingFlags.Microphone));

            do
            {
                var outStream = _audioClient.CreateOutputStream();
                _stream = new OpusEncodeStream(outStream, PcmFormat.Short, VoiceChannels.Stereo, OpusApplication.Audio);
                _ffmpeg = CreateStream(path, progressTime);

                _stopwatch.Start();
                await _ffmpeg.StandardOutput.BaseStream.CopyToAsync(_stream);

                //song is stopped, anything left over if stopped should flush buffer
                await outStream?.FlushAsync();
                if(_endLoop)
                {
                    _endLoop = false;
                    break;
                }               
            } while(_looping && !_paused);
            await _audioClient.EnterSpeakingStateAsync(null);

            if (!_paused)
            {// Song finished normally or stopped
                _stopwatch.Reset();
                _playing = false;
            }
        }

        private Process CreateStream(string path, long resumeTimeMs)
        {
            var resumeTime = resumeTimeMs / 1000;
            var newProcess = new ProcessStartInfo
            {
                FileName = "ffmpeg",
                Arguments = $"-hide_banner -loglevel panic -ss {resumeTime} -i \"{path}\" -ac 2 -f s16le -ar 48000 pipe:1",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
            };
            return Process.Start(newProcess);
        }
        #endregion

        
        #region Setup
        private ServiceProvider SetupServiceProvider()
        {
            var services = new ServiceCollection();
            services.AddSingleton<Idnd5eapi, dnd5eapi>();
            services.AddSingleton<IRandomService, RandomService>();
            services.AddTransient<DndReferenceModule>();
            services.AddTransient<DiceModule>();

            var serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }

        private async Task InstallCommandsAsync(ServiceProvider serviceProvider)
        {
            ApplicationCommandService<ApplicationCommandContext> applicationCommandService = new();
            applicationCommandService.AddModules(typeof(DiceModule).Assembly);

            // Add the handler to handle interactions
            _client.InteractionCreate += async interaction =>
            {
                // Check if the interaction is an application command interaction
                if (interaction is not ApplicationCommandInteraction applicationCommandInteraction)
                    return;

                // Execute the command
                var result = await applicationCommandService.ExecuteAsync(new ApplicationCommandContext(applicationCommandInteraction, _client), serviceProvider);

                // Check if the execution failed
                if (result is not IFailResult failResult)
                    return;

                // Return the error message to the user if the execution failed
                try
                {
                    await interaction.SendResponseAsync(InteractionCallback.Message(failResult.Message));
                }
                catch
                {
                }
            };

            await applicationCommandService.RegisterCommandsAsync(_client.Rest, _client.Id);
        }

        /*private async Task HandleCommandAsync(SocketMessage messageParam)
        {
            // Don't process the command if it was a system message
            var message = messageParam as SocketUserMessage;
            if (message == null) return;

            // Create a number to track where the prefix ends and the command begins
            int argPos = 0;

            // Determine if the message is a command based on the prefix and make sure no bots trigger commands
            if (!(message.HasCharPrefix(PREFIX, ref argPos) ||
                message.HasMentionPrefix(_client.CurrentUser, ref argPos)) ||
                message.Author.IsBot)
                return;

            // Create a WebSocket-based command context based on the message
            var context = new SocketCommandContext(_client, message);

            // Execute the command with the command context we just
            // created, along with the service provider for precondition checks.
            await _commands.ExecuteAsync(context, argPos, null);
        }*/

        #endregion
        
    }
}

/*
    Code to remove Commands
        var test = await _client.GetGlobalApplicationCommandsAsync();
        var command = test.First(t => t.Name == "rigged-roll");
        await command.DeleteAsync();
*/