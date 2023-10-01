using Shopping.Data;
using Shopping.Data.Migrations;
using Shopping.Repository.Interface;
using Shopping.Services;

namespace Shopping.Repository.Class
{
    public class UnitOfWorkRepo : IUnitOfWorkRepo
    {
        private readonly ApplicationDbContext _context;
        public ICategoryRepo Category { get; private set; }

        public IProductRepo Product { get; private set; }

        public ICartRepo Carts { get; private set; }

        public ILocationRepo Locations { get; private set; }

        public IEmailServicesRepo EmailServices { get; private set; }
        
        public IOrderRepo Order { get; private set; }
        public ICartItemsRepo CartItems {  get; private set; }

        public IBuyCartIdRepo BuyCartId { get; private set; }


        public UnitOfWorkRepo(ApplicationDbContext context)
        {
            _context = context;
            Category = new CategoryRepo(context);
            Product = new ProductRepo(context);
            CartItems = new CartItemRepo(context);
            Carts = new CartRepo(context);
            Locations = new LocationRepo(context);
            Order = new OrderRepo(context);
            EmailServices = new EmailServicesRepo(context);
            BuyCartId = new BuyCartIdRepo(context);
            
        }


        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
