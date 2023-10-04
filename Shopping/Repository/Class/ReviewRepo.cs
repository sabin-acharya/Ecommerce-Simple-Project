using Shopping.Data;
using Shopping.Models;
using Shopping.Repository.Interface;

namespace Shopping.Repository.Class
{
    public class ReviewRepo : RepositoryRepo<ReviewModel>, IReviewRepo
    {
        private readonly ApplicationDbContext _context;
        public ReviewRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;

        }
        public void Update(ReviewModel review)
        {
            var reviewDB = _context.Reviews.FirstOrDefault(x => x.Id == review.Id);
            if (reviewDB != null)
            {
                reviewDB.ReviewText = review.ReviewText;
                reviewDB.Rating = review.Rating;
            }

        }
        public decimal GetRating(int id)
        {
           
            var review = _context.Reviews.FirstOrDefault(x => x.Id == id);

            if (review == null)
            {
                return 0;
            }

           
            decimal averageRating = (decimal)(_context.Reviews.Where(r => r.Id == id).Sum(r => r.Id) / _context.Reviews.Where(r => r.Id == id).Count());

            
            return averageRating;
        }


    }
}

