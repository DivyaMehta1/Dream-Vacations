using BusinessLayer.Mappers;
using BusinessLayer.Models;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Http;

namespace BusinessLayer.Services
{
    public class CampServices
    {
        private readonly CampsRepository campsRepository;
        public CampServices()
        {
            campsRepository = new CampsRepository();
        }
        /// <summary>
        /// GetAllCamps from DB
        /// </summary>
        /// <returns>Required Object</returns>
        public IEnumerable<CampsDTO> GetAllCamps()
        {
            Mapper mapper = new Mapper();
            var camps = campsRepository.getAll().ToList();
            return mapper.MapToDTO(camps);
        }
        /// <summary>
        /// Get Details of Desired Camp
        /// </summary>
        /// <param name="Id">Id of desired Camp</param>
        /// <returns>Object of Required data</returns>

        public CampsDTO GetCamp(Guid Id)
        {
            Mapper mapper = new Mapper();
            return mapper.MapToDTO(campsRepository.GetCamp(Id));
        }
        /// <summary>
        /// Add New Camp
        /// </summary>
        /// <param name="camp"></param>
        /// <returns></returns>
        public bool AddCamp(CampsDTO camp)
        {
               Mapper mapper = new Mapper();
            var result = campsRepository.Add(mapper.MapToModel(camp));
            return result > 0;
        }
        /// <summary>
        /// Update an Existing Camp
        /// </summary>
        /// <param name="camp"></param>
        /// <returns>bool value indicating it has been updated or not </returns>
        public bool UpdateCamp(CampsDTO camp)
        {
            Mapper mapper = new Mapper();
            var result = campsRepository.Update(mapper.MapToModel(camp));
            return result > 0;
        }
        /// <summary>
        /// Delete an Existing Camp
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ool value indicating it has been deleted or not</returns>
        public bool DeleteCamp(Guid id)
        {
            var result = campsRepository.Delete(id);
            return result > 0;
        }
        public IEnumerable<CampsDTO> GetAvailableCamps()
        {
            Mapper mapper = new Mapper();
            return mapper.MapToDTO(campsRepository.FindAvailabilty().ToList());
        }
        
        /// <summary>
        /// set Rating for A Given Camp
        /// </summary>
        /// <param name="campId"></param>
        /// <param name="rating"></param>
        /// <returns></returns>
        public bool SetRating(Guid campId, decimal rating)
        {
            var result = campsRepository.SetRating(campId, rating);
              return result;
         
        }
        /// <summary>
        /// Get Rating of a camp
        /// </summary>
        /// <param name="campId"></param>
        /// <returns></returns>
        public decimal? GetRating(Guid campId)
        {
            var result = campsRepository.GetRating(campId);
            return result;
        }
            /// <summary>
            /// Get Bookinggs between given dated & Capacity
            /// </summary>
            /// <param name="checkinDate"></param>
            /// <param name="chekoutDate"></param>
            /// <param name="capacity"></param>
            /// <returns></returns>
            public IEnumerable<CampsDTO> GetCampsBetween(DateTime checkinDate, DateTime chekoutDate, int capacity)
        {
            Mapper mapper = new Mapper();
            List<Camps> camps = new List<Camps>();
            var availableCamps = campsRepository.GetCampsBetween(checkinDate, chekoutDate, capacity);
            return mapper.MapToDTO(availableCamps.ToList());
        }
    }
}