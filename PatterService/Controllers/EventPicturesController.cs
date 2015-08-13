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
    public class EventPicturesController : ApiController
    {
        private PatterServiceContext db = new PatterServiceContext();

        // GET: api/EventPictures
        public IQueryable<EventPicture> GetEventPictures()
        {
            return db.EventPictures;
        }

        // GET: api/EventPictures/5
        [ResponseType(typeof(EventPicture))]
        public async Task<IHttpActionResult> GetEventPicture(int id)
        {
            EventPicture eventPicture = await db.EventPictures.FindAsync(id);
            if (eventPicture == null)
            {
                return NotFound();
            }

            return Ok(eventPicture);
        }

        // PUT: api/EventPictures/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEventPicture(int id, EventPicture eventPicture)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventPicture.EventPicutreNo)
            {
                return BadRequest();
            }

            db.Entry(eventPicture).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventPictureExists(id))
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

        // POST: api/EventPictures
        [ResponseType(typeof(EventPicture))]
        public async Task<IHttpActionResult> PostEventPicture(EventPicture eventPicture)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EventPictures.Add(eventPicture);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = eventPicture.EventPicutreNo }, eventPicture);
        }

        // DELETE: api/EventPictures/5
        [ResponseType(typeof(EventPicture))]
        public async Task<IHttpActionResult> DeleteEventPicture(int id)
        {
            EventPicture eventPicture = await db.EventPictures.FindAsync(id);
            if (eventPicture == null)
            {
                return NotFound();
            }

            db.EventPictures.Remove(eventPicture);
            await db.SaveChangesAsync();

            return Ok(eventPicture);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventPictureExists(int id)
        {
            return db.EventPictures.Count(e => e.EventPicutreNo == id) > 0;
        }
    }
}