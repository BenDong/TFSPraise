using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TFSPraise
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}"
           );

            routes.MapRoute(
                name: "PraiseRoute",
                url: "{controller}/{action}/{page}",
                defaults: new { controller = "Praise", action = "PraiseList", page = UrlParameter.Optional }
            );

            routes.MapRoute( "", "{controller}/{action}/{id}/{page}", new { id = UrlParameter.Optional, page = UrlParameter.Optional }
           );
        }
    }
}
