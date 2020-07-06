using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    /// <summary>
    /// Bookings ViewModel for getting data from Client and sending it back.
    /// </summary>
   public class BookingsDTO
    {
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


    }
}
