using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrlExplorer.Core.Services;
using UrlExplorer.Core.Interfaces;
using UrlExplorer.ViewModels;

namespace UrlExplorer.Controllers
{
    public class HomeController : Controller
    {
        private IHtmlParsingService _htmlParser;

        public HomeController(IHtmlParsingService htmlParser)
        {
            _htmlParser = htmlParser;
        }

        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        public ActionResult Explore(ExplorerViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Explorer", model);
                }

                var uri = new Uri(model.Url);
                var loadResult = _htmlParser.Load(uri);

                if (loadResult != ParsingResult.Success)
                {
                    if (loadResult == ParsingResult.NotFound)
                    {
                        ModelState.AddModelError("Url", "The URL cannot to be resolved");
                        return View("Explorer", model);
                    }
                    else
                    {
                        return View("Error");
                    }
                }

                var wordParsingResult = _htmlParser.ParseWords();
                var imageParsingResult = _htmlParser.ParseImages();

                model.TotalWordCount = wordParsingResult.TotalCount;
                // Select top 12 words by occurrence
                model.TopWords = wordParsingResult.GetWordCounts(true)
                                    .OrderByDescending(w => w.Count)                            
                                    .Take(12);

                model.TotalImageCount = imageParsingResult.TotalCount;
                model.ImageUrls = imageParsingResult.ImageUrls;

                return View("Explorer", model);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }
    }
}