using Shopping.Models;

namespace Shopping.ViewModel
{
    public class CartViewModel
    {
        public CartItem CartItem { get; set; } = new CartItem();


        public IEnumerable<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
