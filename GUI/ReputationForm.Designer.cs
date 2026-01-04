namespace MizasJukebox
{
    partial class ReputationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReputationForm));
            reputationView = new DataGridView();
            Location = new DataGridViewTextBoxColumn();
            Reputation = new DataGridViewTextBoxColumn();
            newButton = new Button();
            removeButton = new Button();
            addReputationButton = new Button();
            locationNameTextBox = new TextBox();
            reputationUpDown = new NumericUpDown();
            locationTextBoxLabel = new Label();
            reputationLabel = new Label();
            decreaseRepButton = new Button();
            welcomeButton = new Button();
            showListButton = new Button();
            saveButton = new Button();
            ((System.ComponentModel.ISupportInitialize)reputationView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)reputationUpDown).BeginInit();
            SuspendLayout();
            // 
            // reputationView
            // 
            reputationView.AllowUserToAddRows = false;
            reputationView.AllowUserToDeleteRows = false;
            reputationView.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.ControlDark;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.ControlLight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            reputationView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            reputationView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            reputationView.Columns.AddRange(new DataGridViewColumn[] { Location, Reputation });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.ControlDark;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.ControlLight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            reputationView.DefaultCellStyle = dataGridViewCellStyle2;
            reputationView.EnableHeadersVisualStyles = false;
            reputationView.GridColor = SystemColors.ControlDark;
            reputationView.Location = new Point(21, 12);
            reputationView.MultiSelect = false;
            reputationView.Name = "reputationView";
            reputationView.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.ControlDark;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            reputationView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            reputationView.RowHeadersWidth = 20;
            reputationView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            reputationView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            reputationView.Size = new Size(322, 389);
            reputationView.TabIndex = 0;
            reputationView.SelectionChanged += reputationView_SelectionChanged;
            // 
            // Location
            // 
            Location.DataPropertyName = "Key";
            Location.HeaderText = "Location";
            Location.Name = "Location";
            Location.ReadOnly = true;
            Location.Width = 200;
            // 
            // Reputation
            // 
            Reputation.DataPropertyName = "Value";
            Reputation.HeaderText = "Reputation";
            Reputation.Name = "Reputation";
            Reputation.ReadOnly = true;
            // 
            // newButton
            // 
            newButton.BackColor = SystemColors.ButtonShadow;
            newButton.ForeColor = SystemColors.ControlText;
            newButton.Location = new Point(363, 88);
            newButton.Name = "newButton";
            newButton.Size = new Size(88, 38);
            newButton.TabIndex = 4;
            newButton.Text = "New";
            newButton.UseVisualStyleBackColor = false;
            newButton.Click += newButton_Click;
            // 
            // removeButton
            // 
            removeButton.BackColor = SystemColors.ButtonShadow;
            removeButton.ForeColor = SystemColors.ControlText;
            removeButton.Location = new Point(459, 88);
            removeButton.Name = "removeButton";
            removeButton.Size = new Size(88, 38);
            removeButton.TabIndex = 5;
            removeButton.Text = "Remove";
            removeButton.UseVisualStyleBackColor = false;
            removeButton.Click += removeButton_Click;
            // 
            // addReputationButton
            // 
            addReputationButton.BackColor = SystemColors.ButtonShadow;
            addReputationButton.ForeColor = SystemColors.ControlText;
            addReputationButton.Location = new Point(363, 132);
            addReputationButton.Name = "addReputationButton";
            addReputationButton.Size = new Size(88, 38);
            addReputationButton.TabIndex = 6;
            addReputationButton.Text = "Increase Reputation";
            addReputationButton.UseVisualStyleBackColor = false;
            addReputationButton.Click += addReputationButton_Click;
            // 
            // locationNameTextBox
            // 
            locationNameTextBox.Location = new Point(363, 30);
            locationNameTextBox.Name = "locationNameTextBox";
            locationNameTextBox.Size = new Size(184, 23);
            locationNameTextBox.TabIndex = 7;
            // 
            // reputationUpDown
            // 
            reputationUpDown.Location = new Point(434, 59);
            reputationUpDown.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            reputationUpDown.Name = "reputationUpDown";
            reputationUpDown.Size = new Size(113, 23);
            reputationUpDown.TabIndex = 8;
            // 
            // locationTextBoxLabel
            // 
            locationTextBoxLabel.AutoSize = true;
            locationTextBoxLabel.Location = new Point(363, 12);
            locationTextBoxLabel.Name = "locationTextBoxLabel";
            locationTextBoxLabel.Size = new Size(88, 15);
            locationTextBoxLabel.TabIndex = 9;
            locationTextBoxLabel.Text = "Location Name";
            // 
            // reputationLabel
            // 
            reputationLabel.AutoSize = true;
            reputationLabel.Location = new Point(363, 61);
            reputationLabel.Name = "reputationLabel";
            reputationLabel.Size = new Size(65, 15);
            reputationLabel.TabIndex = 10;
            reputationLabel.Text = "Reputation";
            // 
            // decreaseRepButton
            // 
            decreaseRepButton.BackColor = SystemColors.ButtonShadow;
            decreaseRepButton.ForeColor = SystemColors.ControlText;
            decreaseRepButton.Location = new Point(459, 132);
            decreaseRepButton.Name = "decreaseRepButton";
            decreaseRepButton.Size = new Size(88, 38);
            decreaseRepButton.TabIndex = 11;
            decreaseRepButton.Text = "Decrease Reputation";
            decreaseRepButton.UseVisualStyleBackColor = false;
            decreaseRepButton.Click += decreaseRepButton_Click;
            // 
            // welcomeButton
            // 
            welcomeButton.BackColor = SystemColors.ButtonShadow;
            welcomeButton.ForeColor = SystemColors.ControlText;
            welcomeButton.Location = new Point(363, 176);
            welcomeButton.Name = "welcomeButton";
            welcomeButton.Size = new Size(88, 38);
            welcomeButton.TabIndex = 12;
            welcomeButton.Text = "Welcome To...";
            welcomeButton.UseVisualStyleBackColor = false;
            welcomeButton.Click += welcomeButton_Click;
            // 
            // showListButton
            // 
            showListButton.BackColor = SystemColors.ButtonShadow;
            showListButton.ForeColor = SystemColors.ControlText;
            showListButton.Location = new Point(459, 176);
            showListButton.Name = "showListButton";
            showListButton.Size = new Size(88, 38);
            showListButton.TabIndex = 13;
            showListButton.Text = "Show Rep List";
            showListButton.UseVisualStyleBackColor = false;
            showListButton.Click += showListButton_Click;
            // 
            // saveButton
            // 
            saveButton.BackColor = SystemColors.ButtonShadow;
            saveButton.ForeColor = SystemColors.ControlText;
            saveButton.Location = new Point(410, 363);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(88, 38);
            saveButton.TabIndex = 14;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = false;
            saveButton.Click += saveButton_Click;
            // 
            // ReputationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(559, 413);
            Controls.Add(saveButton);
            Controls.Add(showListButton);
            Controls.Add(welcomeButton);
            Controls.Add(decreaseRepButton);
            Controls.Add(reputationLabel);
            Controls.Add(locationTextBoxLabel);
            Controls.Add(reputationUpDown);
            Controls.Add(locationNameTextBox);
            Controls.Add(addReputationButton);
            Controls.Add(removeButton);
            Controls.Add(newButton);
            Controls.Add(reputationView);
            ForeColor = SystemColors.ControlText;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "ReputationForm";
            StartPosition = FormStartPosition.Manual;
            Text = "Reputation";
            ((System.ComponentModel.ISupportInitialize)reputationView).EndInit();
            ((System.ComponentModel.ISupportInitialize)reputationUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView reputationView;
        private DataGridViewTextBoxColumn Location;
        private DataGridViewTextBoxColumn Reputation;
        private Button newButton;
        private Button removeButton;
        private Button addReputationButton;
        private TextBox locationNameTextBox;
        private NumericUpDown reputationUpDown;
        private Label locationTextBoxLabel;
        private Label reputationLabel;
        private Button decreaseRepButton;
        private Button welcomeButton;
        private Button showListButton;
        private Button saveButton;
    }
}