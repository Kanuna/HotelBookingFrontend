using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Models
{
    public class ReviewDTO
    {
        public string Title { get; set; }
        public string Comment { get; set; }
        public double Rating { get; set; }
        public DateOnly CreatedAt { get; set; }
    }
}