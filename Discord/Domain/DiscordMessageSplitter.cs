namespace JukeboxDiscordClient.Domain
{
    public static class DiscordMessageSplitter
    {
        public static IEnumerable<string> Split(
            string text,
            int maxLength = 2000)
        {
            if (string.IsNullOrWhiteSpace(text))
                yield break;

            text = text.Trim();

            while (text.Length > maxLength)
            {
                var slice = text.Substring(0, maxLength);

                int splitIndex =
                    slice.LastIndexOf('\n') >= 0 ? slice.LastIndexOf('\n') :
                    LastSentenceEnd(slice) >= 0 ? LastSentenceEnd(slice) :
                    slice.LastIndexOf(' ') >= 0 ? slice.LastIndexOf(' ') :
                    maxLength;

                yield return text.Substring(0, splitIndex).Trim();
                text = text.Substring(splitIndex).Trim();
            }

            if (text.Length > 0)
                yield return text;
        }

        private static int LastSentenceEnd(string text)
        {
            int last = -1;
            foreach (char c in new[] { '.', '!', '?' })
            {
                int idx = text.LastIndexOf(c);
                if (idx > last)
                    last = idx + 1;
            }
            return last;
        }
    }

}
