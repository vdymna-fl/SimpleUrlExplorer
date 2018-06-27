using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UrlExplorer.Core.Dtos;
using UrlExplorer.Validations;

namespace UrlExplorer.ViewModels
{
    public class ExplorerViewModel
    {
        [Required(ErrorMessage = "Please enter valid URL")]
        [Url(ErrorMessage = "Please enter valid URL")]
        [Display(Name = "Enter URL to explore")]
        public string Url { get; set; }
        public long TotalWordCount { get; set; }
        public IEnumerable<WordCountDto> TopWords { get; set; }
        public long TotalImageCount { get; set; }
        public IEnumerable<string> ImageUrls { get; set; }

        public ExplorerViewModel()
        {
            TopWords = new List<WordCountDto>();
            ImageUrls = new List<string>();
        }
    }
}