using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Models
{
    public class BookingDTO
    {
        public DateOnly StartDate {  get; set; }
        public DateOnly EndDate { get; set; }
    }
}