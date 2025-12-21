/*using Discord;
using Discord.WebSocket;

namespace JukeboxDiscordClient.SlashCommands
{
    public class SlashCommandMaster
    {
        private DiscordSocketClient _client;
        private ReferenceCommands _referenceCommands;

        public SlashCommandMaster(DiscordSocketClient client)
        {
            _client = client;
            _referenceCommands = new ReferenceCommands();
        }

        public async Task SlashCommandAsync(SocketSlashCommand command)
        {
            switch (command.Data.Name)
            {
             
                case "condition":
                    await _referenceCommands.GetCondition(command);
                    break;
                case "spell-list":
                    await _referenceCommands.GetSpellList(command);
                    break;
                case "spell":
                    await _referenceCommands.GetSpell(command);
                    break;
            }
        }

        public async Task CreateSlashCommands()
        {

            await CreateRoll();
            await CreateDmRoll();
            await CreatePercentileRoll();
            await CreateRollHealth();
            await CreateConditions();
            await CreateSpellList();
            await CreateSpell();

            //_referenceCommands.Test();
        }

       

        private async Task CreateSpellList()
        {
            var global = new SlashCommandBuilder()
                .WithName("spell-list")
                .WithDescription("Retrieves list of spells for selected Class")
                .AddOption(new SlashCommandOptionBuilder()
                    .WithName("class")
                    .WithDescription("Class wanted for Spells")
                    .WithRequired(true)
                    .AddChoice("Bard", "bard")
                    .AddChoice("Cleric", "cleric")
                    .AddChoice("Druid", "druid")
                    .AddChoice("Paladin", "paladin")
                    .AddChoice("Ranger", "ranger")
                    .AddChoice("Sorcerer", "sorcerer")
                    .AddChoice("Warlock", "warlock")
                    .AddChoice("Wizard", "wizard")
                    .WithType(ApplicationCommandOptionType.String))
                .AddOption(new SlashCommandOptionBuilder()
                    .WithName("show-everyone")
                    .WithDescription("Shows everyone results")
                    .WithRequired(false)
                    .AddChoice("Yes", 1)
                    .WithType(ApplicationCommandOptionType.Integer));
            await _client.CreateGlobalApplicationCommandAsync(global.Build());
        }
        private async Task CreateSpell()
        {
            var global = new SlashCommandBuilder()
                .WithName("spell")
                .WithDescription("Gets Spell information for a spell")
                .AddOption("spell", ApplicationCommandOptionType.String, "Name of Spell", true)
                .AddOption(new SlashCommandOptionBuilder()
                    .WithName("show-only-me")
                    .WithDescription("Shows only you the results")
                    .WithRequired(false)
                    .AddChoice("Yes", 1)
                    .WithType(ApplicationCommandOptionType.Integer));
            await _client.CreateGlobalApplicationCommandAsync(global.Build());
        }
    }
}*/