using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Models
{
    public class AmenityDTO
    {
        public string Name {  get; set; }
        public List<HotelDTO> HotelDTOs { get; set; }
    }
}
