using System.Text.Json;

namespace MizasJukebox.Domain
{
    public class Settings
    {
        private const string JSON_FILE = "settings.json";
        public string MusicFolderPath { get; set; } = "C:\\Users\\Eric\\Music";
        public string MapCommand { get; set; } = string.Empty;

        public bool LoadSettings()
        {
            if (File.Exists(JSON_FILE))
            {
                var jsonData = File.ReadAllText(JSON_FILE);
                var newSettings = JsonSerializer.Deserialize<Settings>(jsonData);
                if (newSettings != null)
                {
                    MusicFolderPath = newSettings.MusicFolderPath;
                    MapCommand = newSettings.MapCommand;
                }
            }
            else 
            {
                return false;
            }
            return true;
        }

        public bool SaveSettings()
        {
            var json = JsonSerializer.Serialize(this);
            File.WriteAllText(JSON_FILE, json);
            return true;
        }
    }
}
