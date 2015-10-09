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
    builder.EntitySet<Workflow>("Workflows");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class WorkflowsController : ODataController
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: odata/Workflows
        [EnableQuery]
        public IQueryable<Workflow> GetWorkflows()
        {
            return db.Workflows;
        }

        // GET: odata/Workflows(5)
        [EnableQuery]
        public SingleResult<Workflow> GetWorkflow([FromODataUri] int key)
        {
            return SingleResult.Create(db.Workflows.Where(workflow => workflow.Id == key));
        }

        // PUT: odata/Workflows(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Workflow> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Workflow workflow = await db.Workflows.FindAsync(key);
            if (workflow == null)
            {
                return NotFound();
            }

            patch.Put(workflow);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkflowExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(workflow);
        }

        // POST: odata/Workflows
        public async Task<IHttpActionResult> Post(Workflow workflow)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Workflows.Add(workflow);
            await db.SaveChangesAsync();

            return Created(workflow);
        }

        // PATCH: odata/Workflows(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Workflow> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Workflow workflow = await db.Workflows.FindAsync(key);
            if (workflow == null)
            {
                return NotFound();
            }

            patch.Patch(workflow);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkflowExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(workflow);
        }

        // DELETE: odata/Workflows(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Workflow workflow = await db.Workflows.FindAsync(key);
            if (workflow == null)
            {
                return NotFound();
            }

            db.Workflows.Remove(workflow);
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

        private bool WorkflowExists(int key)
        {
            return db.Workflows.Count(e => e.Id == key) > 0;
        }
    }
}
