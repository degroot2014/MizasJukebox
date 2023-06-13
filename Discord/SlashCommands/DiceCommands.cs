using Discord.WebSocket;

namespace JukeboxDiscordClient.SlashCommands
{
    public static class DiceCommands
    {
        public static async Task Roll(SocketSlashCommand command)
        {
            var dice = Convert.ToInt32((long)command.Data.Options.First(o => o.Name == "dice").Value);
            long rolls = 1;
            long modifier = 0;

            if(command.Data.Options.FirstOrDefault(o => o.Name == "number") != null)
            {
                rolls = (long)command.Data.Options.First(o => o.Name == "number").Value;
            }
            if (command.Data.Options.FirstOrDefault(o => o.Name == "modifier") != null)
            {
                modifier = (long)command.Data.Options.First(o => o.Name == "modifier").Value;
            }

            var message = $"Rolling d{dice} {rolls} {(rolls == 1 ? "time" : "times")} {(modifier > 0 ? $"with modifier of {modifier}" : String.Empty)}";

            RollDice(ref message, dice, rolls, modifier);
            await command.RespondAsync(message);

        }

        public static async Task RollPercentile(SocketSlashCommand command)
        {
            var message = $"Rolling 2 d10s for percentile";
            var diceRolls = RollDice(ref message, 10, 2, 0);
            message += $"\nPercentile roll is {(diceRolls[0] * 10 + diceRolls[1])}";
            await command.RespondAsync(message);
        }

        public static async Task RollHealth(SocketSlashCommand command)
        {
            var healthPot = (long)command.Data.Options.First(o => o.Name == "type").Value;
            var bonusHealth = 0;
            var message = $"Rolling dice for Health Potion";
            var rolls = RollDice(ref message, 4, healthPot, 0);
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
            await command.RespondAsync(message);
        }

        private static IList<int> RollDice(ref string message, int sides, long rolls, long modifier)
        {
            var diceRolls = new List<int>();

            var starting = 1;
            if (sides == 10)
            {
                starting = 0;
            }

            var rnd = new Random();
            for (int i = 0; i < rolls; i++)
            {
                var diceRoll = rnd.Next(starting, sides);
                message += $"\nRoll {i + 1}: {diceRoll + modifier}";
                diceRolls.Add(diceRoll);
            }

            return diceRolls;
        }
    }
}
