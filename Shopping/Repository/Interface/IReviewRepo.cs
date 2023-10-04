using Shopping.Models;

namespace Shopping.Repository.Interface
{
    public interface IReviewRepo
    {
        public interface IReviewRepo : IRepositoryRepo<ReviewModel>
        {
            void Update(ReviewModel review);
            decimal GetRating(int id);
        }
    }
}
