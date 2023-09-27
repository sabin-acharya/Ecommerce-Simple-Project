using Shopping.Models;

namespace Shopping.Repository.Interface
{
    public interface IOrder : IRepository<OrderModel>
    {
        void Update(OrderModel order);
        void AddCartItemId(CartItemModel cartItem);
    }
}
