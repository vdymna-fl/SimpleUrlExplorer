using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UrlExplorer.Core.Services
{
    /// <summary>
    /// Result object of image parsing. 
    /// </summary>
    public class ImageParsingResult
    {
        public long TotalCount { get; private set; }
        public ICollection<string> ImageUrls { get; private set; }

        public ImageParsingResult(ICollection<string> imageUrls)
        {
            TotalCount = imageUrls.Count;
            ImageUrls = imageUrls;
        }
    }
}