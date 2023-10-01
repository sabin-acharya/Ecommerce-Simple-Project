using Shopping.Models;

namespace Shopping.Repository.Interface
{
    public interface ICategoryRepo : IRepositoryRepo<CategoryModel>
    {
        void Update(CategoryModel category);
    }
}
