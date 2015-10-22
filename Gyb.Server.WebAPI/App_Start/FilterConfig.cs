using Gyb.Server.WebAPI.filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
 

namespace Gyb.Server.WebAPI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(HttpConfiguration config)
        {
            //config.Filters.Add(new ForceHttpsAttribute());

            //config.Filters.Add(new Base64AuthorizeAttribute());
        }
    }
}