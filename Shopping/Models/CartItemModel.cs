using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.Models
{
    public class CartItemModel
    {
        
         public int Id { get; set; }
         public int ProductId { get; set; }
        

        public ProductModel? Product {  get; set; }

        [Required]
      
        public int Quantity { get; set; }
        
        public long TotalPrice { get; set; }    

        public int CartId { get; set; }
        [ForeignKey("CartId")]
        public CartModel? Cart { get; set; }



    }
}
