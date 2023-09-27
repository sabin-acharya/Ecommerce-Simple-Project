using Shopping.Models;

namespace Shopping.Repository.Interface
{
    public interface ICategory : IRepository<CategoryModel>
    {
        void Update(CategoryModel category);
    }
}
