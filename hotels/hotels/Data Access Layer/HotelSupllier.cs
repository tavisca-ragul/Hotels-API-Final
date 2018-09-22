using System;
using System.Collections.Generic;
using Cassandra;
using hotels.Model;

namespace hotels.Data_Access_Layer
{
    public class HotelSupllier : IHotelSupplier
    {
        Cluster cluster;
        ISession session;

        public HotelSupllier()
        {
            cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
            session = cluster.Connect("hotels");
        }

        public List<HotelDynamicDetail> GetHotelDetails()
        {
            try
            {
                var hotels = new List<HotelDynamicDetail>();
                var query = session.Prepare("select * from hotels");
                var statement = query.Bind();
                var result = session.Execute(statement);
                foreach (var hotelResult in result)
                {
                    var hotel = new HotelDynamicDetail();
                    hotel.ID = hotelResult.GetValue<Int32>("id");
                    hotel.Ratings = hotelResult.GetValue<float>("ratings");
                    hotel.PricesStartingFrom = hotelResult.GetValue<double>("pricestartingfrom");
                    hotel.Offers = hotelResult.GetValue<string>("offers");
                    hotels.Add(hotel);
                }
                return hotels;
            }
            catch(Exception ex)
            {
                throw new Exception("Internal Server Error");
            }
        }

        public List<Room> GetHotelRooms(string id)
        {
            try
            {
                var rooms = new List<Room>();
                var query = session.Prepare("select * from hotel_rooms where id = ?");
                var statement = query.Bind(int.Parse(id));
                var result = session.Execute(statement);
                foreach (var roomRow in result)
                {
                    var room = new Room();
                    room.ID = roomRow.GetValue<Int32>("id");
                    room.RoomType = roomRow.GetValue<string>("room_type");
                    room.Description = roomRow.GetValue<string>("description");
                    room.RoomsAvailable = roomRow.GetValue<int>("rooms_available");
                    room.Price = roomRow.GetValue<double>("price");
                    rooms.Add(room);
                }
                return rooms;
            }
            catch (Exception ex)
            {
                throw new Exception("Internal Server Error");
            }
        }


        public void BookRoom(string id, string roomType)
        {
            try
            { 
                var query = session.Prepare("select * from hotel_rooms where id = ? and room_type = ?");
                var Statement = query.Bind(int.Parse(id), roomType);
                var result = session.Execute(Statement);
                int roomsAvailable = 0;
                foreach (var hotelRoom in result)
                    roomsAvailable = hotelRoom.GetValue<Int32>("rooms_available");
                query = session.Prepare("update hotel_rooms set rooms_available = ? where id = ? and room_type = ?");
                var batchStatement = new BatchStatement().Add(query.Bind(roomsAvailable - 1, int.Parse(id), roomType));
                session.Execute(batchStatement);
            }
            catch (Exception ex)
            {
                throw new Exception("Internal Server Error");
            }
        }
    }
}