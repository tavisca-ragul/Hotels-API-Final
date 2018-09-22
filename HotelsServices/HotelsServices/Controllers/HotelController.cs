using System.Collections.Generic;
using System.Threading.Tasks;
using HotelsServices.Attributes;
using HotelsServices.Data_Access_Layer;
using HotelsServices.Model;
using Microsoft.AspNetCore.Mvc;

namespace HotelsServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Logging]
    public class HotelController : ControllerBase
    {
        [HttpGet]
        public async Task<List<Hotel>> GetAllHotels()
        {
            IHotelServices hotelServices = new HotelServices();
            return await hotelServices.GetHotels();
        }

        [HttpGet]
        [Route("{id}/rooms")]
        public async Task<List<Room>> GetHotelRooms(int id)
        {
            IHotelServices hotelServices = new HotelServices();
            return await hotelServices.GetRooms(id);
        }

        [HttpPost]
        [Route("{id}/rooms/book")]
        public async Task BookRoom(BookingDetail bookingDetail)
        {
            HotelBooking hotelBooking = new HotelBooking();
            hotelBooking.BookRoom(bookingDetail);
        }
    }
}