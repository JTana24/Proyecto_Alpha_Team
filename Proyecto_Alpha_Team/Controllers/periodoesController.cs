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
using Proyecto_Alpha_Team.Models;

namespace Proyecto_Alpha_Team.Controllers
{
    public class periodoesController : ApiController
    {
        private oferta_academicaEntities db = new oferta_academicaEntities();

        // GET: api/periodoes
        public IQueryable<periodo> Getperiodo()
        {
            return db.periodo;
        }

        // GET: api/periodoes/5
        [ResponseType(typeof(periodo))]
        public IHttpActionResult Getperiodo(int id)
        {
            periodo periodo = db.periodo.Find(id);
            if (periodo == null)
            {
                return NotFound();
            }

            return Ok(periodo);
        }

        // PUT: api/periodoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putperiodo(int id, periodo periodo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != periodo.id)
            {
                return BadRequest();
            }

            db.Entry(periodo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!periodoExists(id))
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

        // POST: api/periodoes
        [ResponseType(typeof(periodo))]
        public IHttpActionResult Postperiodo(periodo periodo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.periodo.Add(periodo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = periodo.id }, periodo);
        }

        // DELETE: api/periodoes/5
        [ResponseType(typeof(periodo))]
        public IHttpActionResult Deleteperiodo(int id)
        {
            periodo periodo = db.periodo.Find(id);
            if (periodo == null)
            {
                return NotFound();
            }

            db.periodo.Remove(periodo);
            db.SaveChanges();

            return Ok(periodo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool periodoExists(int id)
        {
            return db.periodo.Count(e => e.id == id) > 0;
        }
    }
}