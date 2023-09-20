namespace Shopping.Repository.Interface
{
    public interface IUnitOfWork
    {
        
            ICategory Category { get; }
            IProduct Product { get; }
            ICart Carts { get; }

           ICartItems CartItems { get; }
            
        IOrder Order { get; }
            IBuy Buys { get; }
       
            void Save();

        
    }
}
