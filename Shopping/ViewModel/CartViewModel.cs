using Shopping.Models;

namespace Shopping.ViewModel
{
    public class CartViewModel
    {
        public CartItemModel CartItem { get; set; } = new CartItemModel();


        public IEnumerable<CartItemModel> CartItems { get; set; } = new List<CartItemModel>();
    }
}
