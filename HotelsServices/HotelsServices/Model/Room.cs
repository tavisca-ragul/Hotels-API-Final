namespace HotelsServices.Model
{
    public class Room
    {
        public int ID { get; set; }
        public string RoomType { get; set; }
        public string Description { get; set; }
        public int RoomsAvailable { get; set; }
        public double Price { get; set; }
    }
}
