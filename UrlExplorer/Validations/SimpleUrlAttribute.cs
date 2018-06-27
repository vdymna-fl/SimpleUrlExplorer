using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace UrlExplorer.Validations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SimpleUrlAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var url = (String)value;

            var pattern = @"^(http|https|ftp|)\://|[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$";
            var reg = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);

            return reg.IsMatch(url);
        }
    }
}