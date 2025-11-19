using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Models
{
    public class HotelDTO
    {
        public string Name {  get; set; }
        public string Description { get; set; }
        public string Policies { get; set; }
        public string Franchise { get; set; }
        public double StarRating { get; set; }

        public AddressDTO Address { get; set; }
        public ContactInfoHotelDTO ContactInfoHotelDTO { get; set; }

        public List<RoomDTO> RoomList { get; set; }
        public List<ReviewDTO> ReviewList { get; set; }
        public List<AmenityDTO> AmenityList { get; set; }


        public decimal MinRoomPrice
            => RoomList == null || RoomList.Count == 0
            ? 0
            : RoomList.Min(r => r.Price);


        public decimal MaxRoomPrice
            => RoomList == null || RoomList.Count == 0
            ? 0
            : RoomList.Max(r => r.Price);


        public string PriceRange => $"{MinRoomPrice} - {MaxRoomPrice}";
    }
}