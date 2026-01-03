using JukeboxDiscordClient;
using MizasJukebox.Domain;
using NetCord;
using NetCord.Gateway;
using Button = System.Windows.Forms.Button;
using Color = System.Drawing.Color;

namespace MizasJukebox
{
    public partial class Main : Form
    {
        private DiscordClient _discordClient;
        private Settings _settings = new();
        private bool _isPaused = false;
        private bool _isLooping = false;

        public Main()
        {
            InitializeComponent();
            FormClosing += Main_FormClosing;
            StartDiscord();
            InitializeSettings();
            GetMusicTracks();
        }

        private async void Main_FormClosing(object? sender, FormClosingEventArgs e)
        {
            _settings.SaveSettings();
            _discordClient?.SaveSettings();
            _discordClient?.DisconnectFromChannel();
        }

        private async void StartDiscord()
        {
            _discordClient = new DiscordClient();
            await _discordClient.StartAsync();
            SetConnectionStatus("Disconnected", Color.Red);
            connectButton.Show();
            var servers = _discordClient.GetServers();
            foreach (var server in servers)
            {
                serverList.Items.Add(server);
            }
        }

        private void InitializeSettings()
        {
            if (!_settings.LoadSettings())
            {
                var result = musicFolderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    _settings.MusicFolderPath = currentMusicFolder.Text = musicFolderBrowserDialog.SelectedPath;
                    _settings.SaveSettings();
                }
            }
            currentMusicFolder.Text = _settings.MusicFolderPath;
            mapCommand.Text = _settings.MapCommand;
        }

        private void GetMusicTracks()
        {
            musicTreeView.Nodes.Clear();
            musicTreeView.Nodes.Add(TraverseDirectory(_settings.MusicFolderPath));
        }

        private TreeNode TraverseDirectory(string path)
        {
            TreeNode result = new TreeNode(path);
            foreach (var subdirectory in Directory.GetDirectories(path))
            {

                result.Nodes.Add(TraverseDirectory(subdirectory));
            }

            return AddSongs(result, path);
        }

        private TreeNode AddSongs(TreeNode currentNode, string path)
        {
            var music = new List<string>();
            string[] musicExtensions = new[] { "*.mp3", "*.mp4", "*.wma", "*.wav", "*.m4a" };
            try
            {
                foreach (var extension in musicExtensions)
                {
                    music.AddRange(Directory.GetFiles(path, extension, SearchOption.TopDirectoryOnly));
                }
            }
            catch (UnauthorizedAccessException e)
            {
                MessageBox.Show($"Cannot Access Folder. {e.Message}");
            }

            foreach (var song in music)
            {
                var splitPath = song.Split('\\');
                var songName = splitPath[^1];
                songName = songName.Remove(songName.Length - 4, 4);
                currentNode.Nodes.Add(song, songName);
            }

            return currentNode;
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            var selectedServer = (Guild)serverList.SelectedItem;
            if (selectedServer != null)
            {
                serverErrorProvider.SetError(serverList, string.Empty);

                var selectedVoiceChannel = (VoiceGuildChannel)voiceChannelList.SelectedItem;
                if (selectedVoiceChannel != null)
                {
                    voiceChannelErrorProvider.SetError(voiceChannelList, string.Empty);

                    _discordClient.ConnectToChannel(selectedServer, selectedVoiceChannel);

                    connectButton.Hide();
                    disconnectButton.Show();

                    SetConnectionStatus("Connected", Color.DarkGreen);

                    EnableButton(playButton);
                    EnableButton(pauseButton);
                    EnableButton(stopButton);
                    EnableButton(loopButton);
                }
                else
                {
                    voiceChannelErrorProvider.SetError(voiceChannelList, "Must Select a Channel.");
                }
            }
            else
            {
                serverErrorProvider.SetError(serverList, "Must Select a Server.");
            }

        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            _discordClient.DisconnectFromChannel();

            disconnectButton.Hide();
            connectButton.Show();

            SetConnectionStatus("Disconnected", Color.Red);

            DisableButton(playButton);
            DisableButton(pauseButton);
            DisableButton(stopButton);
            DisableButton(loopButton);
        }

        private void serverList_SelectedIndexChanged(object sender, EventArgs e)
        {
            voiceChannelList.Text = String.Empty;

            //todo handle null
            var guild = (Guild)serverList.SelectedItem;
            var channels = guild.Channels.Values.OfType<VoiceGuildChannel>().ToList(); ;

            voiceChannelList.Items.Clear();
            foreach (var channel in channels)
            {
                voiceChannelList.Items.Add(channel);
            }
        }

        private void folderSelectButton_Click(object sender, EventArgs e)
        {
            var result = musicFolderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                _settings.MusicFolderPath = currentMusicFolder.Text = musicFolderBrowserDialog.SelectedPath;
                _settings.SaveSettings();
                GetMusicTracks();
            }
        }

        private async void playButton_Click(object sender, EventArgs e)
        {
            var song = musicTreeView.SelectedNode;
            if (song != null)
            {
                if (song.Nodes.Count == 0)
                {
                    if (_discordClient.IsPlaying())
                    {
                        if (_isPaused)
                        {
                            pauseButton.Text = _isPaused ? "Pause" : "Resume";
                            _isPaused = !_isPaused;
                        }
                        _discordClient.StopSong();

                        while (_discordClient.IsPlaying())
                        {
                            Thread.Sleep(1000);
                        }
                    }
                    musicErrorProvider.SetError(musicTreeView, string.Empty);
                    currentlyPlaying.Text = song.Text;
                    await Task.Run(() => _discordClient.PlaySong(song.Name));
                    currentlyPlaying.Text = string.Empty;
                }
            }
            else
            {
                musicErrorProvider.SetError(musicTreeView, "Must select a Song to Play.");
            }
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            if (_discordClient.PauseSong())
            {
                pauseButton.Text = _isPaused ? "Pause" : "Resume";
                _isPaused = !_isPaused;
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if (_isPaused)
            {
                pauseButton.Text = _isPaused ? "Pause" : "Resume";
                _isPaused = !_isPaused;
            }
            _discordClient.StopSong();
        }

        private void mapCommandLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var result = mapOpenFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                _settings.MapCommand = mapCommand.Text = mapOpenFileDialog.FileName;
                _settings.SaveSettings();
            }
        }

        private void musicTreeView_DoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (playButton.Enabled)
            {
                playButton_Click(sender, e);
            }
        }

        private void SetConnectionStatus(string status, Color color)
        {
            connectionStatus.Text = status;
            connectionStatus.ForeColor = color;
        }

        private void loopButton_Click(object sender, EventArgs e)
        {
            _isLooping = !_isLooping;
            _discordClient.SetLooping(_isLooping);
            if (_isLooping)
            {
                loopButton.Text = "Stop Looping";
            }
            else
            {
                loopButton.Text = "Loop";
            }
        }

        private void DisableButton(Button button)
        {
            button.Enabled = false;
            button.BackColor = Color.Gray;
        }

        private void EnableButton(Button button)
        {
            button.Enabled = true;
            button.BackColor = SystemColors.ControlLightLight;
        }
    }
}