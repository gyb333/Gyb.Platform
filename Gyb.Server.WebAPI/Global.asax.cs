using Gyb.Server.WebAPI.filters;
using Gyb.Server.WebAPI.StructureMap;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Routing;

namespace Gyb.Server.WebAPI
{
    /// <summary>
    /// 缓存需解析的Controller Filter 
    /// </summary>
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            
           GlobalConfiguration.Configure(WebApiConfig.Register);

         

        }
    }
}
