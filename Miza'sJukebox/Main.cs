using JukeboxDiscordClient;
using Miza_sJukebox.Helpers;

namespace Miza_sJukebox
{
    public partial class Main : Form
    {
        private DiscordClient _discordClient;
        private Settings _settings = new();
        private bool _isPaused = false;

        public Main()
        {
            InitializeComponent();
            StartDiscord();
            InitializeSettings();
            GetMusicTracks();
        }

        private async void StartDiscord()
        {
            _discordClient = new DiscordClient();
            await _discordClient.StartAsync();
            var servers = _discordClient.GetServers();
            foreach (var server in servers)
            {
                serverList.Items.Add(server);
            }
        }

        private void InitializeSettings()
        {
            if(!_settings.LoadSettings())
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
            string[] music = Array.Empty<string>();
            try
            {
                music = Directory.GetFiles(path, "*.mp3", SearchOption.TopDirectoryOnly);
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
            var selectedServer = (Discord.WebSocket.SocketGuild)serverList.SelectedItem;
            if (selectedServer != null)
            {
                serverErrorProvider.SetError(serverList, string.Empty);

                var selectedVoiceChannel = (Discord.WebSocket.SocketVoiceChannel)voiceChannelList.SelectedItem;
                if (selectedVoiceChannel != null)
                {
                    voiceChannelErrorProvider.SetError(voiceChannelList, string.Empty);

                    _discordClient.ConnectToChannel(selectedServer.Id, selectedVoiceChannel.Id);
    
                    connectButton.Hide();
                    disconnectButton.Show();

                    connectionStatus.Text = "Connected";
                    connectionStatus.ForeColor = Color.DarkGreen;

                    playButton.Enabled = true;
                    pauseButton.Enabled = true;
                    stopButton.Enabled = true;
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
            
            connectionStatus.Text = "Disconnected";
            connectionStatus.ForeColor = Color.Red;

            playButton.Enabled = false;
            pauseButton.Enabled = false;
            stopButton.Enabled = false;
        }

        private void serverList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = (Discord.WebSocket.SocketGuild)serverList.SelectedItem;
            var channels = _discordClient.GetChannelsForServer(item.Id);

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
            if(song != null)
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
                }
            }
            else
            {
                musicErrorProvider.SetError(musicTreeView, "Must select a Song to Play.");
            }
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            if(_discordClient.PauseSong())
            {
                pauseButton.Text = _isPaused ? "Pause" : "Resume";
                _isPaused = !_isPaused;
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if(_isPaused)
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
    }
}