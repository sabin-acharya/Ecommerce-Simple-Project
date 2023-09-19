using Shopping.Models;

namespace Shopping.Repository.Interface
{
    public interface ICategory : IRepository<Category>
    {
        void Update(Category category);
    }
}
