using CacheCow.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Gyb.Server.WebAPI 
{
    public class CacheCowConfig
    {
        public static void RegisterCacheCow(HttpConfiguration config)
        {
            //var connString = System.Configuration.ConfigurationManager.ConnectionStrings["eLearningConnection"].ConnectionString;
            //var eTagStore = new CacheCow.Server.EntityTagStore.SqlServer.SqlServerEntityTagStore(connString);
            //var cacheCowCacheHandler = new CacheCow.Server.CachingHandler(eTagStore);
            //cacheCowCacheHandler.AddLastModifiedHeader = false;
            //config.MessageHandlers.Add(cacheCowCacheHandler);

            var cacheCowCacheHandler = new CachingHandler(config);
            config.MessageHandlers.Add(cacheCowCacheHandler);


            //config.MessageHandlers.Add(
            //    new CachingHandler(new SqlServerEntityTagStore())
            //    {
            //        CacheKeyGenerator = CacheCowHelper.GenerateCacheKey,
            //        LinkedRoutePatternProvider = CacheCowHelper.GetLinkedRoutes
            //    }
            //);
        }
    }
}