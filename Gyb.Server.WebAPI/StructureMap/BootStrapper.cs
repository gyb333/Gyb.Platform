using Gyb.Server.IRepository;
using Gyb.Server.Repository.Learn;
using Gyb.Server.WebAPI.Controllers;
using StructureMap;
using StructureMap.Configuration.DSL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Gyb.Server.WebAPI
{
    public class BootStrapper
    {

        private static Lazy<IContainer> container = new Lazy<IContainer>(() =>
        {
            ObjectFactory.Initialize(t =>
            {
                t.AddRegistry<CourseRegistry>();

                // //通过StructureMap自动扫描所有符合条件项
                // t.Scan(scan =>
                // {
                //     scan.TheCallingAssembly();
                //     scan.WithDefaultConventions();
                // });
                // t.Scan(scan =>
                //{
                //    scan.Assembly("TYStudioDemo.Services");
                //    scan.Assembly("TYStudioDemo.Repositories");
                //});
            });

            return ObjectFactory.Container;

        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IContainer GetConfiguredContainer()
        {
            return container.Value;
        }
       
    }


    public class CourseRegistry : Registry
    {
        //手动添加
        public CourseRegistry()
        {
            For<ICourseRepository>().Use<CourseRepository>();
            For<IHttpController>().Use<CustomCoursesController>();
        }
    }
}