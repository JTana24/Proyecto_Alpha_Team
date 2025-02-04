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
    public class institucionesController : ApiController
    {
        private oferta_academicaEntities db = new oferta_academicaEntities();

        // GET: api/instituciones
        public IQueryable<institucion> Getinstitucion()
        {
            return db.institucion;
        }

        // GET: api/instituciones/5
        [ResponseType(typeof(institucion))]
        public IHttpActionResult Getinstitucion(int id)
        {
            institucion institucion = db.institucion.Find(id);
            if (institucion == null)
            {
                return NotFound();
            }

            return Ok(institucion);
        }

        // PUT: api/instituciones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putinstitucion(int id, institucion institucion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != institucion.id)
            {
                return BadRequest();
            }

            db.Entry(institucion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!institucionExists(id))
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

        // POST: api/instituciones
        [ResponseType(typeof(institucion))]
        public IHttpActionResult Postinstitucion(institucion institucion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.institucion.Add(institucion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = institucion.id }, institucion);
        }

        // DELETE: api/instituciones/5
        [ResponseType(typeof(institucion))]
        public IHttpActionResult Deleteinstitucion(int id)
        {
            institucion institucion = db.institucion.Find(id);
            if (institucion == null)
            {
                return NotFound();
            }

            db.institucion.Remove(institucion);
            db.SaveChanges();

            return Ok(institucion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool institucionExists(int id)
        {
            return db.institucion.Count(e => e.id == id) > 0;
        }
    }
}