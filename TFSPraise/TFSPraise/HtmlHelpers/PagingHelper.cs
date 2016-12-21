using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TFSPraise.Models;

namespace TFSPraise.HtmlHelpers
{
    public static class PagingHelper
    {
        public static MvcHtmlString PageLinks(this HtmlHelper helper, PageInfo pageInfo, Func<int, string> pageUrl)
        {
            StringBuilder html = new StringBuilder();

            for (int p = 1; p <= pageInfo.TotalPages; p++)
            {
                TagBuilder linkTag = new TagBuilder("a");
                linkTag.SetInnerText(p.ToString());
                linkTag.MergeAttribute("href", pageUrl(p));
                html.Append(linkTag.ToString());
            }
            return MvcHtmlString.Create(html.ToString());
        }
    }
}