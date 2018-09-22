using hotels.Model;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace hotels
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IHotelServices" in both code and config file together.
    [ServiceContract]
    public interface IHotelServices
    {
        [OperationContract]
        [WebInvoke(
            Method = "GET",
            UriTemplate = "/hotel",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        List<HotelDynamicDetail> GetHotelDetails();

        [OperationContract]
        [WebInvoke(
            Method = "GET",
            UriTemplate = "/hotel/{id}/rooms",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        List<Room> GetHotelRoomDetails(string id);

        [OperationContract]
        [WebInvoke(
            Method = "PUT",
            UriTemplate = "/hotel/{id}/rooms/book?roomType={roomType}",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        void BookRoom(string id, string roomType);
    }
}