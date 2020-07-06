using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class CampsDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Capacity { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public string Image { get; set; }
        public Guid AdminId { get; set; }
        public decimal? Rating { get; set; }


    }
}
