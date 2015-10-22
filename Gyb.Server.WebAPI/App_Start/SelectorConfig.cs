using Gyb.Server.WebAPI.StructureMap;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace Gyb.Server.WebAPI 
{
    public class SelectorConfig
    {
        public static void RegisterSelector(HttpConfiguration config)
        {

            config.Services.Replace(typeof(IHttpControllerSelector), new ControllerSelector((config)));
        }
    }
}