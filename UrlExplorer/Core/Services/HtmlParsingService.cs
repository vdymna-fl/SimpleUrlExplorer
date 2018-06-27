using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using UrlExplorer.Core.Helpers;
using UrlExplorer.Core.Interfaces;

namespace UrlExplorer.Core.Services
{
    /// <summary>
    /// Class responsible for parsing HTML documents.
    /// </summary>
    public class HtmlParsingService : IHtmlParsingService
    {
        private HtmlWeb _htmlWeb;
        private HtmlDocument _htmlDocument;
        private Uri _uri;

        public HtmlParsingService()
        {
            _htmlWeb = new HtmlWeb();
        }

        /// <summary>
        /// Load an HTML document from Internet using Uri.
        /// </summary>
        /// <param name="uri">Uri for document to load.</param>
        /// <returns>Result of loading/parsing operation. </returns>
        public ParsingResult Load(Uri uri)
        {
            try
            {
                _htmlDocument = _htmlWeb.Load(uri);
                _uri = uri;

                return ParsingResult.Success;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("The remote name could not be resolved"))
                {
                    return ParsingResult.NotFound;
                }
                else
                {
                    return ParsingResult.ErrorOccured;
                }
            }
        }

        /// <summary>
        /// Parses an HTML document for images and returns a result. This will search for <img> physical HTML tag.
        /// </summary>
        /// <returns>Object that contains parsing results.</returns>
        public ImageParsingResult ParseImages()
        {
            if (_htmlDocument == null) throw new ArgumentNullException(nameof(_htmlDocument));

            var listOfImageUrls = new List<string>();

            var imageSources = _htmlDocument.DocumentNode.SelectSingleNode("//body")
                                                 .Descendants("img")
                                                 .Select(n => n.GetAttributeValue("src", null))
                                                 .Where(s => !String.IsNullOrEmpty(s));

            foreach (var imgSrc in imageSources)
            {
                if (Uri.TryCreate(imgSrc, UriKind.Absolute, out var imgUri))
                {
                    listOfImageUrls.Add(imgSrc);
                }
                else
                {
                    listOfImageUrls.Add(new UriBuilder(_uri.Scheme, _uri.Host, _uri.Port, imgSrc).ToString());
                }
            }

            return new ImageParsingResult(listOfImageUrls);
        }

        /// <summary>
        /// Parses an HTML document for words and returns a result. 
        /// </summary>
        /// <returns>Object that contains parsing results.</returns>
        public WordParsingResult ParseWords()
        {
            if (_htmlDocument == null) throw new ArgumentNullException(nameof(_htmlDocument));

            var listOfWords = new List<string>();

            var nodes = _htmlDocument.DocumentNode.SelectSingleNode("//body")
                                     .DescendantsAndSelf()
                                     .Where(n => n.NodeType == HtmlNodeType.Text &&
                                                 n.ParentNode.Name != "script" && // exclude <script> element
                                                 n.ParentNode.Name != "style"); // exclude <style> element

            foreach (var node in nodes)
            {
                var chunks = WebUtility.HtmlDecode(node.InnerText)
                                        .Split(WordParserHelper.GetWordSeparators(), StringSplitOptions.RemoveEmptyEntries);

                foreach (var chunk in chunks)
                {
                    if (WordParserHelper.IsWord(chunk))
                    {
                        listOfWords.Add(chunk.ToLower());
                    }
                }
            }

            return new WordParsingResult(listOfWords);
        }
    }
}