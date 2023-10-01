using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.Models
{
    public class BuyCartIdModel
    {
        public int Id { get; set; }

        public int CartItemId { get; set; }
        
        [ForeignKey("CartItemId")]

        public CartItemModel? CartItemModel { get; set; }

        public int LocationId { get; set; }
        [ForeignKey("LocationId")]
        public LocationModel? LocationModel { get; set; }

    }
}
