using Shopping.Models;

namespace Shopping.Repository.Interface
{
    public interface IBuy : IRepository<Buy>
    {
        void Update(Buy buy);
    }
}
