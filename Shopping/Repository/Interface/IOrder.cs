using Shopping.Models;

namespace Shopping.Repository.Interface
{
    public interface IOrder : IRepository<Order>
    {
        void Update(Order order);

    }
}
