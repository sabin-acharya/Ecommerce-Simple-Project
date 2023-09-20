using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int CartItemsId { get; set; }
        [ForeignKey("CartItemsId")]
        public CartItem? CartItem { get; set;}
    }
}
