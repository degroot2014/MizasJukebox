using System.Text.Json;

namespace JukeboxDiscordClient.Domain
{
    public class DiscordSettings
    {
        private const string JSON_FILE = "settings.json";
        public string MusicFolderPath { get; set; } = "C:\\";
        public string MapCommand { get; set; } = string.Empty;

        public bool LoadSettings()
        {
            if (File.Exists(JSON_FILE))
            {
                var jsonData = File.ReadAllText(JSON_FILE);
                var newSettings = JsonSerializer.Deserialize<DiscordSettings>(jsonData);
                if (newSettings != null)
                {
                    MusicFolderPath = newSettings.MusicFolderPath;
                    MapCommand = newSettings.MapCommand;
                }
            }
            return true;
        }
    }
}
