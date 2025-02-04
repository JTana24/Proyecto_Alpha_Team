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
    public class profesor_telefonoController : ApiController
    {
        private oferta_academicaEntities db = new oferta_academicaEntities();

        // GET: api/profesor_telefono
        public IQueryable<profesor_telefono> Getprofesor_telefono()
        {
            return db.profesor_telefono;
        }

        // GET: api/profesor_telefono/5
        [ResponseType(typeof(profesor_telefono))]
        public IHttpActionResult Getprofesor_telefono(int id)
        {
            profesor_telefono profesor_telefono = db.profesor_telefono.Find(id);
            if (profesor_telefono == null)
            {
                return NotFound();
            }

            return Ok(profesor_telefono);
        }

        // PUT: api/profesor_telefono/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putprofesor_telefono(int id, profesor_telefono profesor_telefono)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != profesor_telefono.id)
            {
                return BadRequest();
            }

            db.Entry(profesor_telefono).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!profesor_telefonoExists(id))
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

        // POST: api/profesor_telefono
        [ResponseType(typeof(profesor_telefono))]
        public IHttpActionResult Postprofesor_telefono(profesor_telefono profesor_telefono)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.profesor_telefono.Add(profesor_telefono);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = profesor_telefono.id }, profesor_telefono);
        }

        // DELETE: api/profesor_telefono/5
        [ResponseType(typeof(profesor_telefono))]
        public IHttpActionResult Deleteprofesor_telefono(int id)
        {
            profesor_telefono profesor_telefono = db.profesor_telefono.Find(id);
            if (profesor_telefono == null)
            {
                return NotFound();
            }

            db.profesor_telefono.Remove(profesor_telefono);
            db.SaveChanges();

            return Ok(profesor_telefono);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool profesor_telefonoExists(int id)
        {
            return db.profesor_telefono.Count(e => e.id == id) > 0;
        }
    }
}