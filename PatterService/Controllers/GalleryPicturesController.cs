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
    public class GalleryPicturesController : ApiController
    {
        private PatterServiceContext db = new PatterServiceContext();

        // GET: api/GalleryPictures
        public IQueryable<GalleryPicture> GetGalleryPictures()
        {
            return db.GalleryPictures;
        }

        // GET: api/GalleryPictures/5
        [ResponseType(typeof(GalleryPicture))]
        public async Task<IHttpActionResult> GetGalleryPicture(int id)
        {
            GalleryPicture galleryPicture = await db.GalleryPictures.FindAsync(id);
            if (galleryPicture == null)
            {
                return NotFound();
            }

            return Ok(galleryPicture);
        }

        // PUT: api/GalleryPictures/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGalleryPicture(int id, GalleryPicture galleryPicture)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != galleryPicture.GalleryNo)
            {
                return BadRequest();
            }

            db.Entry(galleryPicture).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GalleryPictureExists(id))
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

        // POST: api/GalleryPictures
        [ResponseType(typeof(GalleryPicture))]
        public async Task<IHttpActionResult> PostGalleryPicture(GalleryPicture galleryPicture)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GalleryPictures.Add(galleryPicture);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = galleryPicture.GalleryNo }, galleryPicture);
        }

        // DELETE: api/GalleryPictures/5
        [ResponseType(typeof(GalleryPicture))]
        public async Task<IHttpActionResult> DeleteGalleryPicture(int id)
        {
            GalleryPicture galleryPicture = await db.GalleryPictures.FindAsync(id);
            if (galleryPicture == null)
            {
                return NotFound();
            }

            db.GalleryPictures.Remove(galleryPicture);
            await db.SaveChangesAsync();

            return Ok(galleryPicture);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GalleryPictureExists(int id)
        {
            return db.GalleryPictures.Count(e => e.GalleryNo == id) > 0;
        }
    }
}