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
    public class tipo_identificacionController : ApiController
    {
        private oferta_academicaEntities db = new oferta_academicaEntities();

        // GET: api/tipo_identificacion
        public IQueryable<tipo_identificacion> Gettipo_identificacion()
        {
            return db.tipo_identificacion;
        }

        // GET: api/tipo_identificacion/5
        [ResponseType(typeof(tipo_identificacion))]
        public IHttpActionResult Gettipo_identificacion(int id)
        {
            tipo_identificacion tipo_identificacion = db.tipo_identificacion.Find(id);
            if (tipo_identificacion == null)
            {
                return NotFound();
            }

            return Ok(tipo_identificacion);
        }

        // PUT: api/tipo_identificacion/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttipo_identificacion(int id, tipo_identificacion tipo_identificacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipo_identificacion.id)
            {
                return BadRequest();
            }

            db.Entry(tipo_identificacion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tipo_identificacionExists(id))
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

        // POST: api/tipo_identificacion
        [ResponseType(typeof(tipo_identificacion))]
        public IHttpActionResult Posttipo_identificacion(tipo_identificacion tipo_identificacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tipo_identificacion.Add(tipo_identificacion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipo_identificacion.id }, tipo_identificacion);
        }

        // DELETE: api/tipo_identificacion/5
        [ResponseType(typeof(tipo_identificacion))]
        public IHttpActionResult Deletetipo_identificacion(int id)
        {
            tipo_identificacion tipo_identificacion = db.tipo_identificacion.Find(id);
            if (tipo_identificacion == null)
            {
                return NotFound();
            }

            db.tipo_identificacion.Remove(tipo_identificacion);
            db.SaveChanges();

            return Ok(tipo_identificacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tipo_identificacionExists(int id)
        {
            return db.tipo_identificacion.Count(e => e.id == id) > 0;
        }
    }
}