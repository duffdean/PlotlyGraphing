using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using deantest.Models;

namespace deantest.Controllers
{
    public class dummyAPIController : ApiController
    {
        private deanduffEntities db = new deanduffEntities();

        // GET: api/dummyAPI
        public IQueryable<dummy> Getdummies()
        {
            return db.dummies;
        }

        // GET: api/dummyAPI/5
        [ResponseType(typeof(dummy))]
        public IHttpActionResult Getdummy(int id)
        {
            dummy dummy = db.dummies.Find(id);
            if (dummy == null)
            {
                return NotFound();
            }

            return Ok(dummy);
        }

        // PUT: api/dummyAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putdummy(int id, dummy dummy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dummy.testID)
            {
                return BadRequest();
            }

            db.Entry(dummy).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!dummyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/dummyAPI
        [ResponseType(typeof(dummy))]
        public IHttpActionResult Postdummy(dummy dummy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.dummies.Add(dummy);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dummy.testID }, dummy);
        }

        // DELETE: api/dummyAPI/5
        [ResponseType(typeof(dummy))]
        public IHttpActionResult Deletedummy(int id)
        {
            dummy dummy = db.dummies.Find(id);
            if (dummy == null)
            {
                return NotFound();
            }

            db.dummies.Remove(dummy);
            db.SaveChanges();

            return Ok(dummy);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool dummyExists(int id)
        {
            return db.dummies.Count(e => e.testID == id) > 0;
        }
    }
}