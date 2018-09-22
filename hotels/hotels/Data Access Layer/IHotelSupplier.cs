using hotels.Model;
using System.Collections.Generic;

namespace hotels.Data_Access_Layer
{
    interface IHotelSupplier
    {
        List<HotelDynamicDetail> GetHotelDetails();
        List<Room> GetHotelRooms(string id);
        void BookRoom(string id, string roomType);
    }
}