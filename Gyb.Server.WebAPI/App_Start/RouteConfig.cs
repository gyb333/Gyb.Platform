using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
 

namespace Gyb.Server.WebAPI 
{
    public class RouteConfig
    {
        public static void RegisterRoutes(HttpConfiguration config)
        {
            //config.Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //config.Routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "CustomCourses",
                routeTemplate: "api/{CustomCourses}/{id}",
                defaults: new { controller = "CustomCourses", id = RouteParameter.Optional }
            );

        }

    }
}