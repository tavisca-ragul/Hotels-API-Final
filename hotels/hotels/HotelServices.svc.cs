using System.Collections.Generic;
using hotels.Data_Access_Layer;
using hotels.Model;

namespace hotels
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "HotelServices" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select HotelServices.svc or HotelServices.svc.cs at the Solution Explorer and start debugging.
    public class HotelServices : IHotelServices
    {
        public void BookRoom(string id, string roomType)
        {
            IHotelSupplier hotelSupplier = new HotelSupllier();
            hotelSupplier.BookRoom(id, roomType);
        }

        public List<HotelDynamicDetail> GetHotelDetails()
        {
            IHotelSupplier hotelSupplier = new HotelSupllier();
            return hotelSupplier.GetHotelDetails();
        }

        public List<Room> GetHotelRoomDetails(string id)
        {
            IHotelSupplier hotelSupplier = new HotelSupllier();
            return hotelSupplier.GetHotelRooms(id);
        }
    }
}