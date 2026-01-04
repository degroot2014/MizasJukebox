using System.Globalization;

namespace JukeboxDiscordClient.Domain.Extensions
{
    public static class StringExtensions
    {
        public static string ToPascalCase(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return str;

            // Split by spaces (or other delimiters if needed)
            string[] words = str.Split(new char[] { ' ', '-', '_' }, StringSplitOptions.RemoveEmptyEntries);
            TextInfo textInfo = CultureInfo.InvariantCulture.TextInfo;

            for (int i = 0; i < words.Length; i++)
            {
                // Capitalize first letter of each word
                words[i] = textInfo.ToTitleCase(words[i].ToLower());
            }

            // Combine words without spaces for PascalCase
            return string.Join("", words);
        }

        public static string NormalizeSpecial(this string str) => new string(str.Where(char.IsLetterOrDigit).ToArray());
    }
}
