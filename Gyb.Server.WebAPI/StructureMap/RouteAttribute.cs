using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Routing;

namespace Gyb.Server.WebAPI.StructureMap
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class RouteAttribute : Attribute, IHttpRouteInfoProvider
    {
        public RouteAttribute();
        public RouteAttribute(string template);

        public string Name { get; set; }
        public int Order { get; set; }
        public string Template { get; private set; }

    }
}