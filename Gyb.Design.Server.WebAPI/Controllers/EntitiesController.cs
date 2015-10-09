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
    builder.EntitySet<Entity>("Entities");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class EntitiesController : ODataController
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: odata/Entities
        [EnableQuery]
        public IQueryable<Entity> GetEntities()
        {
            return db.Entities;
        }

        // GET: odata/Entities(5)
        [EnableQuery]
        public SingleResult<Entity> GetEntity([FromODataUri] int key)
        {
            return SingleResult.Create(db.Entities.Where(entity => entity.Id == key));
        }

        // PUT: odata/Entities(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Entity> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Entity entity = await db.Entities.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            patch.Put(entity);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(entity);
        }

        // POST: odata/Entities
        public async Task<IHttpActionResult> Post(Entity entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entities.Add(entity);
            await db.SaveChangesAsync();

            return Created(entity);
        }

        // PATCH: odata/Entities(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Entity> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Entity entity = await db.Entities.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            patch.Patch(entity);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(entity);
        }

        // DELETE: odata/Entities(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Entity entity = await db.Entities.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            db.Entities.Remove(entity);
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

        private bool EntityExists(int key)
        {
            return db.Entities.Count(e => e.Id == key) > 0;
        }
    }
}
