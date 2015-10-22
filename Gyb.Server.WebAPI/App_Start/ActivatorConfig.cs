using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace Gyb.Server.WebAPI 
{
    public class ActivatorConfig
    {
        public static void RegisterActivators(HttpConfiguration config, IContainer container)
        {
            config.Services.Replace(typeof(IHttpControllerActivator), new StructureMapHttpControllerActivator(container));
        }
    }
}