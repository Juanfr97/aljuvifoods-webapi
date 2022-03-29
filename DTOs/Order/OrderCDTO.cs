using aljuvifoods_webapi.DTOs.OrderProduct;
using aljuvifoods_webapi.Models;

namespace aljuvifoods_webapi.DTOs.Order
{
    public class OrderCDTO
    {
        public int UserId { get; set; }
        public double OrderTotal { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderProductCDTO> Products { get; set; }
    }
}
