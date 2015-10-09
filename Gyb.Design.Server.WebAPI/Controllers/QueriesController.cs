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
using Gyb.Design.Server.Data;
using Gyb.Design.Server.Entities;

namespace Gyb.Design.Server.WebAPI.Controllers
{
    /*
    在为此控制器添加路由之前，WebApiConfig 类可能要求你做出其他更改。请适当地将这些语句合并到 WebApiConfig 类的 Register 方法中。请注意 OData URL 区分大小写。

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using Gyb.Design.Server.Entities;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Query>("Queries");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class QueriesController : ODataController
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: odata/Queries
        [EnableQuery]
        public IQueryable<Query> GetQueries()
        {
            return db.Queries;
        }

        // GET: odata/Queries(5)
        [EnableQuery]
        public SingleResult<Query> GetQuery([FromODataUri] int key)
        {
            return SingleResult.Create(db.Queries.Where(query => query.Id == key));
        }

        // PUT: odata/Queries(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Query> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Query query = await db.Queries.FindAsync(key);
            if (query == null)
            {
                return NotFound();
            }

            patch.Put(query);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QueryExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(query);
        }

        // POST: odata/Queries
        public async Task<IHttpActionResult> Post(Query query)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Queries.Add(query);
            await db.SaveChangesAsync();

            return Created(query);
        }

        // PATCH: odata/Queries(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Query> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Query query = await db.Queries.FindAsync(key);
            if (query == null)
            {
                return NotFound();
            }

            patch.Patch(query);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QueryExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(query);
        }

        // DELETE: odata/Queries(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Query query = await db.Queries.FindAsync(key);
            if (query == null)
            {
                return NotFound();
            }

            db.Queries.Remove(query);
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

        private bool QueryExists(int key)
        {
            return db.Queries.Count(e => e.Id == key) > 0;
        }
    }
}
