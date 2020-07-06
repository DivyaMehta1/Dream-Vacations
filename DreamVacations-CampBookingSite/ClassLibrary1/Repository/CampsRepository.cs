using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;

namespace DataAccessLayer.Repository
{
    public class CampsRepository
    {
        private readonly MyContext _context;
        public void FixEfProviderServicesProblem()
        {
            //The Entity Framework provider type 'System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer'
            //for the 'System.Data.SqlClient' ADO.NET provider could not be loaded. 
            //Make sure the provider assembly is available to the running application. 
            //See http://go.microsoft.com/fwlink/?LinkId=260882 for more information.

            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        public CampsRepository()
        {
            _context = new MyContext();

        }
        public int Add(Camps camp)
        {
            var existingCamp = _context.Camps.FirstOrDefault(camps => camps.Title.ToUpper() == camp.Title.ToUpper());
            if (existingCamp != null)
            {
                return 0;
            }
            else
            {
                _context.Camps.Add(camp);
                var result = _context.SaveChanges();
                return result;
            }
        }
        public int Delete(Guid campId)
        {
            var resulSet = _context.Camps.FirstOrDefault(camps => camps.Id == campId);
            var result = 0;
            if (resulSet != null)
            {
                _context.Camps.Remove(resulSet);
                result = _context.SaveChanges();
            }

            return result;
        }
        public int Update<T>(T camp) where T : Camps
        {
            var campToEdit = _context.Camps.Find(camp.Id);
            if (campToEdit == null)
            {
                return 0;
            }
            else
            {
                _context.Entry(campToEdit).CurrentValues.SetValues(camp);
                var resultset = _context.SaveChanges();
                return resultset;
            }
        }
        /// <summary>
        /// GetAllCamps from DB
        /// </summary>
        /// <returns>IQueryable Object</returns>
        public IQueryable<Camps> getAll()
        {
            return _context.Camps;
        }
        /// <summary>
        /// Get Details of Desired Camp
        /// </summary>
        /// <param name="Id">Id of desired Camp</param>
        /// <returns>Object of Required data</returns>
        public Camps GetCamp(Guid Id)
        {

            return _context.Camps.FirstOrDefault(Camps => Camps.Id == Id);

        }
        public IQueryable<Camps> FindAvailabilty()
        {
            return _context.Camps.Where(camps => camps.IsBooked == false);
        }
        
        /// <summary>
        /// Camps between given dates & capacity
        /// </summary>
        /// <param name="checkin"></param>
        /// <param name="checkout"></param>
        /// <param name="capacity"></param>
        /// <returns>Enumerable object with desired campList</returns>
        public IEnumerable<Camps> GetCampsBetween(DateTime checkin, DateTime checkout, int capacity)
        {
            //Get Bookings between given Checkin & Checkout Dates and then add then return the one's which are uncommon
            BookingsRepository bookingsRepository = new BookingsRepository();
            var bookedCamps = bookingsRepository.GetBookingsBetween(checkin, checkout).Select(bookings=>bookings.CampId).ToList();
            var totalCamps = _context.Camps.Where(camps => camps.Capacity == capacity).ToList();
            List<Camps> availableCamps = new List<Camps>();
           
            foreach (var camp in totalCamps)
            {
                bool isBooked = false;
                foreach (var campId in bookedCamps)
                {
                    if (camp.Id == campId)
                    {
                        isBooked = true;
                    }
                }
                if (isBooked == false)
                    availableCamps.Add(camp);
            }
            
            return availableCamps;
           
        }
        /// <summary>
        /// Sets RAting for a PastBooking
        /// </summary>
        /// <param name="campId">Ensures campId </param>
        /// <param name="rating">value</param>
        /// <returns>bool :true(added)/false:(not added)</returns>
        //set Ratings For Past Bookings
        public bool SetRating(Guid campId, decimal rating)
        {
            var pastBooking = _context.Bookings.FirstOrDefault((booking => booking.CampId == campId && booking.CheckOutDate < System.DateTime.Now));
            if (pastBooking != null)
            {
                var campToRate = _context.Camps.FirstOrDefault(camp => camp.Id == pastBooking.CampId);
                campToRate.Rating = rating;
                var resultset = _context.SaveChanges();
                return resultset > 0;
            }
            else return false;
            
        }
        /// <summary>
        /// Get Rating of a 
        /// </summary>
        /// <param name="campId"></param>
        /// <returns></returns>
        public decimal? GetRating(Guid campId)
        {

            var result = _context.Camps.FirstOrDefault((camp => camp.Id == campId));
            return result.Rating;
        }


    }

}