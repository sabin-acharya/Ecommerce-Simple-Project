using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Shopping.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Description { get; set; }
        
        public string? ImageUrl { get; set; }
        
        public double Price { get; set; }
        public int CategoryId { get; set; }
        [ValidateNever]
        public Category? Category { get; set; }

        //public int CartItemId { get; set; }
        //public CartItem? CartItem { get; set; }
    }
}
 