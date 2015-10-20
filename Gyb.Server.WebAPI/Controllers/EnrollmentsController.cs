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
    builder.EntitySet<Enrollment>("Enrollments");
    builder.EntitySet<Course>("Courses"); 
    builder.EntitySet<Student>("Students"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class EnrollmentsController : ODataController
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: odata/Enrollments
        [EnableQuery]
        public IQueryable<Enrollment> GetEnrollments()
        {
            return db.Enrollments;
        }

        // GET: odata/Enrollments(5)
        [EnableQuery]
        public SingleResult<Enrollment> GetEnrollment([FromODataUri] int key)
        {
            return SingleResult.Create(db.Enrollments.Where(enrollment => enrollment.Id == key));
        }

        // PUT: odata/Enrollments(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Enrollment> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Enrollment enrollment = await db.Enrollments.FindAsync(key);
            if (enrollment == null)
            {
                return NotFound();
            }

            patch.Put(enrollment);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnrollmentExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(enrollment);
        }

        // POST: odata/Enrollments
        public async Task<IHttpActionResult> Post(Enrollment enrollment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Enrollments.Add(enrollment);
            await db.SaveChangesAsync();

            return Created(enrollment);
        }

        // PATCH: odata/Enrollments(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Enrollment> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Enrollment enrollment = await db.Enrollments.FindAsync(key);
            if (enrollment == null)
            {
                return NotFound();
            }

            patch.Patch(enrollment);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnrollmentExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(enrollment);
        }

        // DELETE: odata/Enrollments(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Enrollment enrollment = await db.Enrollments.FindAsync(key);
            if (enrollment == null)
            {
                return NotFound();
            }

            db.Enrollments.Remove(enrollment);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Enrollments(5)/Course
        [EnableQuery]
        public SingleResult<Course> GetCourse([FromODataUri] int key)
        {
            return SingleResult.Create(db.Enrollments.Where(m => m.Id == key).Select(m => m.Course));
        }

        // GET: odata/Enrollments(5)/Student
        [EnableQuery]
        public SingleResult<Student> GetStudent([FromODataUri] int key)
        {
            return SingleResult.Create(db.Enrollments.Where(m => m.Id == key).Select(m => m.Student));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EnrollmentExists(int key)
        {
            return db.Enrollments.Count(e => e.Id == key) > 0;
        }
    }
}
