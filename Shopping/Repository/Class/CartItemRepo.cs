using Microsoft.EntityFrameworkCore;
using Octokit;
using Shopping.Data;
using Shopping.Models;
using Shopping.Repository.Interface;

namespace Shopping.Repository.Class
{
    public class CartItemRepo : RepositoryRepo<CartItemModel>, ICartItems
    {
        private readonly ApplicationDbContext _context;
        public CartItemRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;

        }

        public void Update(CartItemModel cartItem)
        {
            var cartItemDB = _context.CartItems.FirstOrDefault(x => x.Id == cartItem.Id);
            if (cartItemDB != null)
            {
                cartItemDB.Product = cartItem.Product;
                cartItemDB.TotalPrice = cartItem.TotalPrice;
                cartItemDB.Quantity = cartItem.Quantity;
                
            }
        }

        List<CartItemModel> ICartItems.GetUserCartItems(string userId, string includeProperties)
        {
            return _context.CartItems
           .Where(cartItem => cartItem.Cart.UserId == userId)
           .ToList();
        }
        

    }
}
