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
    }
}
