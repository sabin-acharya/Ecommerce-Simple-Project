using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.Models
{
    public class BuyModel
    {
        public int Id { get; set; }
        public string? CustomerName { get; set; }

        public string? Address { get; set; }

        public double PhoneNumber { get; set; }
       
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public OrderModel? Order { get; set; }
    }
}
