using Shopping.Models;

namespace Shopping.Repository.Interface
{
    public interface IProductRepo : IRepositoryRepo<ProductModel>

    {
        void Update(ProductModel product);
    }
}
