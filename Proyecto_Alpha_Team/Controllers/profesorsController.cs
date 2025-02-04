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
    public class profesorsController : ApiController
    {
        private oferta_academicaEntities db = new oferta_academicaEntities();

        // GET: api/profesors
        public IQueryable<profesor> Getprofesor()
        {
            return db.profesor;
        }

        // GET: api/profesors/5
        [ResponseType(typeof(profesor))]
        public IHttpActionResult Getprofesor(int id)
        {
            profesor profesor = db.profesor.Find(id);
            if (profesor == null)
            {
                return NotFound();
            }

            return Ok(profesor);
        }

        // PUT: api/profesors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putprofesor(int id, profesor profesor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != profesor.id)
            {
                return BadRequest();
            }

            db.Entry(profesor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!profesorExists(id))
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

        // POST: api/profesors
        [ResponseType(typeof(profesor))]
        public IHttpActionResult Postprofesor(profesor profesor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.profesor.Add(profesor);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = profesor.id }, profesor);
        }

        // DELETE: api/profesors/5
        [ResponseType(typeof(profesor))]
        public IHttpActionResult Deleteprofesor(int id)
        {
            profesor profesor = db.profesor.Find(id);
            if (profesor == null)
            {
                return NotFound();
            }

            db.profesor.Remove(profesor);
            db.SaveChanges();

            return Ok(profesor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool profesorExists(int id)
        {
            return db.profesor.Count(e => e.id == id) > 0;
        }
    }
}