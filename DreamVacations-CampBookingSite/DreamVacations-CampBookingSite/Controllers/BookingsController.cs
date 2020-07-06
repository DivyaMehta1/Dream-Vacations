using BusinessLayer.Models;
using BusinessLayer.Services;
using Microsoft.Ajax.Utilities;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace DreamVacations_CampBookingSite.Controllers
{


    [RoutePrefix("Api/bookings")]
    public class BookingsController : ApiController
    {
        /// <summary>
        /// Controller for Handling All calls related to BookingModel
        /// </summary>
        ///
        private readonly BookingServices bookingServices;
        private readonly CampServices campServices;

        public BookingsController()
        {
            bookingServices = new BookingServices();
            campServices = new CampServices();
        }

        /// <summary>
        ///  GET Request to Search Booking Between Given Dates
        /// </summary>
        /// <param name="checkInDate"></param>
        /// <param name="checkOutDate"></param>
        /// <returns> JSON with Required Data </returns>
        // GET: api/Bookings
        [HttpGet]
        [Route("BookingsBetween/{checkInDate}/{checkOutDate}")]
        public IHttpActionResult GetBookingsBetween(DateTime checkInDate, DateTime checkOutDate)
        {

            var bookings = bookingServices.GetBookingsBetween(checkInDate, checkOutDate);
            if (bookings == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

            return Ok(bookings);
        }

        /// <summary>
        /// GET request to Provide Details for a Particular 
        /// </summary>
        /// <param name="referenceNumber"></param>
        /// <returns> JSON with Required details </returns>
        [HttpGet]
        [Route("GetBookingDetails/{referenceNumber}")]
        public IHttpActionResult GetBookingsBetween(string referenceNumber)
        {
            var booking = bookingServices.GetBooking(referenceNumber);
            if (booking == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

            return Ok(booking);

        }
        /// <summary>
        /// Book a Camp 
        /// </summary>
        /// <param name="booking">object to be added </param>
        /// <returns></returns>
        [HttpPost]
        [Route("Book")]
        public IHttpActionResult Post([FromBody]BookingsDTO booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = bookingServices.AddBooking(booking);
            //booking not done due to invalid creds.
            if (result.IsNullOrWhiteSpace())
            {
                return new ResponseMessageResult(
                Request.CreateErrorResponse(
                    (HttpStatusCode)422,
                    new HttpError("Something went wrong")
                ));

            }
            return Ok(result);
        }
        /// <summary>
        /// DELETE request to delete a Booking
        /// </summary>
        /// <param name="referenceNumber"> needs refNumber of Booking to be Deleted</param>
        /// <returns></returns>

        [HttpDelete]
        [Route("CancelBooking/{referenceNumber}")]
        public IHttpActionResult CancelBooking(string referenceNumber)
        {
            var result = bookingServices.DeleteBooking(referenceNumber);
            if (!result)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
