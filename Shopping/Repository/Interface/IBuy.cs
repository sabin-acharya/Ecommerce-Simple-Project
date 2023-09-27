using Shopping.Models;

namespace Shopping.Repository.Interface
{
    public interface IBuy : IRepository<BuyModel>
    {
        void Update(BuyModel buy);
        List<BuyModel> GetBuy(int Id, string includeProperties);
    }
}
