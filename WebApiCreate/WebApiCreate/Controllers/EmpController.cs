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
using System.Web.Http.Description;
using WebApiCreate.EDM;

namespace WebApiCreate.Controllers
{
    public class EmpController : ApiController
    {
        private CompanyEntities db = new CompanyEntities();

        public EmpController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET: api/Emp
        public IQueryable<tblemployee> Gettblemployees()
        {
            return db.tblemployees;
        }

        // GET: api/Emp/5
        [ResponseType(typeof(tblemployee))]
        public async Task<IHttpActionResult> Gettblemployee(int id)
        {
            tblemployee tblemployee = await db.tblemployees.FindAsync(id);
            if (tblemployee == null)
            {
                return NotFound();
            }

            return Ok(tblemployee);
        }

        // PUT: api/Emp/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Puttblemployee(int id, tblemployee tblemployee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblemployee.emp_id)
            {
                return BadRequest();
            }

            db.Entry(tblemployee).State = EntityState.Modified;
            await db.SaveChangesAsync();

            //return StatusCode(HttpStatusCode.NoContent);
            return Ok("Update Success");
        }

        // POST: api/Emp
        [ResponseType(typeof(tblemployee))]
        public async Task<IHttpActionResult> Posttblemployee(tblemployee tblemployee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblemployees.Add(tblemployee);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tblemployee.emp_id }, tblemployee);
        }

        // DELETE: api/Emp/5
        [ResponseType(typeof(tblemployee))]
        public async Task<IHttpActionResult> Deletetblemployee(int id)
        {
            tblemployee tblemployee = await db.tblemployees.FindAsync(id);
            if (tblemployee == null)
            {
                return NotFound();
            }

            db.tblemployees.Remove(tblemployee);
            await db.SaveChangesAsync();

            return Ok(tblemployee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblemployeeExists(int id)
        {
            return db.tblemployees.Count(e => e.emp_id == id) > 0;
        }
    }
}