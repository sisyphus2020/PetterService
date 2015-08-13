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
    public class ReviewPicturesController : ApiController
    {
        private PatterServiceContext db = new PatterServiceContext();

        // GET: api/ReviewPictures
        public IQueryable<ReviewPicture> GetReviewPictures()
        {
            return db.ReviewPictures;
        }

        // GET: api/ReviewPictures/5
        [ResponseType(typeof(ReviewPicture))]
        public async Task<IHttpActionResult> GetReviewPicture(int id)
        {
            ReviewPicture reviewPicture = await db.ReviewPictures.FindAsync(id);
            if (reviewPicture == null)
            {
                return NotFound();
            }

            return Ok(reviewPicture);
        }

        // PUT: api/ReviewPictures/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutReviewPicture(int id, ReviewPicture reviewPicture)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reviewPicture.ReviewNo)
            {
                return BadRequest();
            }

            db.Entry(reviewPicture).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewPictureExists(id))
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

        // POST: api/ReviewPictures
        [ResponseType(typeof(ReviewPicture))]
        public async Task<IHttpActionResult> PostReviewPicture(ReviewPicture reviewPicture)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ReviewPictures.Add(reviewPicture);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ReviewPictureExists(reviewPicture.ReviewNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = reviewPicture.ReviewNo }, reviewPicture);
        }

        // DELETE: api/ReviewPictures/5
        [ResponseType(typeof(ReviewPicture))]
        public async Task<IHttpActionResult> DeleteReviewPicture(int id)
        {
            ReviewPicture reviewPicture = await db.ReviewPictures.FindAsync(id);
            if (reviewPicture == null)
            {
                return NotFound();
            }

            db.ReviewPictures.Remove(reviewPicture);
            await db.SaveChangesAsync();

            return Ok(reviewPicture);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReviewPictureExists(int id)
        {
            return db.ReviewPictures.Count(e => e.ReviewNo == id) > 0;
        }
    }
}