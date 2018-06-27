using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UrlExplorer.Core.Services
{
    /// <summary>
    /// Enum for result of an HTML document parsing.
    /// </summary>
    public enum ParsingResult
    {
        Success,
        ErrorOccured,
        NotFound
    }
}