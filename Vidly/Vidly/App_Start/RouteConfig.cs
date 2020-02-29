using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapMvcAttributeRoutes();



            //define custume route OLD
            /*
            routes.MapRoute(
                "MoviesByReleaseDate",
                "Movies/release/{year}/{month}",
                new { Controller = "Movies" , action = "ByReleaseDate" },
                new {year = @"\d{4}", month = @"\d{2}"}
                // to specify years year = @"2015 | 2016"
                );
                */

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
