using Shopping.Data;
using Shopping.Data.Migrations;
using Shopping.Repository.Interface;

namespace Shopping.Repository.Class
{
    public class UnitOfWorkRepo : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public ICategory Category { get; private set; }

        public IProduct Product { get; private set; }

        public ICart Carts { get; private set; }

        

        public ICartItems CartItems {  get; private set; }


        public UnitOfWorkRepo(ApplicationDbContext context)
        {
            _context = context;
            Category = new CategoryRepo(context);
            Product = new ProductRepo(context);
            CartItems = new CartItemRepo(context);
            Carts = new CartRepo(context);
            
            
        }


        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
