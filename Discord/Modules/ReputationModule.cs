using JukeboxDiscordClient.Domain;
using JukeboxDiscordClient.Domain.Extensions;
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

        [Command("rep")]
        public string Reputation([CommandParameter(Remainder = true)] string location)
        {
            var actualKey = _reputation.Reputations.Keys.FirstOrDefault(k => k.NormalizeSpecial().Equals(location.NormalizeSpecial(), StringComparison.OrdinalIgnoreCase));
            if (actualKey == null)
            {
                return $"Location '{location}' not found in reputation list.";
            }

            var repValue = _reputation.Reputations[actualKey];
            return WrapMessage($"Reputation for {actualKey} is currently at {repValue}.");
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

        private string WrapMessage(string message)
        {
            return $"<---------------------------------------->\n{message}\n<---------------------------------------->";
        }
    }
}
