using Octokit;
using Shopping.Data;
using Shopping.Models;
using Shopping.Repository.Interface;

namespace Shopping.Repository.Class
{
    public class BuyRepo : RepositoryRepo<Buy>, IBuy
    {
        private readonly ApplicationDbContext _context;
        public BuyRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;

        }

        public void Update(Buy buy)
        {
            
                var buyDB = _context.Buys.FirstOrDefault(x => x.Id == buy.Id);
                if (buyDB != null)
                {
                    buyDB.CustomerName = buy.CustomerName;
                    buyDB.PhoneNumber = buy.PhoneNumber;
                    buyDB.Address = buy.Address;

                }
            
        }
        List<Buy> IBuy.GetBuy(int Id, string includeProperties)
        {
            return _context.Buys
           .Where(buy => buy.OrderId == Id)
           .ToList();
        }
    }
}
