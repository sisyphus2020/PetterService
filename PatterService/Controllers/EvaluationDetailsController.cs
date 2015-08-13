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
    public class EvaluationDetailsController : ApiController
    {
        private PatterServiceContext db = new PatterServiceContext();

        // GET: api/EvaluationDetails
        public IQueryable<EvaluationDetail> GetEvaluationDetails()
        {
            return db.EvaluationDetails;
        }

        // GET: api/EvaluationDetails/5
        [ResponseType(typeof(EvaluationDetail))]
        public async Task<IHttpActionResult> GetEvaluationDetail(int id)
        {
            EvaluationDetail evaluationDetail = await db.EvaluationDetails.FindAsync(id);
            if (evaluationDetail == null)
            {
                return NotFound();
            }

            return Ok(evaluationDetail);
        }

        // PUT: api/EvaluationDetails/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEvaluationDetail(int id, EvaluationDetail evaluationDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != evaluationDetail.EvaluationDetailNo)
            {
                return BadRequest();
            }

            db.Entry(evaluationDetail).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EvaluationDetailExists(id))
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

        // POST: api/EvaluationDetails
        [ResponseType(typeof(EvaluationDetail))]
        public async Task<IHttpActionResult> PostEvaluationDetail(EvaluationDetail evaluationDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EvaluationDetails.Add(evaluationDetail);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = evaluationDetail.EvaluationDetailNo }, evaluationDetail);
        }

        // DELETE: api/EvaluationDetails/5
        [ResponseType(typeof(EvaluationDetail))]
        public async Task<IHttpActionResult> DeleteEvaluationDetail(int id)
        {
            EvaluationDetail evaluationDetail = await db.EvaluationDetails.FindAsync(id);
            if (evaluationDetail == null)
            {
                return NotFound();
            }

            db.EvaluationDetails.Remove(evaluationDetail);
            await db.SaveChangesAsync();

            return Ok(evaluationDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EvaluationDetailExists(int id)
        {
            return db.EvaluationDetails.Count(e => e.EvaluationDetailNo == id) > 0;
        }
    }
}