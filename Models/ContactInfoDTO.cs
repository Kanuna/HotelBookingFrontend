using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HotelBooking.Models
{
    public class ContactInfoDTO
    {
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}