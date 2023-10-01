using Shopping.Models;

namespace Shopping.Repository.Interface
{
    public interface IOrderRepo : IRepositoryRepo<OrderModel>
    {
        void Update(OrderModel order);
        void AddCartItemId(CartItemModel cartItem);
    }
}
