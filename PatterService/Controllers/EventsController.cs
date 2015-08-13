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
using System.Web;
using System.Diagnostics;
using System.Web.Hosting;
using System.IO;
using PatterService.Common;
using System.Web.Http.Results;

namespace PatterService.Controllers
{
    public class EventsController : ApiController
    {
        private PatterServiceContext db = new PatterServiceContext();
        private int PageSize = 10;

        // GET: api/Events
        //public IQueryable<Event> GetEvents()
        //{
        //    return db.Events;
        //}

        // GET: api/Events?page
        public async Task<IQueryable<Event>> GetEvents(int page = 1)
        {
            var events = await db.Events.OrderBy(p => p.EventNo)
                .Skip((page - 1) * PageSize)
                .Take(PageSize).ToListAsync();

            return events.AsQueryable();
        }

        // GET: api/Events/5
        //[ResponseType(typeof(Event))]
        //public async Task<IHttpActionResult> GetEvent(int id)
        //{
        //    Event @event = await db.Events.FindAsync(id);
        //    if (@event == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(@event);
        //}

        // GET: api/Events/5
        //[ResponseType(typeof(Event))]
        //public IList<EventDetailsDto> GetEvent(int id)
        //{
        //    var EvnetDatails = db.Events.Where(p => p.EventNo == id).Select(p => new EventDetailsDto
        //    {
        //        EventNo = p.EventNo,
        //        WriteId = p.WriteId,
        //        Title = p.Title,
        //        Content = p.Content,
        //        EventPictures = p.EventPictures.ToList()
        //    }).ToList();

        //    return EvnetDatails;
        //}

        [ResponseType(typeof(EventDetailsDTO))]
        public async Task<IHttpActionResult> GetEvent(int id)
        {
            var EvnetDatails = await db.Events.Where(p => p.EventNo == id).Select(p => new EventDTO
            {
                EventNo = p.EventNo,
                WriteId = p.WriteId,
                Title = p.Title,
                Content = p.Content,
                EventPictures = p.EventPictures.ToList()
            }).SingleOrDefaultAsync();


            return Ok(EvnetDatails);
        }

        // PUT: api/Events/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEvent(int id, Event @event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @event.EventNo)
            {
                return BadRequest();
            }

            db.Entry(@event).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
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

        // POST: api/Events
        //[ResponseType(typeof(Event))]
        //public async Task<IHttpActionResult> PostEvent(Event @event)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Events.Add(@event);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = @event.EventNo }, @event);
        //}

        //[ResponseType(typeof(Event))]
        //[HttpPost]
        //public async Task<HttpResponseMessage> PostEvent()
        //{
        //    // Check if the request contains multipart/form-data.
        //    if (!Request.Content.IsMimeMultipartContent())
        //    {
        //        throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
        //    }

        //    string root = HttpContext.Current.Server.MapPath("~/App_Data");
        //    var provider = new MultipartFormDataStreamProvider(root);

        //    try
        //    {
        //        // Read the form data.
        //        await Request.Content.ReadAsMultipartAsync(provider);

        //        // This illustrates how to get the file names.
        //        foreach (MultipartFileData file in provider.FileData)
        //        {
        //            Trace.WriteLine(file.Headers.ContentDisposition.FileName);
        //            Trace.WriteLine("Server file path: " + file.LocalFileName);
        //        }
        //        return Request.CreateResponse(HttpStatusCode.OK);
        //    }
        //    catch (System.Exception e)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
        //    }
        //}


        //POST: api/Events
        //[HttpPost]
        [ResponseType(typeof(PatterResultType))]
        public async Task<IHttpActionResult> PostEvent()
        {
            
            EventDetailsDTO @eventDetail = new EventDetailsDTO();
            Event @event = new Event();
            List<EventPicture> @eventPictureList = new List<EventPicture>();
            EventPicture @eventPicture = new EventPicture();
            PatterResultType @patterResultType = new PatterResultType();

            if (!Request.Content.IsMimeMultipartContent())
            {
                //throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            var folder = HostingEnvironment.MapPath(UploadPath.PATH);

            Utilities.CreateDirectory(folder);

            var provider = new CustomMultipartFormDataStreamProvider(folder);

            try
            {
                await Request.Content.ReadAsMultipartAsync(provider);

                // Show all the key-value pairs.
                foreach (var key in provider.FormData)
                {
                    foreach (var val in provider.FormData.GetValues(key.ToString()))
                    {
                        switch (key.ToString())
                        {
                            case "EventNo":
                                @event.EventNo = int.Parse(val);
                                break;
                            case "WriteId":
                                @event.WriteId = val;
                                break;
                            case "Title":
                                @event.Title = val;
                                break;
                            case "Content":
                                @event.Content = val;
                                break;
                            default:
                                break;
                        }
                    }
                }

                db.Events.Add(@event);
                await db.SaveChangesAsync();

                foreach (MultipartFileData file in provider.FileData)
                {
                    //Trace.WriteLine("Server file name: " + file.Headers.ContentDisposition.FileName);
                    //Trace.WriteLine("Server file path: " + file.LocalFileName);
                    @eventPicture.EventNo = @event.EventNo;
                    @eventPicture.PictureName = file.Headers.ContentDisposition.FileName;
                    @eventPicture.PicturePath = file.LocalFileName;
                    db.EventPictures.Add(@eventPicture);
                    await db.SaveChangesAsync();

                    //@eventDetail.EventPictures.Add(@eventPicture);
                }

                @eventDetail.EventNo = @event.EventNo;
                @eventDetail.WriteId = @event.WriteId;
                @eventDetail.Title = @event.Title;
                @eventDetail.Content = @event.Content;
                //var picture = db.EventPictures.FindAsync(@event.EventNo);
                //@eventDetail.EventPictures = picture.
                //@eventDetail.EventPictures = 
                //foreach (var item in @eventPicture)
                //{
                //    @eventDTO.EventPictures.Add(item);
                //}
                //@event.EventPictures = @eventPictureList;


                //return Request.CreateResponse(HttpStatusCode.OK, @event.ToString());
                //var result = new List<ListItems>();

                @patterResultType.JsonDataSet = @eventDetail.ToString();
                @patterResultType.IsSuccessful = true;

                //return new JsonResult{ Data = result};
                return Ok(@patterResultType);
            }
            catch (System.Exception e)
            {
                //return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
                return InternalServerError(e);
            }
        }

        // DELETE: api/Events/5
        [ResponseType(typeof(Event))]
        public async Task<IHttpActionResult> DeleteEvent(int id)
        {
            Event @event = await db.Events.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }

            db.Events.Remove(@event);
            await db.SaveChangesAsync();

            return Ok(@event);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventExists(int id)
        {
            return db.Events.Count(e => e.EventNo == id) > 0;
        }
    }
}