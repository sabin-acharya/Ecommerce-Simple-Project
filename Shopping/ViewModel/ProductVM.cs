using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shopping.Models;

namespace Shopping.ViewModel
{
    public class ProductVM
    {
        public Product Product { get; set; } = new Product();//single category

        [ValidateNever]
        public IEnumerable<Product> Products { get; set; } = new List<Product>(); //list of category

        public IEnumerable<SelectListItem>? Categories { get; set; }

    }
}
