using HotelsServices.Model;
using System.Net;
using System.Threading.Tasks;

namespace HotelsServices.Data_Access_Layer
{
    public class HotelBooking
    {
        public async Task BookRoom(BookingDetail bookingDetail)
        {
            await BookRoomInSupplier(bookingDetail.HotelID, bookingDetail.RoomType);
            await SaveBookingDetails(bookingDetail);
        }

        private async Task BookRoomInSupplier(int hotelID, string roomType)
        {
            string url = $"http://localhost:63163/hotelservices.svc/hotel/{hotelID}/rooms/book?roomType={roomType}";
            WebClient webClient = new WebClient();
            var json = webClient.UploadString(url, "PUT", "");
        }

        private async Task SaveBookingDetails(BookingDetail bookingDetail)
        {
            IHotelBookingServices hotelBookingServices = new HotelBookingServices();
            hotelBookingServices.BookRoom(bookingDetail);
        }
    }
}