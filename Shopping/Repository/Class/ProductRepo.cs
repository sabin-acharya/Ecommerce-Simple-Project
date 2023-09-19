using Shopping.Data;
using Shopping.Models;
using Shopping.Repository.Interface;

namespace Shopping.Repository.Class
{

    public class ProductRepo : RepositoryRepo<Product>, IProduct
    {
        private readonly ApplicationDbContext _context;
        public ProductRepo(ApplicationDbContext context) : base(context)
        {

            _context = context;

        }

        public void Update(Product product)
        {
            var productDB = _context.Products.FirstOrDefault(x => x.Id == product.Id);
            if (productDB != null)
            {
                productDB.Name = product.Name;
                productDB.Description = product.Description;
                productDB.Price = product.Price;
                productDB.ImageUrl = product.ImageUrl;
                productDB.CategoryId = product.CategoryId;
            }
        }
    }
}
