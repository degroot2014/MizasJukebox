using JukeboxDiscordClient.Domain;
using NetCord.Services.Commands;

namespace JukeboxDiscordClient.Modules
{
    public class ReputationModule : CommandModule<CommandContext>
    {
        private readonly Reputation _reputation;

        public ReputationModule(Reputation reputation)
        {
            _reputation = reputation;
        }

        [Command("newrep")]
        public string NewReputationLocation([CommandParameter(Remainder = true)] string newLocation)
        {
            _reputation.ReputationChange(newLocation, 0);
            return $"Welcome to {newLocation}! Reputation starting at 0.";
        }

        [Command("addrep")]
        public string AddReputation(int repIncrease, [CommandParameter(Remainder = true)] string location)
        {
            _reputation.ReputationChange(location, repIncrease);
            var repValue = _reputation.Reputations.GetValueOrDefault(location, 0);
            return $"Reputation Increased by {repIncrease}!!\nReputation for {location} is now {repValue}";
        }

        [Command("rep")]
        public string Reputation([CommandParameter(Remainder = true)] string location)
        {
            var repValue = _reputation.Reputations.GetValueOrDefault(location, 0);
            return $"Reputation for {location} is currently at {repValue}";
        }

        [Command("replist")]
        public string ReputationList()
        {
            var message = "Reputation List:\n";
            foreach (var rep in _reputation.Reputations)
            {
                message += $"{rep.Key}: {rep.Value}\n";
            }
            return message;
        }
    }
}
