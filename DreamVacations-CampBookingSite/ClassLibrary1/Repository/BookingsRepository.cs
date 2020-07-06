using DataAccessLayer.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Repository
{
    /// <summary>
    /// Class to access DBEnity Bookings
    /// </summary>
    public class BookingsRepository
    {
        private readonly MyContext _context;

        public BookingsRepository()
        {
            _context = new MyContext();

        }
        /// <summary>
        /// Add new entry in BookingsEntity 
        /// Checks for Past Entries on same Date
        /// </summary>
        /// <param name="booking"></param>
        /// <returns>Reference number of the Newly created booking </returns>
        public string Add(Bookings booking)
        {            
           try
            {
                BookingsRepository bookingsRepository = new BookingsRepository();

                List<Bookings> bookedCamps = bookingsRepository.GetBookingsBetween(booking.CheckInDate, booking.CheckOutDate).ToList();
                var previousRecords = bookedCamps.FirstOrDefault(item => item.CampId == booking.CampId);
                if (previousRecords == null)
                {
                    _context.Bookings.Add(booking);
                    _context.SaveChanges();
                    return booking.ReferenceNumber.ToString();
                }
                else
                {
                    return "Booked";
                }
                
            }

            catch (Exception e)
            {
                throw e;
            }


        }
        /// <summary>
        /// Deletes Booking with given ReferenceNumber from DB
        /// </summary>
        /// <param name="referenceNumber"></param>
        /// <returns>value if deleted else 0 </returns>
        public int Delete(string referenceNumber)
        {
            var resulSet = _context.Bookings.FirstOrDefault(bookings => bookings.ReferenceNumber == referenceNumber && bookings.CheckInDate >= System.DateTime.Now);
            var result = 0;
            if (resulSet != null)
            {
                _context.Bookings.Remove(resulSet);
                result = _context.SaveChanges();
            }

            return result;
        }
        /// <summary>
        /// Update Booking in DB
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="booking"></param>
        /// <returns></returns>
        public int Update<T>(T booking) where T : Bookings
        {
            var bookingToEdit = _context.Bookings.Find(booking.ReferenceNumber);
            if (_context.Camps.Find(bookingToEdit) == null)
            {
                return 0;
            }
            else
            {
                _context.Entry(bookingToEdit).CurrentValues.SetValues(booking);
                var resultset = _context.SaveChanges();
                return resultset;
            }
        }

        /// <summary>
        /// GET Request to Search Booking Between Given Dates
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns>returns required Queryable Object from DB</returns>
        public IQueryable<Bookings> GetBookingsBetween(DateTime from, DateTime to)
        {


            return _context.Bookings.Where(bookings => bookings.CheckInDate >= from && bookings.CheckOutDate <= to);
        }
        /// <summary>
        /// GET request to Provide Details for a Particular Booking
        /// </summary>
        /// <param name="referenceNumber"></param>
        /// <returns> Bookings Object  with Required details </returns>

        public Bookings GetBooking(string referenceNumber)
        {
            return _context.Bookings.FirstOrDefault(bookings => bookings.ReferenceNumber == referenceNumber);

        }
    }
}