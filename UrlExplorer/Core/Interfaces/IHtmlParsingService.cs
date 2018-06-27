using System;

namespace UrlExplorer.Core.Services.Interfaces
{
    public interface IHtmlParsingService
    {
        ParsingResult Load(Uri uri);
        ImageParsingResult ParseImages();
        WordParsingResult ParseWords();
    }
}