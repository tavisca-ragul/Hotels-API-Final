using HotelsServices.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelsServices.Data_Access_Layer
{
    interface IHotelBookingServices
    {
        void BookRoom(BookingDetail bookingDetail);
    }
}