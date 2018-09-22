using System.Runtime.Serialization;

namespace hotels.Model
{
    [DataContract]
    public class Room
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string RoomType { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int RoomsAvailable { get; set; }
        [DataMember]
        public double Price { get; set; }
    }
}