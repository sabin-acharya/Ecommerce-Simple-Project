using Shopping.Models;

namespace Shopping.Repository.Interface
{
    public interface ILocationRepo : IRepositoryRepo<LocationModel>
    {
        void Update(LocationModel location);
       // List<LocationModel> GetBuy(int Id, string includeProperties);
    }
}
