using Shopping.Data;

namespace Shopping.Models
{
    public class ReviewModel
    {
        public int Id { get; set; }

        public string? UserID { get; set; }
        public ApplicationUser User { get; set; }

        public int ProductID { get; set; }

        public ProductModel ProductName { get; set; }

        public string Rating { get; set; }

        public string ReviewText { get; set; }
    }
}
