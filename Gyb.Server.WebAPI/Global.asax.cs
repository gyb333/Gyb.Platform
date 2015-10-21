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
            IContainer container= BootStrapper.ConfigureStructureMap();
            //默认的DefaultHttpControllerActivator会先利用当前注册的DependencyResolver对象去激活目标HttpController
            GlobalConfiguration.Configuration.DependencyResolver = new StructureMapDependencyResolver(container);

            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), new StructureMapHttpControllerActivator(container));

            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerSelector), new StructureMapControllerSelector((GlobalConfiguration.Configuration)));

            //GlobalConfiguration.Configuration.Filters.Add(new ForceHttpsAttribute());
            GlobalConfiguration.Configuration.Filters.Add(new Base64AuthorizeAttribute());
        }
    }
}
