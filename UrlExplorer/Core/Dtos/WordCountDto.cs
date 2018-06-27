using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UrlExplorer.Core.Dtos
{
    /// <summary>
    /// Data transfer object for words and their counts.
    /// </summary>
    public class WordCountDto
    {
        public string Word { get; set; }
        public int Count { get; set; }
    }
}