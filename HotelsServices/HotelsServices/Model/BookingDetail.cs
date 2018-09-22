using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelsServices.Model
{
    public class BookingDetail
    {
        public string Name { get; set; }
        public string EmailID { get; set; }
        public string PhoneNumber { get; set; }
        public int HotelID { get; set; }
        public string RoomType { get; set; }
    }
}