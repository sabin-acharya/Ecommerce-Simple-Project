using Shopping.Models;

namespace Shopping.ViewModel
{
    public class CategoryVM
    {
        public Category Category { get; set; } = new Category();//single category


        public IEnumerable<Category> Categories { get; set; } = new List<Category>(); //list of category
    }
}
