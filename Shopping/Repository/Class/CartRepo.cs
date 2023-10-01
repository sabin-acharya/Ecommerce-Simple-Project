using Microsoft.EntityFrameworkCore;
using Shopping.Data;
using Shopping.Models;
using Shopping.Repository.Interface;

namespace Shopping.Repository.Class
{
    public class CartRepo : RepositoryRepo<CartModel>, ICartRepo
    {
        private readonly ApplicationDbContext _context;
        public CartRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;

        }

        
       public void AddUpdate(CartModel cart)
        {
            if(cart != null)
            {
                var cartDB = _context.Carts.FirstOrDefault(x => x.Id == cart.Id);
                if (cartDB != null)
                {
                    cartDB.UserId = cart.UserId;
                   
                }
               
            }
              _context.Add(cart);
        }
    }
}
