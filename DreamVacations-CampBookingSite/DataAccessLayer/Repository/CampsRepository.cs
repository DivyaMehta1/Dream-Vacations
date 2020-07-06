using SharedProject.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccessLayer.Repository
{
    public class CampsRepository
    {
        private readonly MyContext _context;
        public CampsRepository()
        {
            _context = new MyContext();

        }
        public int Add(Camps camp)
        {
            var existingCamp = _context.Camps.FirstOrDefault(camps => camps.Title.ToUpper() == camp.Title.ToUpper());
            if (existingCamp == null)
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
            var campToEdit = (Camps)_context.Camps.Find(camp.Id);
            if (_context.Camps.Find(campToEdit) == null)
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
        public IQueryable<Camps> getAll()
        {
            return _context.Camps;
        }
        public Camps GetCamp(Guid Id)
        {

            return _context.Camps.FirstOrDefault(Camps => Camps.Id == Id);

        }
        public IQueryable<Camps> FindAvailabilty()
        {
            return _context.Camps.Where(camps => camps.IsBooked == false);
        }
        public void SetBooked(Guid campId, bool isBooked)
        {
            try
            {
                _context.Camps.Where(camps => camps.Id == campId).ToList().ForEach(camp => camp.IsBooked = isBooked);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public IEnumerable<Camps> GetCampsBetween(DateTime checkin, DateTime checkout, int capacity)
        {
            var sqlParametercheckin = new SqlParameter("@checkin", checkin);
            var sqlparamaetrecheckout = new SqlParameter("@checkout", checkout);
            var sqlPArametreCapacity = new SqlParameter("@capacity", capacity);
            var result = _context.Database.SqlQuery<Camps>("FilterBookings @checkin,@checkout,@capacity", sqlParametercheckin, sqlparamaetrecheckout, sqlPArametreCapacity).ToList();
             
            
            return result;
        }
       
    }

}