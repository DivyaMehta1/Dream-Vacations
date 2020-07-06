using BusinessLayer.Mappers;
using BusinessLayer.Models;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Services
{
    public class BookingServices
    {
        private readonly BookingsRepository bookingsRepository;
        public BookingServices()
        {
            bookingsRepository = new BookingsRepository();
        }
        /// <summary>
        /// Book a Camp in DB
        /// </summary>
        /// <param name="bookingDetails">object to be added </param>
        /// <returns></returns>
        public string AddBooking(BookingsDTO bookingDetails)
        {
            Mapper mapper = new Mapper();
            var booking = mapper.MapToModel(bookingDetails);
            var result = bookingsRepository.Add(booking);
            return result;
        }
        /// <summary>
        /// GET Request to Search Booking Between Given Dates
        /// </summary>
        /// </summary>
        /// <param name="checkin"></param>
        /// <param name="checkout"></param>
        /// <returns> Enumerable Object with Required Data </returns>
        public IEnumerable<BookingsDTO> GetBookingsBetween(DateTime checkin, DateTime checkout)
        {
            Mapper mapper = new Mapper();
            var bookings =bookingsRepository.GetBookingsBetween(checkin, checkout).ToList();
            return mapper.MapToDTO(bookings);


        }
        /// <summary>
        /// GET request to Provide Details for a Particular 
        /// </summary>
        /// <param name="referenceNumber"></param>
        /// <returns> DTO Object with Required details </returns>
        public BookingsDTO GetBooking(string referenceNumber)
        {
            Mapper mapper = new Mapper();
            var result = bookingsRepository.GetBooking(referenceNumber);
            if (result == null)
                return null;
            else
            return mapper.MapToDTO(result);
             
        }
        /// <summary>
        /// DELETE request to delete a Booking
        /// </summary>
        /// <param name="referenceNumber"> needs refNumber of Booking to be Deleted</param>
        /// <returns></returns>
        public bool DeleteBooking(string referenceNumber)
        {
            var result = bookingsRepository.Delete(referenceNumber);
            return result > 0;
        }
       


    }
}