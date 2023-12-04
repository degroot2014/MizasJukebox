namespace Miza_sJukebox
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.serverPanel = new System.Windows.Forms.Panel();
            this.serverList = new System.Windows.Forms.ComboBox();
            this.voiceChannelList = new System.Windows.Forms.ComboBox();
            this.voiceChannelLabel = new System.Windows.Forms.Label();
            this.serverNameLabel = new System.Windows.Forms.Label();
            this.connectionStatus = new System.Windows.Forms.Label();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.connectButton = new System.Windows.Forms.Button();
            this.playButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.voiceChannelErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.currentlyPlayingLabel = new System.Windows.Forms.Label();
            this.serverErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.musicPanel = new System.Windows.Forms.Panel();
            this.musicTreeView = new System.Windows.Forms.TreeView();
            this.currentlyPlaying = new System.Windows.Forms.Label();
            this.currentMusicFolder = new System.Windows.Forms.Label();
            this.currentMusicFolderLabel = new System.Windows.Forms.Label();
            this.folderSelectButton = new System.Windows.Forms.Button();
            this.folderSelectToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.musicFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.musicErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.discordCommandSettingsLabel = new System.Windows.Forms.Label();
            this.commandPanel = new System.Windows.Forms.Panel();
            this.mapCommand = new System.Windows.Forms.Label();
            this.mapCommandLabel = new System.Windows.Forms.LinkLabel();
            this.mapOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.serverPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.voiceChannelErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverErrorProvider)).BeginInit();
            this.musicPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.musicErrorProvider)).BeginInit();
            this.commandPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // serverPanel
            // 
            this.serverPanel.Controls.Add(this.serverList);
            this.serverPanel.Controls.Add(this.voiceChannelList);
            this.serverPanel.Controls.Add(this.voiceChannelLabel);
            this.serverPanel.Controls.Add(this.serverNameLabel);
            this.serverPanel.Controls.Add(this.connectionStatus);
            this.serverPanel.Controls.Add(this.disconnectButton);
            this.serverPanel.Controls.Add(this.connectButton);
            this.serverPanel.Location = new System.Drawing.Point(520, 12);
            this.serverPanel.Name = "serverPanel";
            this.serverPanel.Size = new System.Drawing.Size(268, 95);
            this.serverPanel.TabIndex = 0;
            // 
            // serverList
            // 
            this.serverList.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.serverList.DisplayMember = "\"Name\"";
            this.serverList.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.serverList.FormattingEnabled = true;
            this.serverList.Location = new System.Drawing.Point(94, 32);
            this.serverList.Name = "serverList";
            this.serverList.Size = new System.Drawing.Size(157, 23);
            this.serverList.TabIndex = 5;
            this.serverList.ValueMember = "\"Id\"";
            this.serverList.SelectedIndexChanged += new System.EventHandler(this.serverList_SelectedIndexChanged);
            // 
            // voiceChannelList
            // 
            this.voiceChannelList.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.voiceChannelList.DisplayMember = "\"Name\"";
            this.voiceChannelList.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.voiceChannelList.FormattingEnabled = true;
            this.voiceChannelList.Location = new System.Drawing.Point(94, 61);
            this.voiceChannelList.Name = "voiceChannelList";
            this.voiceChannelList.Size = new System.Drawing.Size(157, 23);
            this.voiceChannelList.TabIndex = 4;
            this.voiceChannelList.ValueMember = "\"Id\"";
            // 
            // voiceChannelLabel
            // 
            this.voiceChannelLabel.AutoSize = true;
            this.voiceChannelLabel.Location = new System.Drawing.Point(3, 64);
            this.voiceChannelLabel.Name = "voiceChannelLabel";
            this.voiceChannelLabel.Size = new System.Drawing.Size(85, 15);
            this.voiceChannelLabel.TabIndex = 3;
            this.voiceChannelLabel.Text = "Voice Channel:";
            // 
            // serverNameLabel
            // 
            this.serverNameLabel.AutoSize = true;
            this.serverNameLabel.Location = new System.Drawing.Point(3, 35);
            this.serverNameLabel.Name = "serverNameLabel";
            this.serverNameLabel.Size = new System.Drawing.Size(77, 15);
            this.serverNameLabel.TabIndex = 2;
            this.serverNameLabel.Text = "Server Name:";
            // 
            // connectionStatus
            // 
            this.connectionStatus.AutoSize = true;
            this.connectionStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.connectionStatus.ForeColor = System.Drawing.Color.Red;
            this.connectionStatus.Location = new System.Drawing.Point(3, 3);
            this.connectionStatus.Name = "connectionStatus";
            this.connectionStatus.Size = new System.Drawing.Size(114, 21);
            this.connectionStatus.TabIndex = 0;
            this.connectionStatus.Text = "Disconnected";
            // 
            // disconnectButton
            // 
            this.disconnectButton.ForeColor = System.Drawing.SystemColors.Desktop;
            this.disconnectButton.Location = new System.Drawing.Point(123, 3);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(75, 23);
            this.disconnectButton.TabIndex = 1;
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Visible = false;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // connectButton
            // 
            this.connectButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.connectButton.Location = new System.Drawing.Point(123, 3);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 1;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // playButton
            // 
            this.playButton.Enabled = false;
            this.playButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.playButton.Location = new System.Drawing.Point(3, 2);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(80, 50);
            this.playButton.TabIndex = 2;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.stopButton.Location = new System.Drawing.Point(183, 2);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(80, 50);
            this.stopButton.TabIndex = 3;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Enabled = false;
            this.pauseButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pauseButton.Location = new System.Drawing.Point(93, 2);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(80, 50);
            this.pauseButton.TabIndex = 4;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // voiceChannelErrorProvider
            // 
            this.voiceChannelErrorProvider.BlinkRate = 200;
            this.voiceChannelErrorProvider.ContainerControl = this;
            // 
            // currentlyPlayingLabel
            // 
            this.currentlyPlayingLabel.AutoSize = true;
            this.currentlyPlayingLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.voiceChannelErrorProvider.SetIconAlignment(this.currentlyPlayingLabel, System.Windows.Forms.ErrorIconAlignment.BottomLeft);
            this.currentlyPlayingLabel.Location = new System.Drawing.Point(3, 70);
            this.currentlyPlayingLabel.Name = "currentlyPlayingLabel";
            this.currentlyPlayingLabel.Size = new System.Drawing.Size(133, 21);
            this.currentlyPlayingLabel.TabIndex = 9;
            this.currentlyPlayingLabel.Text = "Currently Playing:";
            // 
            // serverErrorProvider
            // 
            this.serverErrorProvider.BlinkRate = 200;
            this.serverErrorProvider.ContainerControl = this;
            // 
            // musicPanel
            // 
            this.musicPanel.Controls.Add(this.musicTreeView);
            this.musicPanel.Controls.Add(this.currentlyPlaying);
            this.musicPanel.Controls.Add(this.currentlyPlayingLabel);
            this.musicPanel.Controls.Add(this.currentMusicFolder);
            this.musicPanel.Controls.Add(this.currentMusicFolderLabel);
            this.musicPanel.Controls.Add(this.folderSelectButton);
            this.musicPanel.Controls.Add(this.stopButton);
            this.musicPanel.Controls.Add(this.playButton);
            this.musicPanel.Controls.Add(this.pauseButton);
            this.musicPanel.Location = new System.Drawing.Point(12, 12);
            this.musicPanel.Name = "musicPanel";
            this.musicPanel.Size = new System.Drawing.Size(502, 524);
            this.musicPanel.TabIndex = 6;
            // 
            // musicTreeView
            // 
            this.musicTreeView.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.musicTreeView.Location = new System.Drawing.Point(3, 94);
            this.musicTreeView.Name = "musicTreeView";
            this.musicTreeView.Size = new System.Drawing.Size(461, 430);
            this.musicTreeView.TabIndex = 9;
            this.musicTreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.musicTreeView_DoubleClick);
            // 
            // currentlyPlaying
            // 
            this.currentlyPlaying.AutoSize = true;
            this.currentlyPlaying.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.currentlyPlaying.Location = new System.Drawing.Point(133, 70);
            this.currentlyPlaying.Name = "currentlyPlaying";
            this.currentlyPlaying.Size = new System.Drawing.Size(0, 21);
            this.currentlyPlaying.TabIndex = 11;
            // 
            // currentMusicFolder
            // 
            this.currentMusicFolder.AutoSize = true;
            this.currentMusicFolder.Location = new System.Drawing.Point(80, 55);
            this.currentMusicFolder.Name = "currentMusicFolder";
            this.currentMusicFolder.Size = new System.Drawing.Size(21, 15);
            this.currentMusicFolder.TabIndex = 8;
            this.currentMusicFolder.Text = "c:\\";
            // 
            // currentMusicFolderLabel
            // 
            this.currentMusicFolderLabel.AutoSize = true;
            this.currentMusicFolderLabel.Location = new System.Drawing.Point(3, 55);
            this.currentMusicFolderLabel.Name = "currentMusicFolderLabel";
            this.currentMusicFolderLabel.Size = new System.Drawing.Size(78, 15);
            this.currentMusicFolderLabel.TabIndex = 7;
            this.currentMusicFolderLabel.Text = "Music Folder:";
            // 
            // folderSelectButton
            // 
            this.folderSelectButton.Image = ((System.Drawing.Image)(resources.GetObject("folderSelectButton.Image")));
            this.folderSelectButton.Location = new System.Drawing.Point(470, 94);
            this.folderSelectButton.Name = "folderSelectButton";
            this.folderSelectButton.Size = new System.Drawing.Size(25, 25);
            this.folderSelectButton.TabIndex = 6;
            this.folderSelectToolTip.SetToolTip(this.folderSelectButton, "Select a folder with music to play.\r\n");
            this.folderSelectButton.UseVisualStyleBackColor = true;
            this.folderSelectButton.Click += new System.EventHandler(this.folderSelectButton_Click);
            // 
            // musicErrorProvider
            // 
            this.musicErrorProvider.ContainerControl = this;
            // 
            // discordCommandSettingsLabel
            // 
            this.discordCommandSettingsLabel.AutoSize = true;
            this.discordCommandSettingsLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.discordCommandSettingsLabel.Location = new System.Drawing.Point(3, 2);
            this.discordCommandSettingsLabel.Name = "discordCommandSettingsLabel";
            this.discordCommandSettingsLabel.Size = new System.Drawing.Size(240, 25);
            this.discordCommandSettingsLabel.TabIndex = 7;
            this.discordCommandSettingsLabel.Text = "Discord Command Settings";
            // 
            // commandPanel
            // 
            this.commandPanel.Controls.Add(this.mapCommand);
            this.commandPanel.Controls.Add(this.mapCommandLabel);
            this.commandPanel.Controls.Add(this.discordCommandSettingsLabel);
            this.commandPanel.Location = new System.Drawing.Point(520, 113);
            this.commandPanel.Name = "commandPanel";
            this.commandPanel.Size = new System.Drawing.Size(268, 170);
            this.commandPanel.TabIndex = 8;
            // 
            // mapCommand
            // 
            this.mapCommand.AutoSize = true;
            this.mapCommand.Location = new System.Drawing.Point(50, 27);
            this.mapCommand.Name = "mapCommand";
            this.mapCommand.Size = new System.Drawing.Size(21, 15);
            this.mapCommand.TabIndex = 9;
            this.mapCommand.Text = "c:\\";
            // 
            // mapCommandLabel
            // 
            this.mapCommandLabel.AutoSize = true;
            this.mapCommandLabel.LinkColor = System.Drawing.Color.White;
            this.mapCommandLabel.Location = new System.Drawing.Point(10, 27);
            this.mapCommandLabel.Name = "mapCommandLabel";
            this.mapCommandLabel.Size = new System.Drawing.Size(34, 15);
            this.mapCommandLabel.TabIndex = 8;
            this.mapCommandLabel.TabStop = true;
            this.mapCommandLabel.Text = "!map";
            this.mapCommandLabel.VisitedLinkColor = System.Drawing.Color.White;
            this.mapCommandLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.mapCommandLabel_LinkClicked);
            // 
            // mapOpenFileDialog
            // 
            this.mapOpenFileDialog.FileName = "mapOpenFileDialog";
            this.mapOpenFileDialog.Title = "Picture of Map";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(794, 548);
            this.Controls.Add(this.commandPanel);
            this.Controls.Add(this.musicPanel);
            this.Controls.Add(this.serverPanel);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Name = "Main";
            this.Text = "Miza\'s Jukebox";
            this.serverPanel.ResumeLayout(false);
            this.serverPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.voiceChannelErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverErrorProvider)).EndInit();
            this.musicPanel.ResumeLayout(false);
            this.musicPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.musicErrorProvider)).EndInit();
            this.commandPanel.ResumeLayout(false);
            this.commandPanel.PerformLayout();
            this.ResumeLayout(false);

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