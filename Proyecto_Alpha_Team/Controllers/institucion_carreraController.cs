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
    public class institucion_carreraController : ApiController
    {
        private oferta_academicaEntities db = new oferta_academicaEntities();

        // GET: api/institucion_carrera
        public IQueryable<institucion_carrera> Getinstitucion_carrera()
        {
            return db.institucion_carrera;
        }

        // GET: api/institucion_carrera/5
        [ResponseType(typeof(institucion_carrera))]
        public IHttpActionResult Getinstitucion_carrera(int id)
        {
            institucion_carrera institucion_carrera = db.institucion_carrera.Find(id);
            if (institucion_carrera == null)
            {
                return NotFound();
            }

            return Ok(institucion_carrera);
        }

        // PUT: api/institucion_carrera/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putinstitucion_carrera(int id, institucion_carrera institucion_carrera)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != institucion_carrera.id)
            {
                return BadRequest();
            }

            db.Entry(institucion_carrera).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!institucion_carreraExists(id))
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

        // POST: api/institucion_carrera
        [ResponseType(typeof(institucion_carrera))]
        public IHttpActionResult Postinstitucion_carrera(institucion_carrera institucion_carrera)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.institucion_carrera.Add(institucion_carrera);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = institucion_carrera.id }, institucion_carrera);
        }

        // DELETE: api/institucion_carrera/5
        [ResponseType(typeof(institucion_carrera))]
        public IHttpActionResult Deleteinstitucion_carrera(int id)
        {
            institucion_carrera institucion_carrera = db.institucion_carrera.Find(id);
            if (institucion_carrera == null)
            {
                return NotFound();
            }

            db.institucion_carrera.Remove(institucion_carrera);
            db.SaveChanges();

            return Ok(institucion_carrera);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool institucion_carreraExists(int id)
        {
            return db.institucion_carrera.Count(e => e.id == id) > 0;
        }
    }
}