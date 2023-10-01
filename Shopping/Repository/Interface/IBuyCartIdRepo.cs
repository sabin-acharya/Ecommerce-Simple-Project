using Shopping.Models;

namespace Shopping.Repository.Interface
{
    
    
        public interface IBuyCartIdRepo : IRepositoryRepo<BuyCartIdModel>
        {
            void Update(BuyCartIdModel buycartid);

           

        }
    
}
