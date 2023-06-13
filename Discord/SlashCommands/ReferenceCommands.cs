using Discord.WebSocket;
using JukeboxDiscordClient.Api;

namespace JukeboxDiscordClient.SlashCommands
{
    public class ReferenceCommands
    {
        private Open5eApi _api;

        public ReferenceCommands()
        {
            _api = new Open5eApi();
        }

        public IList<Result> GetConditions()
        {
            return _api.GetConditions();
        }

        public async Task GetCondition(SocketSlashCommand command)
        {
            var name = (string)command.Data.Options.First(o => o.Name == "condition").Value;
            var condition = _api.GetCondition(name);

            var message = $"{condition.name}\n{condition.desc}";
            await command.RespondAsync(message);
        }

    }
}
