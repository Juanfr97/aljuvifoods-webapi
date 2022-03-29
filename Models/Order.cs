namespace aljuvifoods_webapi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public double OrderTotal { get; set; }
        public DateTime OrderDate { get; set; }
        public User OrderUser { get; set; }
    }
}
