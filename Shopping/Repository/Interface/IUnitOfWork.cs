namespace Shopping.Repository.Interface
{
    public interface IUnitOfWork
    {
        
            ICategory Category { get; }
            IProduct Product { get; }
            ICart Carts { get; }

           ICartItems CartItems { get; }
       
            void Save();

        
    }
}
