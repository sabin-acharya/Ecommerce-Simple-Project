﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.Models
{
    public class CartItem
    {
        
         public int Id { get; set; }
         public int ProductId { get; set; }
        
        [Required]
        public Product? Product {  get; set; }

        [Required]
      
        public int Quantity { get; set; }
        
        public long TotalPrice { get; set; }    

        public int CartId { get; set; }
        [ForeignKey("CartId")]
        public Cart? Cart { get; set; }

    }
}