using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TelefonRehberi.Kutuphane
{
   static public class HtmlHelpers
    {
        public static MvcHtmlString ButtonLink(this HtmlHelper helper,string link,string sinif,string iconsinif,string text)
        {
            string html = string.Format("<a href='{0}' class='{1}'><i class='{2}'></i> {3}</a>", link, sinif, iconsinif, text);

            return MvcHtmlString.Create(html);
        }

        public static MvcHtmlString ButtonSubmit(this HtmlHelper helper, string type, string sinif,string iconsinif,string text)
        {
            string html = string.Format("<input type ='{0}' class='{1}'> <em class='{2}'></em> {3}</input>", type, sinif, iconsinif, text);
            return MvcHtmlString.Create(html);

        }

      
        }
  
    }
