using HotelsServices.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelsServices.Data_Access_Layer
{
    interface IHotelServices
    {
        Task<List<Hotel>> GetHotels();
        Task<List<Room>> GetRooms(int id);
    }
}