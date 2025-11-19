using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Models
{
    public class RoomDTO
    {
        public string RoomNumber { get; set; }
        public byte NumberOfBeds { get; set; }
        public bool HasKitchen { get; set; }
        public short Roomsize { get; set; }
        public int Price { get; set; }
        public Ocuppied Ocuppied { get; set; }
        public List<BookingDTO> Bookings { get; set; }
    }

    public enum Ocuppied
    {
        OCCUPIED,
        VACANT
    }
}