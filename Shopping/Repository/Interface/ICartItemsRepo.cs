using Shopping.Models;
using Shopping.Repository.Class;

namespace Shopping.Repository.Interface
{
    public interface ICartItemsRepo : IRepositoryRepo<CartItemModel>
    {
        void Update(CartItemModel cartItem);
        
        List<CartItemModel> GetUserCartItems(string userId, string includeProperties);
        
    }
}

