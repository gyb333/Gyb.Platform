using Gyb.Server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

namespace Gyb.Server.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //// Web API 配置和服务

            //// Web API 路由
            //config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Course>("Courses");
            builder.EntitySet<Enrollment>("Enrollments");
            builder.EntitySet<Student>("Students");
            builder.EntitySet<Subject>("Subjects");
            builder.EntitySet<Tutor>("Tutors");

            config.MapODataServiceRoute(
               routeName: "ODataRoute",
               routePrefix: null,
               model: builder.GetEdmModel());
        }
    }
}
