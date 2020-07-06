using SharedProject.Models;
using System;
using System.Linq;

namespace DataAccessLayer.Repository
{
    public class BookingsRepository
    {
        private readonly MyContext _context;

        public BookingsRepository()
        {
            _context = new MyContext();

        }
        public int Add(Bookings bookings) {
            var existingBooking = _context.Bookings.FirstOrDefault(booking => booking.ReferenceNumber == bookings.ReferenceNumber);
            if (existingBooking == null)
            {
                return 0;
            }
            else
            {
                _context.Bookings.Add(bookings);
                var result = _context.SaveChanges();
                return result;
            }
        }
        public int Delete(Guid referenceNumber)
        {
            var resulSet = _context.Bookings.FirstOrDefault(bookings => bookings.ReferenceNumber == referenceNumber);
            var result = 0;
          /* var similar = _context.Bookings.FirstOrDefault(bookings => bookings.CampId == resulSet.CampId);
            if (similar == null)
                _context.Camps.Find(similar).IsBooked = false;
            */
            if (resulSet != null)
            {
                _context.Bookings.Remove(resulSet);
                result = _context.SaveChanges();
            }

            return result;
        }
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
        public IQueryable<Bookings> getBookingsFor(Guid userId) {
           return 
                _context.Bookings.
                Where(bookings=>Guid.Parse(bookings.UserId.ToString())==userId);
        }
        public IQueryable<Bookings> GetBookingsBetween(DateTime from, DateTime to) {
            return _context.Bookings.Where(bookings => bookings.CheckInDate<to && bookings.CheckOutDate > from);
        }
        public Bookings GetBooking(Guid referenceNumber) {
            return _context.Bookings.FirstOrDefault(bookings => bookings.ReferenceNumber ==referenceNumber);

              }
    }
}