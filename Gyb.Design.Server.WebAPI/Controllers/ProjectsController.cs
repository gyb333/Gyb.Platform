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
    builder.EntitySet<Project>("Projects");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ProjectsController : ODataController
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: odata/Projects
        [EnableQuery]
        public IQueryable<Project> GetProjects()
        {
            return db.Projects;
        }

        // GET: odata/Projects(5)
        [EnableQuery]
        public SingleResult<Project> GetProject([FromODataUri] int key)
        {
            return SingleResult.Create(db.Projects.Where(project => project.Id == key));
        }

        // PUT: odata/Projects(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Project> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Project project = await db.Projects.FindAsync(key);
            if (project == null)
            {
                return NotFound();
            }

            patch.Put(project);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(project);
        }

        // POST: odata/Projects
        public async Task<IHttpActionResult> Post(Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Projects.Add(project);
            await db.SaveChangesAsync();

            return Created(project);
        }

        // PATCH: odata/Projects(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Project> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Project project = await db.Projects.FindAsync(key);
            if (project == null)
            {
                return NotFound();
            }

            patch.Patch(project);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(project);
        }

        // DELETE: odata/Projects(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Project project = await db.Projects.FindAsync(key);
            if (project == null)
            {
                return NotFound();
            }

            db.Projects.Remove(project);
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

        private bool ProjectExists(int key)
        {
            return db.Projects.Count(e => e.Id == key) > 0;
        }
    }
}
