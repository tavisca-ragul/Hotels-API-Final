namespace HotelsServices.Model
{
    public class Hotel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string[] Amenities { get; set; }
        public string Address { get; set; }
        public float Ratings { get; set; }
        public double PricesStartingFrom { get; set; }
        public string Offers { get; set; }
    }
}