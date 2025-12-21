using JukeboxDiscordClient.Domain;
using NetCord.Rest;
using NetCord.Services.Commands;

namespace JukeboxDiscordClient.Modules
{
    public class LinkModule : CommandModule<CommandContext>
    {
        private readonly DiscordSettings _settings = new();

        [Command("map")]
        public async Task SquareAsync()
        {
            _settings.LoadSettings();
            var message = new MessageProperties().AddAttachments(new AttachmentProperties(Path.GetFileName(_settings.MapCommand),File.OpenRead(_settings.MapCommand)));
            await Context.Channel.SendMessageAsync(message);
        }
    }
}