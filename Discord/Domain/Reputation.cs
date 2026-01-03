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
        public void ReputationChange(string rep, int change)
        {
            if (Reputations.ContainsKey(rep))
            {
                Reputations[rep] += change;
            }
            else
            {
                Reputations[rep] = change;
            }
        }

        public void RemoveReputation(string rep)
        {
            if (Reputations.ContainsKey(rep))
            {
                Reputations.Remove(rep);
            }
        }
    }
}
