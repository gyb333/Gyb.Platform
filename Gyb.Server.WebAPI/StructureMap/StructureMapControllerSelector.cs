﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Gyb.Server.WebAPI.StructureMap
{
    /// <summary>
    /// 实现现版本控制
    /// </summary>
    public class StructureMapControllerSelector : DefaultHttpControllerSelector
    {
        private HttpConfiguration _config;
        public StructureMapControllerSelector(HttpConfiguration config)
            : base(config)
        {
            _config = config;
        }

        //获取Controller的版本
        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            //获取所有实现了ApiController的类
            var controllers = GetControllerMapping(); //Will ignore any controls in same name even if they are in different namepsace

            //通过request对象获取routeData ，然后进一步获得Controller的name
            var routeData = request.GetRouteData();

            if (string.IsNullOrWhiteSpace(routeData.Route.RouteTemplate))
            {
                return base.SelectController(request);
            }

            var controllerName = routeData.Values["controller"].ToString();

            HttpControllerDescriptor controllerDescriptor;

            if (controllers.TryGetValue(controllerName, out controllerDescriptor))
            {

                //var version = GetVersionFromQueryString(request);
                //var version = GetVersionFromHeader(request);
                var version = GetVersionFromAcceptHeaderVersion(request);

                var versionedControllerName = string.Concat(controllerName, "V", version);

                HttpControllerDescriptor versionedControllerDescriptor;
                if (controllers.TryGetValue(versionedControllerName, out versionedControllerDescriptor))
                {
                    return versionedControllerDescriptor;
                }

                return controllerDescriptor;
            }

            return null;

        }

        private string GetVersionFromAcceptHeaderVersion(HttpRequestMessage request)
        {
            var acceptHeader = request.Headers.Accept;

            foreach (var mime in acceptHeader)
            {
                if (mime.MediaType == "application/json")
                {
                    var version = mime.Parameters
                                    .Where(v => v.Name.Equals("version", StringComparison.OrdinalIgnoreCase))
                                    .FirstOrDefault();

                    if (version != null)
                    {
                        return version.Value;
                    }
                    return "1";
                }
            }
            return "1";
        }

        private string GetVersionFromHeader(HttpRequestMessage request)
        {
            const string HEADER_NAME = "X-Learning-Version";

            if (request.Headers.Contains(HEADER_NAME))
            {
                var versionHeader = request.Headers.GetValues(HEADER_NAME).FirstOrDefault();
                if (versionHeader != null)
                {
                    return versionHeader;
                }
            }

            return "1";
        }

        private string GetVersionFromQueryString(HttpRequestMessage request)
        {
            var query = HttpUtility.ParseQueryString(request.RequestUri.Query);

            var version = query["v"];

            if (version != null)
            {
                return version;
            }

            return "1";

        }
    }
}