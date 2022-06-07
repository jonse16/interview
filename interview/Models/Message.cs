namespace interview.Models
{
    public class Message
    {
        public int id { get; set; }
        public string name { get; set; }

        public string msg { get; set; }

        public int houseId { get; set; }

        public DateTime createDateTime { get; set; }

        public DateTime lastUpdateDateTime { get; set; }
    }
}
