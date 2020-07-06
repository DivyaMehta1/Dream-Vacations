using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DataAccessLayer.Models
{
    /// <summary>
    /// Model Basis for Booking Entity in DB
    /// </summary>
    public class Bookings
    {
        [Key]
        public string ReferenceNumber { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int TotalNights { get; set; }
        public string BillingAddress { get; set; }
        public string Contact { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public int NoOfPeople { get; set; }
        public Guid CampId { get; set; }
        public double BillingAmount { get; set; }
      
        [ForeignKey("CampId")]
        public Camps Camp { get; set; }
       


    }
}