using Shopping.Models;

namespace Shopping.Repository.Interface
{
    public interface ICart : IRepository<CartModel>
    {
        void AddUpdate(CartModel cart);
    }
}
