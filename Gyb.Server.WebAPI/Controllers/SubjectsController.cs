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
    builder.EntitySet<Subject>("Subjects");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class SubjectsController : ODataController
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: odata/Subjects
        [EnableQuery]
        public IQueryable<Subject> GetSubjects()
        {
            return db.Subjects;
        }

        // GET: odata/Subjects(5)
        [EnableQuery]
        public SingleResult<Subject> GetSubject([FromODataUri] int key)
        {
            return SingleResult.Create(db.Subjects.Where(subject => subject.Id == key));
        }

        // PUT: odata/Subjects(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Subject> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Subject subject = await db.Subjects.FindAsync(key);
            if (subject == null)
            {
                return NotFound();
            }

            patch.Put(subject);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(subject);
        }

        // POST: odata/Subjects
        public async Task<IHttpActionResult> Post(Subject subject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Subjects.Add(subject);
            await db.SaveChangesAsync();

            return Created(subject);
        }

        // PATCH: odata/Subjects(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Subject> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Subject subject = await db.Subjects.FindAsync(key);
            if (subject == null)
            {
                return NotFound();
            }

            patch.Patch(subject);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(subject);
        }

        // DELETE: odata/Subjects(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Subject subject = await db.Subjects.FindAsync(key);
            if (subject == null)
            {
                return NotFound();
            }

            db.Subjects.Remove(subject);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubjectExists(int key)
        {
            return db.Subjects.Count(e => e.Id == key) > 0;
        }
    }
}
