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
    public class carrerasController : ApiController
    {
        private oferta_academicaEntities db = new oferta_academicaEntities();

        // GET: api/carreras
        public IQueryable<carrera> Getcarrera()
        {
            return db.carrera;
        }

        // GET: api/carreras/5
        [ResponseType(typeof(carrera))]
        public IHttpActionResult Getcarrera(int id)
        {
            carrera carrera = db.carrera.Find(id);
            if (carrera == null)
            {
                return NotFound();
            }

            return Ok(carrera);
        }

        // PUT: api/carreras/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcarrera(int id, carrera carrera)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != carrera.id)
            {
                return BadRequest();
            }

            db.Entry(carrera).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!carreraExists(id))
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

        // POST: api/carreras
        [ResponseType(typeof(carrera))]
        public IHttpActionResult Postcarrera(carrera carrera)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.carrera.Add(carrera);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = carrera.id }, carrera);
        }

        // DELETE: api/carreras/5
        [ResponseType(typeof(carrera))]
        public IHttpActionResult Deletecarrera(int id)
        {
            carrera carrera = db.carrera.Find(id);
            if (carrera == null)
            {
                return NotFound();
            }

            db.carrera.Remove(carrera);
            db.SaveChanges();

            return Ok(carrera);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool carreraExists(int id)
        {
            return db.carrera.Count(e => e.id == id) > 0;
        }
    }
}