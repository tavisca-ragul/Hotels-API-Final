using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using HotelsServices.Model;
using Newtonsoft.Json;

namespace HotelsServices.Data_Access_Layer
{
    public class HotelServices : IHotelServices
    {
        HttpClient client;

        public HotelServices()
        {
            client = new HttpClient();
        }

        public async Task<List<Hotel>> GetHotels()
        {
            var hotelStaticDetails = await GetHotelsFromLocal();
            var HotelDetailsResult = await GetHotelsFromSupplier();
            var hotels = new List<Hotel>();
            foreach (var hotelDynamicDetail in HotelDetailsResult.GetHotelDetailsResult)
            {
                var hotelStaticDetail = hotelStaticDetails.Find(h => h.ID == hotelDynamicDetail.ID);
                var hotel = new Hotel();
                hotel.ID = hotelStaticDetail.ID;
                hotel.Name = hotelStaticDetail.Name;
                hotel.Amenities = hotelStaticDetail.Amenities;
                hotel.Address = hotelStaticDetail.Address;
                hotel.Ratings = hotelDynamicDetail.Ratings;
                hotel.PricesStartingFrom = hotelDynamicDetail.PricesStartingFrom;
                hotel.Offers = hotelDynamicDetail.Offers;
                hotels.Add(hotel);
            }
            return hotels;
        }

        public async Task<List<Room>> GetRooms(int id)
        {
            string url = $"http://localhost:63163/hotelservices.svc/hotel/{id}/rooms";
            WebClient webClient = new WebClient();
            var json = webClient.DownloadString(url);
            var hotelRooms = JsonConvert.DeserializeObject<HotelRoomDetailsResult>(json);
            return hotelRooms.GetHotelRoomDetailsResult;
        }

        private async Task<List<HotelStaticDetail>> GetHotelsFromLocal()
        {
            try
            {
                using (var hotelsFile = new StreamReader("C:\\Users\\rkrishnan\\source\\repos\\HotelsServices\\HotelsServices\\Data Access Layer\\hotels.json"))
                {
                    var hotelsData = hotelsFile.ReadToEnd();
                    return JsonConvert.DeserializeObject<List<HotelStaticDetail>>(hotelsData);
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Internal Server error");
            }
        }

        private async Task<HotelDetailsResult> GetHotelsFromSupplier()
        {
            string url= "http://localhost:63163/hotelservices.svc/hotel";
            WebClient webClient = new WebClient();
            var json = webClient.DownloadString(url);
            var hotels = JsonConvert.DeserializeObject<HotelDetailsResult>(json);
            return hotels;
        }
    }
}