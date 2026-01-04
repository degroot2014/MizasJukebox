using System.Text.Json;

namespace JukeboxDiscordClient.Domain
{
    public class Reputation
    {
        private const string JSON_FILE = "reputation.json";

        public Dictionary<string, int> Reputations { get; set; } = new Dictionary<string, int>();

        public Reputation() { }
        public void LoadReputation()
        {
            if (File.Exists(JSON_FILE))
            {
                var jsonData = File.ReadAllText(JSON_FILE);
                var newRep = JsonSerializer.Deserialize<Dictionary<string, int>>(jsonData);
                if (newRep != null)
                {
                    Reputations = newRep;
                }
            }
        }

        public bool SaveReputation()
        {
            var json = JsonSerializer.Serialize(Reputations);
            File.WriteAllText(JSON_FILE, json);
            return true;
        }

        /// <summary>
        /// Updates the reputation for a given location by the specified change amount. If the location does not exist, it is added with the initial reputation equal to the change amount.
        /// </summary>
        /// <param name="rep"></param>
        /// <param name="change"></param>
        public int ReputationChange(string rep, int change)
        {
            var key = Reputations.Keys.FirstOrDefault(k => string.Equals(k.Normalize(), rep.Normalize(), StringComparison.OrdinalIgnoreCase));
            if(key != null)
            {
                Reputations[key] += change;
            }
            else
            {
                Reputations[rep] = change;
                return change;
            }
            return Reputations[key];
        }

        public void RemoveReputation(string rep)
        {
            var key = Reputations.Keys.FirstOrDefault(k => string.Equals(k.Normalize(), rep.Normalize(), StringComparison.OrdinalIgnoreCase));
            if (key != null)
            {
                Reputations.Remove(rep);
            }
        }
    }
}
