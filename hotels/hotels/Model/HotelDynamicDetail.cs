using System.Runtime.Serialization;

namespace hotels.Model
{
    [DataContract]
    public class HotelDynamicDetail
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public float Ratings { get; set; }
        [DataMember]
        public double PricesStartingFrom { get; set; }
        [DataMember]
        public string Offers { get; set; }
    }
}