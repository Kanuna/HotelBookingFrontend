using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Models
{
    public class UserCreateDTO
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }
        public ContactInfoDTO ContactInfo { get; set; }
    }
}
