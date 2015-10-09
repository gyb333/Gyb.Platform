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
    builder.EntitySet<Screen>("Screens");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ScreensController : ODataController
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: odata/Screens
        [EnableQuery]
        public IQueryable<Screen> GetScreens()
        {
            return db.Screens;
        }

        // GET: odata/Screens(5)
        [EnableQuery]
        public SingleResult<Screen> GetScreen([FromODataUri] int key)
        {
            return SingleResult.Create(db.Screens.Where(screen => screen.Id == key));
        }

        // PUT: odata/Screens(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Screen> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Screen screen = await db.Screens.FindAsync(key);
            if (screen == null)
            {
                return NotFound();
            }

            patch.Put(screen);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScreenExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(screen);
        }

        // POST: odata/Screens
        public async Task<IHttpActionResult> Post(Screen screen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Screens.Add(screen);
            await db.SaveChangesAsync();

            return Created(screen);
        }

        // PATCH: odata/Screens(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Screen> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Screen screen = await db.Screens.FindAsync(key);
            if (screen == null)
            {
                return NotFound();
            }

            patch.Patch(screen);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScreenExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(screen);
        }

        // DELETE: odata/Screens(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Screen screen = await db.Screens.FindAsync(key);
            if (screen == null)
            {
                return NotFound();
            }

            db.Screens.Remove(screen);
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

        private bool ScreenExists(int key)
        {
            return db.Screens.Count(e => e.Id == key) > 0;
        }
    }
}
