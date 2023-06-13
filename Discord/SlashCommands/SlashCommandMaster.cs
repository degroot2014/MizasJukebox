using Discord;
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
                case "roll":
                    await DiceCommands.Roll(command);
                    break;
                case "roll-percentile":
                    await DiceCommands.RollPercentile(command);
                    break;
                case "roll-health":
                    await DiceCommands.RollHealth(command);
                    break;
                case "condition":
                    await _referenceCommands.GetCondition(command);
                    break;
            }
        }

        public async Task CreateSlashCommands()
        {
            await CreateRoll();
            await CreatePercentileRoll();
            await CreateRollHealth();
            await CreateConditions();
        }

        private async Task CreateRoll()
        {
            var global = new SlashCommandBuilder()
                .WithName("roll")
                .WithDescription("Roll dice")
                .AddOption(new SlashCommandOptionBuilder()
                    .WithName("dice")
                    .WithDescription("Dice wanting to be rolled")
                    .WithRequired(true)
                    .AddChoice("d4", 4)
                    .AddChoice("d6", 6)
                    .AddChoice("d8", 8)
                    .AddChoice("d10", 10)
                    .AddChoice("d12", 12)
                    .AddChoice("d20", 20)
                    .WithType(ApplicationCommandOptionType.Integer))
                .AddOption("number", ApplicationCommandOptionType.Integer, "Number of dice to roll")
                .AddOption("modifier", ApplicationCommandOptionType.Integer, "Modifier to add to rolls");
            await _client.CreateGlobalApplicationCommandAsync(global.Build());
        }

        private async Task CreatePercentileRoll()
        {
            var global = new SlashCommandBuilder()
                .WithName("roll-percentile")
                .WithDescription("Rolls 2 d10 dice for percentile");
            await _client.CreateGlobalApplicationCommandAsync(global.Build());
        }

        private async Task CreateRollHealth()
        {
            var global = new SlashCommandBuilder()
                .WithName("roll-health")
                .WithDescription("Rolls dice for health potions")
                .AddOption(new SlashCommandOptionBuilder()
                    .WithName("type")
                    .WithDescription("Type of health potion")
                    .WithRequired(true)
                    .AddChoice("Regular", 2)
                    .AddChoice("Greater", 4)
                    .AddChoice("Superior", 8)
                    .AddChoice("Supreme", 10)
                    .WithType(ApplicationCommandOptionType.Integer));
            await _client.CreateGlobalApplicationCommandAsync(global.Build());
        }

        private async Task CreateConditions()
        {
            //api call
            var conditions = _referenceCommands.GetConditions();
            var options = new SlashCommandOptionBuilder()
                .WithName("condition")
                .WithDescription("Condition to get more information about")
                .WithRequired(true);
            foreach (var condition in conditions)
            {
                options.AddChoice(condition.name, condition.slug);
            }
            options.WithType(ApplicationCommandOptionType.String);

            var global = new SlashCommandBuilder()
                .WithName("condition")
                .WithDescription("Get Condition information");
            global.AddOption(options);
            await _client.CreateGlobalApplicationCommandAsync(global.Build());
        }
    }
}
