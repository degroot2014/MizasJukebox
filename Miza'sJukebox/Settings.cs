using System.Text.Json;

namespace Miza_sJukebox
{
    public class Settings
    {
        private const string JSON_FILE = "settings.json";
        public string MusicFolderPath { get; set; } = "C:\\";

        public bool LoadSettings()
        {
            if (File.Exists(JSON_FILE))
            {
                var jsonData = File.ReadAllText(JSON_FILE);
                var newSettings = JsonSerializer.Deserialize<Settings>(jsonData);
                if (newSettings != null)
                {
                    MusicFolderPath = newSettings.MusicFolderPath;
                }
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
