using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JagHarAldrig.Extensions
{
    public static class StringExtensions
    {
        public static bool IsValid(this string value)
        {
            return !String.IsNullOrWhiteSpace(value) && value.Length > 4;
        }

        public static string Format(this string value)
        {
            value = value.Trim();
            if (NeedsDotsAtStart(value)) value = "..." + value;
            value = TurnStartOfFirstWordToLowerLetter(value);
            value = RemoveDuplicateWhiteSpaces(value);

            if (!value.EndsWith("!") &&
                !value.EndsWith("?") &&
                !value.EndsWith("."))
            {
                value += ".";
            }            
            return value;
        }

        private static bool NeedsDotsAtStart(string value)
        {
            return
                !Char.IsPunctuation(value, 0) ||
                !Char.IsPunctuation(value, 1) ||
                !Char.IsPunctuation(value, 2);
        }

        private static string TurnStartOfFirstWordToLowerLetter(string value)
        {
            List<string> words = value.Split(' ').ToList();
            words[0] = words[0].ToLower();
            value = string.Empty;
            foreach (var word in words)
            {
                value += " " + word;
            }
            return value.Trim();
        }

        private static string RemoveDuplicateWhiteSpaces(string value)
        {
            List<string> words = value.Split(' ').ToList();
            words = words
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .ToList();
            value = string.Empty;
            foreach (var word in words)
            {
                value += " " + word;
            }
            return value.Trim();
        }
    }
}
