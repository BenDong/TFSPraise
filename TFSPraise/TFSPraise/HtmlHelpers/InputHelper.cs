using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TFSPraise.Models;
namespace TFSPraise.HtmlHelpers
{
    public static class InputHelper
    {
        public static MvcHtmlString InputEditor(this HtmlHelper helper, string inputType, string buttonText, object htmlAttributes = null)
        {
            StringBuilder html = new StringBuilder();
            html.AppendFormat("<input type = '{0}' value = '{1}' ", inputType, buttonText);
          
            var attributes = helper.AttributeEncode(htmlAttributes);
            if (!string.IsNullOrEmpty(attributes))
            {
                attributes = attributes.Trim('{', '}');
                var attrValuePairs = attributes.Split(',');
                foreach (var attrValuePair in attrValuePairs)
                {
                    var equalIndex = attrValuePair.IndexOf('=');
                    var attrValue = attrValuePair.Split('=');
                    html.AppendFormat("{0}='{1}' ", attrValuePair.Substring(0, equalIndex).Trim(), attrValuePair.Substring(equalIndex + 1).Trim());
                }
            }
            html.Append("/>");
            return new MvcHtmlString(html.ToString());
        }
    }
}