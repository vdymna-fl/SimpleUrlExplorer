using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace UrlExplorer.Core.Helpers
{
    /// <summary>
    /// Helper class for word parsing.
    /// </summary>
    public class WordParserHelper
    {
        /// <summary>
        /// Get list of characters that are word separators.
        /// </summary>
        /// <returns>Array of characters.</returns>
        public static char[] GetWordSeparators()
        {
            return new char[]
            {
                ' ',
                ',',
                '.',
                '!',
                '?',
                ':',
                ';',
                '\n',
                '\r',
                '\t'
            };
        }

        // TODO: need to improve this logic
        /// <summary>
        /// Simple check to see if string is a word.
        /// </summary>
        /// <param name="str">Input string to check.</param>
        /// <returns>Boolean identifier whether string is a word or not.</returns>
        public static bool IsWord(string str)
        {
            if (decimal.TryParse(str, out var nbr))
                return false;

            return new Regex(@"\w+").IsMatch(str);
        }

        /// <summary>
        /// Get predefined list of common words.
        /// </summary>
        /// <returns>Hashset of common words.</returns>
        public static HashSet<string> GetCommonWords()
        {
            return new HashSet<string>
            {
                "the",
                "a",
                "an",
                "for",
                "to",
                "and",
                "of",
                "this",
                "is"
            };
        }
    }
}