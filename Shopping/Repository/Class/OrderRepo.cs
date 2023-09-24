using Shopping.Data;
using Shopping.Models;
using Shopping.Repository.Interface;

namespace Shopping.Repository.Class
{
    public class OrderRepo : RepositoryRepo<Order>, IOrder
    {
        private readonly ApplicationDbContext _context;
        public OrderRepo(ApplicationDbContext context) : base(context)
        {

            _context = context;

        }

        public void Update(Order order)
        {
            throw new NotImplementedException();
        }
        public void AddCartItemId(CartItem cartItem)
        {
            var orderDB = _context.Orders.FirstOrDefault(x => x.Id == cartItem.Id);
            //var cartitemDB = _context.CartItems.FirstOrDefault(x => x.Id == id);
            
            if (orderDB == null)
            {
                orderDB.CartItemsId = cartItem.Id;
            }
            _context.Orders.Add(orderDB);
        }

       
    }
}
