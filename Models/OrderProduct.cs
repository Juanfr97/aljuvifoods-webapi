using System.ComponentModel.DataAnnotations.Schema;

namespace aljuvifoods_webapi.Models
{
    public class OrderProduct
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public double Total { get; set; }

        public Product Product { get; set; }
        
    }
}
