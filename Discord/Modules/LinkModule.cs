using Discord.Commands;
using JukeboxDiscordClient.Domain;

namespace JukeboxDiscordClient.Modules
{
    public class LinkModule : ModuleBase<SocketCommandContext>
    {
        private readonly DiscordSettings _settings = new();

        [Command("map")]
        [Summary("Returns map")]
        public async Task SquareAsync()
        {
            _settings.LoadSettings();
            await Context.Channel.SendFileAsync(_settings.MapCommand);
        }
    }
}
