using Shopping.Models;

namespace Shopping.Repository.Interface
{
    public interface IProduct : IRepository<Product>

    {
        void Update(Product product);
    }
}
