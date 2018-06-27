using System;
using UrlExplorer.Core.Services;

namespace UrlExplorer.Core.Interfaces
{
    /// <summary>
    /// Interface that defines methods for a service for parsing HTML document.
    /// </summary>
    public interface IHtmlParsingService
    {
        ParsingResult Load(Uri uri);
        ImageParsingResult ParseImages();
        WordParsingResult ParseWords();
    }
}