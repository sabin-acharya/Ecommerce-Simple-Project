using Shopping.Models;

namespace Shopping.Repository.Interface
{
    public interface IProduct : IRepository<ProductModel>

    {
        void Update(ProductModel product);
    }
}
