using BusinessLayer.Models;
using BusinessLayer.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace DreamVacations_CampBookingSite.Controllers
{
    [RoutePrefix("Api/Camps")]
    public class CampsController : ApiController
    {
        /// <summary>
        /// Controller to Handle Camps Related Requests
        /// </summary>

        private readonly CampServices campServices;
        private readonly BookingServices bookingServices;
        public CampsController()
        {
            campServices = new CampServices();
            bookingServices = new BookingServices();
        }

        /// <summary>
        /// GetAllCamps from DB
        /// </summary>
        /// <returns>Required JSON object </returns>
        [HttpGet]
        [Route("GetAllCamps")]
        public IEnumerable<CampsDTO> GetCamps()
        {
            try
            {
                return campServices.GetAllCamps();
            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="checkIn"></param>
        /// <param name="checkOut"></param>
        /// <param name="capacity"></param>
        /// <returns></returns>

        [HttpGet]
        [Route("GetCampsBetween/{checkIn}/{checkOut}/{capacity}")]
        public IEnumerable<CampsDTO> GetCampsBetween(DateTime checkIn, DateTime checkOut, int capacity)
        {
            IEnumerable<CampsDTO> result;
            try
            {
                result = campServices.GetCampsBetween(checkIn, checkOut, capacity);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }


        /// <summary>
        /// Get Details of Desired Camp
        /// </summary>
        /// <param name="CampId"></param>
        /// <returns>JSON Object of Required data</returns>
        [HttpGet]
        [Route("GetCamp/{CampId}")]
        public IHttpActionResult GetCamp(Guid CampId)
        {
            var camp = campServices.GetCamp(CampId);
            if (camp == null)
            {
                return NotFound();
            }

            return Ok(camp);
        }

        /// <summary>
        /// Update Camp Details
        /// </summary>
        /// <param name="camp">new details</param>
        /// <returns>return Updated JSON object </returns>
        [HttpPut]
        [Authorize]
        [Route("UpdateCamp")]
        public IHttpActionResult UpdateCamp(CampsDTO camp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = campServices.UpdateCamp(camp);

            if (!result)
            {
                return NotFound();
            }
            return Ok(camp);

        }
        /// <summary>
        /// Add a New Camp
        /// </summary>
        /// <param name="camp"></param>
        /// <returns></returns>

        [HttpPost]
        [Route("Addcamp")]
        [Authorize]
        public IHttpActionResult AddCamp(CampsDTO camp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (campServices.AddCamp(camp))
            { return Ok(); }
            else
            {
                return StatusCode(HttpStatusCode.NotModified);
            }
                
            

            //     return CreatedAtRoute("DefaultApi", new { id = camps.Id }, camps);
        }

       /// <summary>
       /// Delete an Existing Camp
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        [HttpDelete]
        [Authorize]
        [Route("DeleteCamp/{id}")]
        public IHttpActionResult DeleteCamp(Guid id)
        {
            var result = campServices.DeleteCamp(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok(result);
        }
        /// <summary>
        /// Rate a camp
        /// </summary>
        /// <param name="campId"></param>
        /// <param name="rating"></param>
        /// <returns>Status code Ok if rated </returns>
        [HttpPost]
        [Route("RateCamp/{campId}")]
        public IHttpActionResult RateCamp(Guid campId, [FromBody]decimal rating)
        {
            if (campServices.SetRating(campId, rating))
            {
                return Ok();
            }
            else
            {
                return NotFound();

            }
        }
        /// <summary>
        /// Get Rating of Past Camp
        /// </summary>
        /// <param name="campId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetRating/{campId}")]
        public IHttpActionResult GetRatingOfCamp(Guid campId)
        {
            if (campServices.GetRating(campId)>0)
            {
                return Ok();
            }
            else
            {
                return NotFound();


            }
        }

    }
        

}