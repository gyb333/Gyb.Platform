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
    builder.EntitySet<Tutor>("Tutors");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class TutorsController : ODataController
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: odata/Tutors
        [EnableQuery]
        public IQueryable<Tutor> GetTutors()
        {
            return db.Tutors;
        }

        // GET: odata/Tutors(5)
        [EnableQuery]
        public SingleResult<Tutor> GetTutor([FromODataUri] int key)
        {
            return SingleResult.Create(db.Tutors.Where(tutor => tutor.Id == key));
        }

        // PUT: odata/Tutors(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Tutor> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Tutor tutor = await db.Tutors.FindAsync(key);
            if (tutor == null)
            {
                return NotFound();
            }

            patch.Put(tutor);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TutorExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(tutor);
        }

        // POST: odata/Tutors
        public async Task<IHttpActionResult> Post(Tutor tutor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tutors.Add(tutor);
            await db.SaveChangesAsync();

            return Created(tutor);
        }

        // PATCH: odata/Tutors(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Tutor> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Tutor tutor = await db.Tutors.FindAsync(key);
            if (tutor == null)
            {
                return NotFound();
            }

            patch.Patch(tutor);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TutorExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(tutor);
        }

        // DELETE: odata/Tutors(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Tutor tutor = await db.Tutors.FindAsync(key);
            if (tutor == null)
            {
                return NotFound();
            }

            db.Tutors.Remove(tutor);
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

        private bool TutorExists(int key)
        {
            return db.Tutors.Count(e => e.Id == key) > 0;
        }
    }
}
