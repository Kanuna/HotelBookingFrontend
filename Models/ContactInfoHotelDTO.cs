using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Models
{
    public class ContactInfoHotelDTO
    {
        public string HotelEmail { get; set; }
        public string HotelPhoneNumber { get; set; }

        public List<ManagerDTO> ManagerDTOs { get; set; }
    }
}