using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
   public class UsersDTO
    {
        public string  Username { get; set; }
        public string Password { get; set; }
        public Guid Id { get; set; }
    }
}
