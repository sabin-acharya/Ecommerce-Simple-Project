using Shopping.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.Models
{
    public class OrderModel
    {
        public int Id { get; set; }

        public int CartItemsId { get; set; }
        [ForeignKey("CartItemsId")]
        public CartItemModel? CartItem { get; set;}
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }
    }
}
