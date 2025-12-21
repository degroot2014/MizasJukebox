using JukeboxDiscordClient.Api.interfaces;
using JukeboxDiscordClient.Domain.interfaces;
using NetCord.Rest;
using NetCord.Services.ApplicationCommands;
using static JukeboxDiscordClient.Domain.CommonEnum;
using static JukeboxDiscordClient.Modules.DiceModuleEnums;

namespace JukeboxDiscordClient.Modules
{
    public class DiceModule : ApplicationCommandModule<ApplicationCommandContext>
    {
        private readonly IRandomService _randomService;

        public DiceModule(IRandomService randomService)
        {
            _randomService = randomService;
        }

        [SlashCommand("roll", "Roll dice")]
        public string Roll(
            [SlashCommandParameter(Name = "dice", Description = "Type of die")] Die dieType,
            [SlashCommandParameter(Name = "rolls", Description = "Number of dice to roll")] long rolls = 1,
            [SlashCommandParameter(Name = "modifier", Description = "Modifier to add to rolls")] long modifier = 0)
        {
            var dice = (int)dieType;
            long rig = 0;

            var message = $"Rolling d{dice} {rolls} {(rolls == 1 ? "time" : "times")} {(modifier > 0 ? $"with modifier of {modifier}" : String.Empty)}";

            RollDice(ref message, dice, rolls, modifier, rig);
            return message;

        }

        [SlashCommand("roll-dm", "Roll dice")]
        public InteractionMessageProperties RiggedRoll(
            [SlashCommandParameter(Name = "dice", Description = "Type of die")] Die dieType,
            [SlashCommandParameter(Name = "rolls", Description = "Number of dice to roll")] long rolls = 1,
            [SlashCommandParameter(Name = "modifier", Description = "Modifier to add to rolls")] long modifier = 0,
            [SlashCommandParameter(Name = "rig", Description = "Weighted Rolls")] Rig rig = 0,
            [SlashCommandParameter(Name = "hide", Description = "Hides results")] YesNo hide = YesNo.Yes)
        {
            var dice = (int)dieType;
            var rigValue = (long)rig;

            var message = $"Rolling d{dice} {rolls} {(rolls == 1 ? "time" : "times")} {(modifier > 0 ? $"with modifier of {modifier}" : String.Empty)}";

            RollDice(ref message, dice, rolls, modifier, rigValue);

            var props = new InteractionMessageProperties().WithContent(message);
            if(hide == YesNo.Yes)
            {
                props.WithFlags(NetCord.MessageFlags.Ephemeral);
            }
            return props;
        }

        [SlashCommand("roll-percentile", "Rolls 2 d10 dice for percentile")]
        public string RollPercentile()
        {
            var message = $"Rolling 2 d10s for percentile";
            var diceRolls = RollDice(ref message, 10, 2);
            message += $"\nPercentile roll is {(diceRolls[0] * 10 + diceRolls[1])}";
            return message;
        }

        [SlashCommand("roll-health", "Rolls dice for health potions")]
        public string RollHealth([SlashCommandParameter(Name = "type", Description = "Type of Potion")] HealthPotion potionType)
        {
            var healthPot = (long)potionType;
            var bonusHealth = 0;
            var message = $"Rolling dice for Health Potion";
            var rolls = RollDice(ref message, 4, healthPot);
            switch (healthPot)
            {
                case 2:
                    bonusHealth = 2;
                    break;
                case 4:
                    bonusHealth = 4;
                    break;
                case 8:
                    bonusHealth = 8;
                    break;
                case 10:
                    bonusHealth = 10;
                    break;
            }
            message += $"\nPotion heals {bonusHealth} + rolls for total of {rolls.Sum() + bonusHealth}";
            return message;
        }

        private IList<int> RollDice(ref string message, int sides, long rolls = 1, long modifier = 0, long rig = 0)
        {
            var diceRolls = new List<int>();

            var starting = 1;
            if (sides == 10)
            {
                starting = 0;
                sides = 9;
            }
            if (rig == 1)
            {
                starting = Math.Max(sides - 3, 1);
            }
            if (rig == 2)
            {
                sides = Math.Min(starting + 3, sides);
            }

            for (int i = 0; i < rolls; i++)
            {
                var diceRoll = _randomService.RandomNumber(starting, sides + 1);
                message += $"\nRoll {i + 1}: {diceRoll + modifier}";
                diceRolls.Add(diceRoll);
            }

            return diceRolls;
        }
    }

    public class DiceModuleEnums
    {
        public enum Die
        {
            d4 = 4,
            d6 = 6,
            d8 = 8,
            d10 = 10,
            d12 = 12,
            d20 = 20
        }

        public enum HealthPotion
        {
            Small = 2,
            Medium = 4,
            Large = 8,
            Superior = 10
        }

        public enum Rig
        {
            None = 0,
            High = 1,
            Low = 2
        }
    }

}

