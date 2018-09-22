using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using HotelsServices.Model;

namespace HotelsServices.Data_Access_Layer
{
    public class HotelBookingServices : IHotelBookingServices
    {
        SqlConnectionStringBuilder Builder;
        SqlConnection Connection;
        SqlCommand Statement;
        String Query;

        public HotelBookingServices()
        {
            Builder = new SqlConnectionStringBuilder();
            Builder.DataSource = "TAVDESK136";
            Builder.UserID = "sa";
            Builder.Password = "test123!@#";
            Builder.InitialCatalog = "Hotel";
            Query = null;
            Statement = null;
        }

        public void BookRoom(BookingDetail bookingDetail)
        {
            try
            {
                using (Connection = new SqlConnection(Builder.ConnectionString))
                {
                    Query = "insert into booking_details(name, email_id, phone_number, hotel_id, room_type) values(@Name, @EmailID, @PhoneNumber, @HotelID, @RoomType)";
                    Connection.Open();
                    using (Statement = new SqlCommand(Query, Connection))
                    {
                        Statement.CommandType = CommandType.Text;
                        Statement.Parameters.AddWithValue("@Name", bookingDetail.Name);
                        Statement.Parameters.AddWithValue("@EmailID", bookingDetail.EmailID);
                        Statement.Parameters.AddWithValue("@PhoneNumber", bookingDetail.PhoneNumber);
                        Statement.Parameters.AddWithValue("@HotelID", bookingDetail.HotelID);
                        Statement.Parameters.AddWithValue("@RoomType", bookingDetail.RoomType);
                        Statement.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Internal Server Error");
            }
        }
    }
}