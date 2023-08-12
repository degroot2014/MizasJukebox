using Discord.WebSocket;

namespace JukeboxDiscordClient.SlashCommands
{
    public static class DiceCommands
    {
        private static readonly Random random = new ();
        private static readonly object syncLock = new ();

        public static async Task Roll(SocketSlashCommand command)
        {
            var dice = Convert.ToInt32((long)command.Data.Options.First(o => o.Name == "dice").Value);
            long rolls = 1;
            long modifier = 0;
            long rig = 0;
            long hide = 0;

            if (command.Data.Options.FirstOrDefault(o => o.Name == "number") != null)
            {
                rolls = (long)command.Data.Options.First(o => o.Name == "number").Value;
            }
            if (command.Data.Options.FirstOrDefault(o => o.Name == "modifier") != null)
            {
                modifier = (long)command.Data.Options.First(o => o.Name == "modifier").Value;
            }
            if (command.Data.Options.FirstOrDefault(o => o.Name == "rig") != null)
            {
                rig = (long)command.Data.Options.First(o => o.Name == "rig").Value;
            }
            if (command.Data.Options.FirstOrDefault(o => o.Name == "hide") != null)
            {
                hide = (long)command.Data.Options.First(o => o.Name == "hide").Value;
            }

            var message = $"Rolling d{dice} {rolls} {(rolls == 1 ? "time" : "times")} {(modifier > 0 ? $"with modifier of {modifier}" : String.Empty)}";

            RollDice(ref message, dice, rolls, modifier, rig);
            await command.RespondAsync(message, ephemeral:(hide > 0));

        }

        public static async Task RollPercentile(SocketSlashCommand command)
        {
            var message = $"Rolling 2 d10s for percentile";
            var diceRolls = RollDice(ref message, 10, 2);
            message += $"\nPercentile roll is {(diceRolls[0] * 10 + diceRolls[1])}";
            await command.RespondAsync(message);
        }

        public static async Task RollHealth(SocketSlashCommand command)
        {
            var healthPot = (long)command.Data.Options.First(o => o.Name == "type").Value;
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
            await command.RespondAsync(message);
        }

        private static IList<int> RollDice(ref string message, int sides, long rolls = 1, long modifier = 0, long rig = 0)
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
                var diceRoll = RandomNumber(starting, sides + 1);
                message += $"\nRoll {i + 1}: {diceRoll + modifier}";
                diceRolls.Add(diceRoll);
            }

            return diceRolls;
        }

        private static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            {
                return random.Next(min, max);
            }
        }
    }
}
