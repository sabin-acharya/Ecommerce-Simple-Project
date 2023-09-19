using Shopping.Models;

namespace Shopping.Repository.Interface
{
    public interface ICart : IRepository<Cart>
    {
        void AddUpdate(Cart cart);
    }
}
