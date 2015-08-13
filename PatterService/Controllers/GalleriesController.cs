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
using PatterService.Models;

namespace PatterService.Controllers
{
    public class GalleriesController : ApiController
    {
        private PatterServiceContext db = new PatterServiceContext();

        // GET: api/Galleries
        public IQueryable<Gallery> GetGalleries()
        {
            return db.Galleries;
        }

        // GET: api/Galleries/5
        [ResponseType(typeof(Gallery))]
        public async Task<IHttpActionResult> GetGallery(int id)
        {
            Gallery gallery = await db.Galleries.FindAsync(id);
            if (gallery == null)
            {
                return NotFound();
            }

            return Ok(gallery);
        }

        // PUT: api/Galleries/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGallery(int id, Gallery gallery)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gallery.GalleryNo)
            {
                return BadRequest();
            }

            db.Entry(gallery).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GalleryExists(id))
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

        // POST: api/Galleries
        [ResponseType(typeof(Gallery))]
        public async Task<IHttpActionResult> PostGallery(Gallery gallery)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Galleries.Add(gallery);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = gallery.GalleryNo }, gallery);
        }

        // DELETE: api/Galleries/5
        [ResponseType(typeof(Gallery))]
        public async Task<IHttpActionResult> DeleteGallery(int id)
        {
            Gallery gallery = await db.Galleries.FindAsync(id);
            if (gallery == null)
            {
                return NotFound();
            }

            db.Galleries.Remove(gallery);
            await db.SaveChangesAsync();

            return Ok(gallery);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GalleryExists(int id)
        {
            return db.Galleries.Count(e => e.GalleryNo == id) > 0;
        }
    }
}