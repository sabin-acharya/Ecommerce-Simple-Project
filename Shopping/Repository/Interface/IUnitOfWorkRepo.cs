using Shopping.Services;

namespace Shopping.Repository.Interface
{
    public interface IUnitOfWorkRepo
    {
        
            ICategoryRepo Category { get; }
            IProductRepo Product { get; }
            ICartRepo Carts { get; }
            
             IBuyCartIdRepo BuyCartId { get; }

            ICartItemsRepo CartItems { get; }
            
            IOrderRepo Order { get; }
            ILocationRepo Locations { get; }
            IEmailServicesRepo EmailServices { get; }
            void Save();

        
    }
}
