using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelsServices.Model
{
    public class HotelStaticDetail
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string[] Amenities { get; set; }
        public string Address { get; set; }
    }
}