namespace MizasJukebox
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            serverPanel = new Panel();
            serverList = new ComboBox();
            voiceChannelList = new ComboBox();
            voiceChannelLabel = new Label();
            serverNameLabel = new Label();
            connectionStatus = new Label();
            disconnectButton = new Button();
            connectButton = new Button();
            playButton = new Button();
            stopButton = new Button();
            pauseButton = new Button();
            voiceChannelErrorProvider = new ErrorProvider(components);
            currentlyPlayingLabel = new Label();
            serverErrorProvider = new ErrorProvider(components);
            musicPanel = new Panel();
            musicTreeView = new TreeView();
            currentlyPlaying = new Label();
            currentMusicFolder = new Label();
            currentMusicFolderLabel = new Label();
            folderSelectButton = new Button();
            folderSelectToolTip = new ToolTip(components);
            musicFolderBrowserDialog = new FolderBrowserDialog();
            musicErrorProvider = new ErrorProvider(components);
            discordCommandSettingsLabel = new Label();
            commandPanel = new Panel();
            mapCommand = new Label();
            mapCommandLabel = new LinkLabel();
            mapOpenFileDialog = new OpenFileDialog();
            serverPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)voiceChannelErrorProvider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)serverErrorProvider).BeginInit();
            musicPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)musicErrorProvider).BeginInit();
            commandPanel.SuspendLayout();
            SuspendLayout();
            // 
            // serverPanel
            // 
            serverPanel.Controls.Add(serverList);
            serverPanel.Controls.Add(voiceChannelList);
            serverPanel.Controls.Add(voiceChannelLabel);
            serverPanel.Controls.Add(serverNameLabel);
            serverPanel.Controls.Add(connectionStatus);
            serverPanel.Controls.Add(connectButton);
            serverPanel.Controls.Add(disconnectButton);
            serverPanel.Location = new Point(520, 12);
            serverPanel.Name = "serverPanel";
            serverPanel.Size = new Size(268, 95);
            serverPanel.TabIndex = 0;
            // 
            // serverList
            // 
            serverList.BackColor = SystemColors.ControlDarkDark;
            serverList.DisplayMember = "\"Name\"";
            serverList.ForeColor = SystemColors.ControlLightLight;
            serverList.FormattingEnabled = true;
            serverList.Location = new Point(94, 32);
            serverList.Name = "serverList";
            serverList.Size = new Size(157, 23);
            serverList.TabIndex = 5;
            serverList.ValueMember = "\"Id\"";
            serverList.SelectedIndexChanged += serverList_SelectedIndexChanged;
            // 
            // voiceChannelList
            // 
            voiceChannelList.BackColor = SystemColors.ControlDarkDark;
            voiceChannelList.DisplayMember = "\"Name\"";
            voiceChannelList.ForeColor = SystemColors.ControlLightLight;
            voiceChannelList.FormattingEnabled = true;
            voiceChannelList.Location = new Point(94, 61);
            voiceChannelList.Name = "voiceChannelList";
            voiceChannelList.Size = new Size(157, 23);
            voiceChannelList.TabIndex = 4;
            voiceChannelList.ValueMember = "\"Id\"";
            // 
            // voiceChannelLabel
            // 
            voiceChannelLabel.AutoSize = true;
            voiceChannelLabel.Location = new Point(3, 64);
            voiceChannelLabel.Name = "voiceChannelLabel";
            voiceChannelLabel.Size = new Size(85, 15);
            voiceChannelLabel.TabIndex = 3;
            voiceChannelLabel.Text = "Voice Channel:";
            // 
            // serverNameLabel
            // 
            serverNameLabel.AutoSize = true;
            serverNameLabel.Location = new Point(3, 35);
            serverNameLabel.Name = "serverNameLabel";
            serverNameLabel.Size = new Size(77, 15);
            serverNameLabel.TabIndex = 2;
            serverNameLabel.Text = "Server Name:";
            // 
            // connectionStatus
            // 
            connectionStatus.AutoSize = true;
            connectionStatus.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            connectionStatus.ForeColor = Color.DeepSkyBlue;
            connectionStatus.Location = new Point(3, 6);
            connectionStatus.Name = "connectionStatus";
            connectionStatus.Size = new Size(192, 21);
            connectionStatus.TabIndex = 0;
            connectionStatus.Text = "Connecting to Discord...";
            // 
            // disconnectButton
            // 
            disconnectButton.ForeColor = SystemColors.Desktop;
            disconnectButton.Location = new Point(120, 4);
            disconnectButton.Name = "disconnectButton";
            disconnectButton.Size = new Size(75, 23);
            disconnectButton.TabIndex = 1;
            disconnectButton.Text = "Disconnect";
            disconnectButton.UseVisualStyleBackColor = true;
            disconnectButton.Visible = false;
            disconnectButton.Click += disconnectButton_Click;
            // 
            // connectButton
            // 
            connectButton.ForeColor = SystemColors.ControlText;
            connectButton.Location = new Point(120, 5);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(75, 23);
            connectButton.TabIndex = 1;
            connectButton.Text = "Connect";
            connectButton.UseVisualStyleBackColor = true;
            connectButton.Visible = false;
            connectButton.Click += connectButton_Click;
            // 
            // playButton
            // 
            playButton.Enabled = false;
            playButton.ForeColor = SystemColors.ControlText;
            playButton.Location = new Point(3, 2);
            playButton.Name = "playButton";
            playButton.Size = new Size(80, 50);
            playButton.TabIndex = 2;
            playButton.Text = "Play";
            playButton.UseVisualStyleBackColor = true;
            playButton.Click += playButton_Click;
            // 
            // stopButton
            // 
            stopButton.Enabled = false;
            stopButton.ForeColor = SystemColors.ControlText;
            stopButton.Location = new Point(183, 2);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(80, 50);
            stopButton.TabIndex = 3;
            stopButton.Text = "Stop";
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += stopButton_Click;
            // 
            // pauseButton
            // 
            pauseButton.Enabled = false;
            pauseButton.ForeColor = SystemColors.ControlText;
            pauseButton.Location = new Point(93, 2);
            pauseButton.Name = "pauseButton";
            pauseButton.Size = new Size(80, 50);
            pauseButton.TabIndex = 4;
            pauseButton.Text = "Pause";
            pauseButton.UseVisualStyleBackColor = true;
            pauseButton.Click += pauseButton_Click;
            // 
            // voiceChannelErrorProvider
            // 
            voiceChannelErrorProvider.BlinkRate = 200;
            voiceChannelErrorProvider.ContainerControl = this;
            // 
            // currentlyPlayingLabel
            // 
            currentlyPlayingLabel.AutoSize = true;
            currentlyPlayingLabel.Font = new Font("Segoe UI", 12F);
            voiceChannelErrorProvider.SetIconAlignment(currentlyPlayingLabel, ErrorIconAlignment.BottomLeft);
            currentlyPlayingLabel.Location = new Point(3, 70);
            currentlyPlayingLabel.Name = "currentlyPlayingLabel";
            currentlyPlayingLabel.Size = new Size(133, 21);
            currentlyPlayingLabel.TabIndex = 9;
            currentlyPlayingLabel.Text = "Currently Playing:";
            // 
            // serverErrorProvider
            // 
            serverErrorProvider.BlinkRate = 200;
            serverErrorProvider.ContainerControl = this;
            // 
            // musicPanel
            // 
            musicPanel.Controls.Add(musicTreeView);
            musicPanel.Controls.Add(currentlyPlaying);
            musicPanel.Controls.Add(currentlyPlayingLabel);
            musicPanel.Controls.Add(currentMusicFolder);
            musicPanel.Controls.Add(currentMusicFolderLabel);
            musicPanel.Controls.Add(folderSelectButton);
            musicPanel.Controls.Add(stopButton);
            musicPanel.Controls.Add(playButton);
            musicPanel.Controls.Add(pauseButton);
            musicPanel.Location = new Point(12, 12);
            musicPanel.Name = "musicPanel";
            musicPanel.Size = new Size(502, 524);
            musicPanel.TabIndex = 6;
            // 
            // musicTreeView
            // 
            musicTreeView.Font = new Font("Segoe UI", 12F);
            musicTreeView.Location = new Point(3, 94);
            musicTreeView.Name = "musicTreeView";
            musicTreeView.Size = new Size(461, 430);
            musicTreeView.TabIndex = 9;
            musicTreeView.NodeMouseDoubleClick += musicTreeView_DoubleClick;
            // 
            // currentlyPlaying
            // 
            currentlyPlaying.AutoSize = true;
            currentlyPlaying.Font = new Font("Segoe UI", 12F);
            currentlyPlaying.Location = new Point(133, 70);
            currentlyPlaying.Name = "currentlyPlaying";
            currentlyPlaying.Size = new Size(0, 21);
            currentlyPlaying.TabIndex = 11;
            // 
            // currentMusicFolder
            // 
            currentMusicFolder.AutoSize = true;
            currentMusicFolder.Location = new Point(80, 55);
            currentMusicFolder.Name = "currentMusicFolder";
            currentMusicFolder.Size = new Size(21, 15);
            currentMusicFolder.TabIndex = 8;
            currentMusicFolder.Text = "c:\\";
            // 
            // currentMusicFolderLabel
            // 
            currentMusicFolderLabel.AutoSize = true;
            currentMusicFolderLabel.Location = new Point(3, 55);
            currentMusicFolderLabel.Name = "currentMusicFolderLabel";
            currentMusicFolderLabel.Size = new Size(78, 15);
            currentMusicFolderLabel.TabIndex = 7;
            currentMusicFolderLabel.Text = "Music Folder:";
            // 
            // folderSelectButton
            // 
            folderSelectButton.Image = (Image)resources.GetObject("folderSelectButton.Image");
            folderSelectButton.Location = new Point(470, 94);
            folderSelectButton.Name = "folderSelectButton";
            folderSelectButton.Size = new Size(25, 25);
            folderSelectButton.TabIndex = 6;
            folderSelectToolTip.SetToolTip(folderSelectButton, "Select a folder with music to play.\r\n");
            folderSelectButton.UseVisualStyleBackColor = true;
            folderSelectButton.Click += folderSelectButton_Click;
            // 
            // musicErrorProvider
            // 
            musicErrorProvider.ContainerControl = this;
            // 
            // discordCommandSettingsLabel
            // 
            discordCommandSettingsLabel.AutoSize = true;
            discordCommandSettingsLabel.Font = new Font("Segoe UI", 14.25F);
            discordCommandSettingsLabel.Location = new Point(3, 2);
            discordCommandSettingsLabel.Name = "discordCommandSettingsLabel";
            discordCommandSettingsLabel.Size = new Size(240, 25);
            discordCommandSettingsLabel.TabIndex = 7;
            discordCommandSettingsLabel.Text = "Discord Command Settings";
            // 
            // commandPanel
            // 
            commandPanel.Controls.Add(mapCommand);
            commandPanel.Controls.Add(mapCommandLabel);
            commandPanel.Controls.Add(discordCommandSettingsLabel);
            commandPanel.Location = new Point(520, 113);
            commandPanel.Name = "commandPanel";
            commandPanel.Size = new Size(268, 170);
            commandPanel.TabIndex = 8;
            // 
            // mapCommand
            // 
            mapCommand.AutoSize = true;
            mapCommand.Location = new Point(50, 27);
            mapCommand.Name = "mapCommand";
            mapCommand.Size = new Size(21, 15);
            mapCommand.TabIndex = 9;
            mapCommand.Text = "c:\\";
            // 
            // mapCommandLabel
            // 
            mapCommandLabel.AutoSize = true;
            mapCommandLabel.LinkColor = Color.White;
            mapCommandLabel.Location = new Point(10, 27);
            mapCommandLabel.Name = "mapCommandLabel";
            mapCommandLabel.Size = new Size(34, 15);
            mapCommandLabel.TabIndex = 8;
            mapCommandLabel.TabStop = true;
            mapCommandLabel.Text = "!map";
            mapCommandLabel.VisitedLinkColor = Color.White;
            mapCommandLabel.LinkClicked += mapCommandLabel_LinkClicked;
            // 
            // mapOpenFileDialog
            // 
            mapOpenFileDialog.FileName = "mapOpenFileDialog";
            mapOpenFileDialog.Title = "Picture of Map";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(794, 548);
            Controls.Add(commandPanel);
            Controls.Add(musicPanel);
            Controls.Add(serverPanel);
            ForeColor = SystemColors.ControlLightLight;
            Name = "Main";
            Text = "Miza's Jukebox";
            serverPanel.ResumeLayout(false);
            serverPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)voiceChannelErrorProvider).EndInit();
            ((System.ComponentModel.ISupportInitialize)serverErrorProvider).EndInit();
            musicPanel.ResumeLayout(false);
            musicPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)musicErrorProvider).EndInit();
            commandPanel.ResumeLayout(false);
            commandPanel.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private Panel serverPanel;
        private Label connectionStatus;
        private ComboBox voiceChannelList;
        private Label voiceChannelLabel;
        private Label serverNameLabel;
        private Button connectButton;
        private Button disconnectButton;
        private Button playButton;
        private Button stopButton;
        private Button pauseButton;
        private ErrorProvider voiceChannelErrorProvider;
        private ComboBox serverList;
        private ErrorProvider serverErrorProvider;
        private Panel musicPanel;
        private Label currentMusicFolder;
        private Label currentMusicFolderLabel;
        private Button folderSelectButton;
        private ToolTip folderSelectToolTip;
        private FolderBrowserDialog musicFolderBrowserDialog;
        private ErrorProvider musicErrorProvider;
        private Label currentlyPlayingLabel;
        private Label currentlyPlaying;
        private Panel commandPanel;
        private Label mapCommand;
        private LinkLabel mapCommandLabel;
        private Label discordCommandSettingsLabel;
        private OpenFileDialog mapOpenFileDialog;
        private TreeView musicTreeView;
    }
}