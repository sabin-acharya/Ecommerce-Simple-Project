using Shopping.Models;
using Shopping.Repository.Class;

namespace Shopping.Repository.Interface
{
    public interface ICartItems : IRepository<CartItem>
    {
        void Update(CartItem cartItem);
        List<CartItem> GetUserCartItems(string userId, string includeProperties);
    }
}

