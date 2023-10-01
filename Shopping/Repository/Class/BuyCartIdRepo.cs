using Shopping.Data;
using Shopping.Models;
using Shopping.Repository.Interface;

namespace Shopping.Repository.Class
{
    public class BuyCartIdRepo : RepositoryRepo<BuyCartIdModel>, IBuyCartIdRepo
    {
        private readonly ApplicationDbContext _context;
        public BuyCartIdRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;

        }

        public void Update(BuyCartIdModel buycartid)
        {
            throw new NotImplementedException();
        }
    }
}
