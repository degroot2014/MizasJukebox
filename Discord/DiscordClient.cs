using System.Diagnostics;
using NetCord;
using NetCord.Gateway;
using NetCord.Logging;
//using JukeboxDiscordClient.SlashCommands;
//using JukeboxDiscordClient.Modules;
using JukeboxDiscordClient.Domain;

namespace JukeboxDiscordClient
{
    public class DiscordClient
    {
        private const string TOKEN = "token.txt";
        private const int BLOCK_SIZE = 1920;
        private const char PREFIX = '!';

        private GatewayClient _client;
        //private SocketGuild _guild;
        //private SocketVoiceChannel _voiceChannel;
        //private IAudioClient _audioClient;
        private Process _ffmpeg;
        private Stream _output;
        //private CommandService _commands;
        //private SlashCommandMaster _slashCommands;
        private DiscordSettings _settings;

        private static bool _paused = false;
        private static bool _playing = false;
        private static bool _looping = false;
        private static bool _endLoop = false;

        public static Task Main(string[] args) => new DiscordClient().StartAsync();

        public async Task StartAsync()
        {
            var token = File.ReadAllText(TOKEN);
            _client = new(new BotToken(token), new GatewayClientConfiguration
            {
                Logger = new ConsoleLogger(),
                Intents = GatewayIntents.All,
            });

            //Register Commands

            await _client.StartAsync();
            

            while (_client.Status == WebSocketStatus.Connecting) ;
            while (_client.Cache.Guilds.Count == 0 || _client.Cache.Guilds.First().Value == null || _client.Cache.Guilds.First().Value.Name == null) ;

            //_slashCommands = new SlashCommandMaster(_client);
            //await InstallCommandsAsync();
            //await Task.Delay(-1);
        }

        public IReadOnlyCollection<Guild> GetServers()
        {
            //Todo : Better handling when no servers are available
            return _client.Cache.Guilds.Values.ToList();
        }

        /*public IReadOnlyCollection<SocketVoiceChannel> GetChannelsForServer(ulong serverId)
        {
            var guild = _client.GetGuild(serverId);
            return guild.VoiceChannels;
        }*/

        /*
        #region Voice
        public async void ConnectToChannel(ulong serverId, ulong channelId)
        {
            _guild = _client.GetGuild(serverId);
            _voiceChannel = _guild.GetVoiceChannel(channelId);
            _audioClient = await _voiceChannel.ConnectAsync();
        }

        public async void DisconnectFromChannel()
        {
            await _voiceChannel.DisconnectAsync();
        }

        public bool IsPlaying() 
        { 
            return _playing; 
        }

        public bool PauseSong()
        {
            if (_playing)
            {
                _paused = !_paused;
                return true;
            }
            return false;
        }

        public void SetLooping(bool loop)
        {
            _looping = loop;
        }

        private void TogglePlaying()
        {
            _playing = !_playing;
        }

        public void StopSong()
        {
            if (_playing)
            {
                _ffmpeg.Kill();
                _endLoop = true;
            }
        }

        public async Task PlaySong(string path)
        {
            if (_playing)
            {
                return;
            }
            else
            {
                TogglePlaying();
            }

            do
            {
                _ffmpeg = CreateStream(path);
                _output = _ffmpeg.StandardOutput.BaseStream;
                await using var discord = _audioClient.CreatePCMStream(AudioApplication.Music);
            
                while (true)
                {
                    //Music finished or broken
                    if (_ffmpeg.HasExited || discord == null)
                    {
                        CloseFileStreams();
                        break;
                    }

                    if (_paused)
                        continue;

                    var buffer = new byte[BLOCK_SIZE];
                    var byteCount = await _output.ReadAsync(buffer, 0, BLOCK_SIZE);

                    //File cannot be read or ending
                    if (byteCount <= 0)
                        break;

                    //send music bytes to discord
                    try
                    {
                        await discord.WriteAsync(buffer, 0, byteCount);
                    }
                    catch (Exception e)
                    {
                        await discord?.FlushAsync();
                        throw;
                    }
                }

                //song is done, anything left over if stopped should flush buffer
                await discord?.FlushAsync();
                if(_endLoop)
                {
                    _endLoop = false;
                    break;
                }
            } while(_looping);
            _playing = false;
            _paused = false;
        }

        private Task Log(LogMessage message)
        {
            Console.WriteLine(message.ToString());
            return Task.CompletedTask;
        }

        private Process CreateStream(string path)
        {
            return Process.Start(new ProcessStartInfo
            {
                FileName = "ffmpeg",
                Arguments = $"-hide_banner -loglevel panic -i \"{path}\" -ac 2 -f s16le -ar 48000 pipe:1",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true,
            });
        }

        private void CloseFileStreams()
        {
            if (_ffmpeg != null)
                _ffmpeg.Close();
            if (_output != null)
                _output.Close();
        }
        #endregion
        */
        /*
        #region Commands
        private async Task InstallCommandsAsync()
        {
            var commandConfig = new CommandServiceConfig()
            {
                CaseSensitiveCommands = false
            };
            _commands = new CommandService(commandConfig);

            _client.MessageReceived += HandleCommandAsync;
            _client.SlashCommandExecuted += _slashCommands.SlashCommandAsync;

            //Modules
            await _commands.AddModuleAsync<LinkModule>(null);

            //Slash Commands
            await _slashCommands.CreateSlashCommands();
        }

        private async Task HandleCommandAsync(SocketMessage messageParam)
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
        }

        #endregion
        */
    }
}

/*
    Code to remove Commands
        var test = await _client.GetGlobalApplicationCommandsAsync();
        var command = test.First(t => t.Name == "rigged-roll");
        await command.DeleteAsync();
*/