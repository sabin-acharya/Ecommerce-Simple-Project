using Shopping.Models;

namespace Shopping.Repository.Interface
{
    public interface ICartRepo : IRepositoryRepo<CartModel>
    {
        void AddUpdate(CartModel cart);
    }
}
