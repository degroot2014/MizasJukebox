using JukeboxDiscordClient.Domain.interfaces;

namespace JukeboxDiscordClient.Domain
{
    public class RandomService : IRandomService
    {
        private static readonly Random random = new();
        private static readonly object syncLock = new();

        public int RandomNumber(int min, int max)
        {
            return RandomNumberStatic(min, max);
        }

        private static int RandomNumberStatic(int min, int max)
        {
            lock (syncLock)
            {
                return random.Next(min, max);
            }
        }
    }
}
