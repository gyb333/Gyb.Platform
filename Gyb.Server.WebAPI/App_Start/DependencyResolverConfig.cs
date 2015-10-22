using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Gyb.Server.WebAPI 
{
    public class DependencyResolverConfig
    {
        public static void RegisterDependencyResolver(HttpConfiguration config, IContainer container)
        {
            
            //默认的DefaultHttpControllerActivator会先利用当前注册的DependencyResolver对象去激活目标HttpController
            config.DependencyResolver = new StructureMapDependencyResolver(container);
        }

 
    }
}