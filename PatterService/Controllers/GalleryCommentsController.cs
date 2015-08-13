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
    public class GalleryCommentsController : ApiController
    {
        private PatterServiceContext db = new PatterServiceContext();

        // GET: api/GalleryComments
        public IQueryable<GalleryComment> GetGalleryComments()
        {
            return db.GalleryComments;
        }

        // GET: api/GalleryComments/5
        [ResponseType(typeof(GalleryComment))]
        public async Task<IHttpActionResult> GetGalleryComment(int id)
        {
            GalleryComment galleryComment = await db.GalleryComments.FindAsync(id);
            if (galleryComment == null)
            {
                return NotFound();
            }

            return Ok(galleryComment);
        }

        // PUT: api/GalleryComments/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGalleryComment(int id, GalleryComment galleryComment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != galleryComment.GalleryCommentNo)
            {
                return BadRequest();
            }

            db.Entry(galleryComment).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GalleryCommentExists(id))
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

        // POST: api/GalleryComments
        [ResponseType(typeof(GalleryComment))]
        public async Task<IHttpActionResult> PostGalleryComment(GalleryComment galleryComment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GalleryComments.Add(galleryComment);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = galleryComment.GalleryCommentNo }, galleryComment);
        }

        // DELETE: api/GalleryComments/5
        [ResponseType(typeof(GalleryComment))]
        public async Task<IHttpActionResult> DeleteGalleryComment(int id)
        {
            GalleryComment galleryComment = await db.GalleryComments.FindAsync(id);
            if (galleryComment == null)
            {
                return NotFound();
            }

            db.GalleryComments.Remove(galleryComment);
            await db.SaveChangesAsync();

            return Ok(galleryComment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GalleryCommentExists(int id)
        {
            return db.GalleryComments.Count(e => e.GalleryCommentNo == id) > 0;
        }
    }
}