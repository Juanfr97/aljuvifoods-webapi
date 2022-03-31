namespace aljuvifoods_webapi.Models
{
    public class ResponseOrder
    {
        public List<Order> Orders { get; set; }
        public int Total { get; set; }
    }
}
