using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.OData;
using System.Web.OData.Routing;
using Gyb.Server.Data;
using Gyb.Server.Entities;

namespace Gyb.Server.WebAPI.Controllers
{
    /*
    在为此控制器添加路由之前，WebApiConfig 类可能要求你做出其他更改。请适当地将这些语句合并到 WebApiConfig 类的 Register 方法中。请注意 OData URL 区分大小写。

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using Gyb.Server.Entities;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Course>("Courses");
    builder.EntitySet<Subject>("Subjects"); 
    builder.EntitySet<Tutor>("Tutors"); 
    builder.EntitySet<Enrollment>("Enrollments"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class CoursesController : ODataController
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: odata/Courses
        [EnableQuery]
        public IQueryable<Course> GetCourses()
        {
            return db.Courses;
        }

        // GET: odata/Courses(5)
        [EnableQuery]
        public SingleResult<Course> GetCourse([FromODataUri] int key)
        {
            return SingleResult.Create(db.Courses.Where(course => course.Id == key));
        }

        // PUT: odata/Courses(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Course> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Course course = await db.Courses.FindAsync(key);
            if (course == null)
            {
                return NotFound();
            }

            patch.Put(course);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(course);
        }

        // POST: odata/Courses
        public async Task<IHttpActionResult> Post(Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Courses.Add(course);
            await db.SaveChangesAsync();

            return Created(course);
        }

        // PATCH: odata/Courses(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Course> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Course course = await db.Courses.FindAsync(key);
            if (course == null)
            {
                return NotFound();
            }

            patch.Patch(course);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(course);
        }

        // DELETE: odata/Courses(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Course course = await db.Courses.FindAsync(key);
            if (course == null)
            {
                return NotFound();
            }

            db.Courses.Remove(course);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Courses(5)/CourseSubject
        [EnableQuery]
        public SingleResult<Subject> GetCourseSubject([FromODataUri] int key)
        {
            return SingleResult.Create(db.Courses.Where(m => m.Id == key).Select(m => m.CourseSubject));
        }

        // GET: odata/Courses(5)/CourseTutor
        [EnableQuery]
        public SingleResult<Tutor> GetCourseTutor([FromODataUri] int key)
        {
            return SingleResult.Create(db.Courses.Where(m => m.Id == key).Select(m => m.CourseTutor));
        }

        // GET: odata/Courses(5)/Enrollments
        [EnableQuery]
        public IQueryable<Enrollment> GetEnrollments([FromODataUri] int key)
        {
            return db.Courses.Where(m => m.Id == key).SelectMany(m => m.Enrollments);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CourseExists(int key)
        {
            return db.Courses.Count(e => e.Id == key) > 0;
        }
    }
}
