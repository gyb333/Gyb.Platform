using Gyb.Server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

namespace Gyb.Server.WebAPI
{
    public static class ODataConfig
    {
        public static void Register(HttpConfiguration config)
        {
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

            config.EnableQuerySupport();
        }
    }
}