using Octokit;
using Shopping.Data;
using Shopping.Models;
using Shopping.Repository.Interface;

namespace Shopping.Repository.Class
{
    public class CategoryRepo : RepositoryRepo<Category>, ICategory
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;

        }

        public void Update(Category category)
        {
            var categoryDB = _context.Categories.FirstOrDefault(x => x.Id == category.Id);
            if (categoryDB != null)
            {
                categoryDB.Name = category.Name;
                categoryDB.DisplayOrder = category.DisplayOrder;
            }
        }
    }
}
