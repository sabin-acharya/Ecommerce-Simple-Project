using Shopping.Models;

namespace Shopping.ViewModel
{
    public class CategoryVM
    {
        public CategoryModel Category { get; set; } = new CategoryModel();//single category


        public IEnumerable<CategoryModel> Categories { get; set; } = new List<CategoryModel>(); //list of category
    }
}
