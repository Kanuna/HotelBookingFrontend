using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Models
{
    public class AddressDTO
    {
        public string Region {  get; set; }
        public string ZipCode { get; set; }
        public string city { get; set; }
        public string Street { get; set; }
    }
}