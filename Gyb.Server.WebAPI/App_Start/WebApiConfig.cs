using Gyb.Server.Entities;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

namespace Gyb.Server.WebAPI
{
    public static class WebApiConfig
    {
        /// <summary>
        /// 返回对象时出现循环依赖,返回了领域模型中所有的字段给客户端，然而有一些敏感信息不应该返回（例如：password字段）
        /// 每一个返回给客户端的资源都应该包含一个URI以便客户端查询
        /// 对于返回单个资源，我们应当返回相应的状态码（例如：成功200，资源未找到404等）HttpResponseMessage对象
        /// 配置Json格式。
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            //// Web API 配置和服务


            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            //// Web API 路由
            //config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "CustomCourses",
            //    routeTemplate: "api/{CustomCourses}/{id}",
            //    defaults: new { controller = "CustomCourses", id = RouteParameter.Optional }
            //);


            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Course>("Courses");
            //builder.EntitySet<Course>("CustomCourses");

            builder.EntitySet<Enrollment>("Enrollments");
            builder.EntitySet<Student>("Students");
            builder.EntitySet<Subject>("Subjects");
            builder.EntitySet<Tutor>("Tutors");

            var tutorsEntitySet = builder.EntitySet<Tutor>("Tutors");

            tutorsEntitySet.EntityType.Ignore(s => s.UserName);
            tutorsEntitySet.EntityType.Ignore(s => s.Password);

            config.MapODataServiceRoute(
               routeName: "ODataRoute",
               routePrefix: null,
               model: builder.GetEdmModel());



         
        }
    }
}
