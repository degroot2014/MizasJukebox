using JukeboxDiscordClient;
using JukeboxDiscordClient.Domain;
using JukeboxDiscordClient.Domain.Exceptions;
using System.Data;

namespace MizasJukebox
{
    public partial class ReputationForm : Form
    {
        private Main _mainForm;
        private DiscordClient _discordClient;
        private Reputation _reputation;
        public ReputationForm(Main mainForm, DiscordClient discordClient)
        {
            InitializeComponent();
            _mainForm = mainForm;
            _discordClient = discordClient;
            _reputation = _discordClient.GetReputation();
            reputationView.DataSource = _reputation.Reputations.Select(kvp => new { Key = kvp.Key, Value = kvp.Value }).ToList();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            _reputation.ReputationChange(locationNameTextBox.Text, (int)reputationUpDown.Value);
            reputationView.DataSource = _reputation.Reputations.Select(kvp => new { Key = kvp.Key, Value = kvp.Value }).ToList();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (reputationView.SelectedRows.Count > 0)
            {
                var keyCell = reputationView.SelectedRows[0].Cells["Location"].Value.ToString();

                _reputation.RemoveReputation(keyCell);
                reputationView.DataSource = _reputation.Reputations.Select(kvp => new { Key = kvp.Key, Value = kvp.Value }).ToList();
            }

        }

        private void addReputationButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (reputationView.SelectedRows.Count > 0)
                {
                    var textChannel = _mainForm.GetTextChannel();
                    var keyCell = reputationView.SelectedRows[0].Cells["Location"].Value.ToString();

                    var repChange = (int)reputationUpDown.Value;

                    var valueCell = _reputation.ReputationChange(keyCell, repChange);
                    reputationView.DataSource = _reputation.Reputations.Select(kvp => new { Key = kvp.Key, Value = kvp.Value }).ToList();
                    reputationUpDown.Value = 0;

                    _discordClient.ReputationUp(new KeyValuePair<string, int>(keyCell, valueCell), repChange, textChannel);
                    _mainForm.ClearTextChannelError();
                }
            }
            catch (NoChannelException ex)
            {
                _mainForm.SetTextChannelError();
            }
        }

        private void reputationView_SelectionChanged(object sender, EventArgs e)
        {
            if (reputationView.SelectedRows.Count > 0)
            {
                var keyCell = reputationView.SelectedRows[0].Cells["Location"].Value?.ToString();

                locationNameTextBox.Text = keyCell ?? string.Empty;
            }
        }

        private void decreaseRepButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (reputationView.SelectedRows.Count > 0)
                {
                    var textChannel = _mainForm.GetTextChannel();
                    var keyCell = reputationView.SelectedRows[0].Cells["Location"].Value.ToString();

                    var repChange = (int)reputationUpDown.Value;

                    var valueCell = _reputation.ReputationChange(keyCell, repChange * -1);
                    reputationView.DataSource = _reputation.Reputations.Select(kvp => new { Key = kvp.Key, Value = kvp.Value }).ToList();
                    reputationUpDown.Value = 0;

                    _discordClient.ReputationDown(new KeyValuePair<string, int>(keyCell, valueCell), repChange, textChannel);
                    _mainForm.ClearTextChannelError();
                }
            }
            catch (NoChannelException ex)
            {
                _mainForm.SetTextChannelError();
            }
        }

        private void welcomeButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (reputationView.SelectedRows.Count > 0)
                {
                    var textChannel = _mainForm.GetTextChannel();

                    var keyCell = reputationView.SelectedRows[0].Cells["Location"].Value.ToString();
                    var valueCell = (int)reputationView.SelectedRows[0].Cells["Reputation"].Value;

                    _discordClient.ReputationWelcome(new KeyValuePair<string, int>(keyCell, valueCell), textChannel);
                    _mainForm.ClearTextChannelError();
                }
            }
            catch (NoChannelException ex)
            {
                _mainForm.SetTextChannelError();
            }
        }

        private void showListButton_Click(object sender, EventArgs e)
        {
            try
            {
                _discordClient.ReputationList(_mainForm.GetTextChannel());
                _mainForm.ClearTextChannelError();
            }
            catch (NoChannelException ex)
            {
                _mainForm.SetTextChannelError();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            _discordClient.SaveSettings();
        }
    }
}
