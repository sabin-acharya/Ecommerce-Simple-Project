using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.Models
{
    public class Buy
    {
        public int Id { get; set; }
        public string? CustomerName { get; set; }

        public string? Address { get; set; }

        public double PhoneNumber { get; set; }
       
        public int CartItemId { get; set; }
        [ForeignKey("CartItemId")]
        public CartItem? CartItem { get; set; }
    }
}
