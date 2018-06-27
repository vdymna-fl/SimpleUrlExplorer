using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UrlExplorer.Core.Dtos;
using UrlExplorer.Core.Helpers;

namespace UrlExplorer.Core.Services
{
    /// <summary>
    /// Result object of word parsing. 
    /// </summary>
    public class WordParsingResult
    {
        public long TotalCount { get; private set; }
        public ICollection<string> AllWords { get; private set; }
        public WordParsingResult(ICollection<string> words)
        {
            TotalCount = words.Count;
            AllWords = words;
        }

        /// <summary>
        /// Get distinct list of words with their counts.
        /// </summary>
        /// <param name="excludeCommonWords">Exclude common words like the, a, an, the, etc.</param>
        /// <returns>Collection of Dtos with words and their counts.</returns>
        public IEnumerable<WordCountDto> GetWordCounts(bool excludeCommonWords)
        {
            return AllWords
                  .Where(w => (!excludeCommonWords || !WordParserHelper.GetCommonWords().Contains(w)))
                  .GroupBy(w => w)
                  .Select(w => new WordCountDto
                  {
                      Word = w.Key,
                      Count = w.Count()
                  });
        }
    }
}