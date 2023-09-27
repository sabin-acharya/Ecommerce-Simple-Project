using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shopping.Models;

namespace Shopping.ViewModel
{
    public class ProductVM
    {
        public ProductModel Product { get; set; } = new ProductModel();//single category

        [ValidateNever]
        public IEnumerable<ProductModel> Products { get; set; } = new List<ProductModel>(); //list of category

        public IEnumerable<SelectListItem>? Categories { get; set; }

    }
}
