using Octokit;
using Shopping.Data;
using Shopping.Models;
using Shopping.Repository.Interface;

namespace Shopping.Repository.Class
{
    public class LocationRepo : RepositoryRepo<LocationModel>, ILocationRepo
    {
        private readonly ApplicationDbContext _context;
        public LocationRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;

        }

        public void Update(LocationModel location)
        {
            
                var buyDB = _context.Buys.FirstOrDefault(x => x.Id == location.Id);
                if (buyDB != null)
                {
                    buyDB.CustomerName = location.CustomerName;
                    buyDB.PhoneNumber = location.PhoneNumber;
                    buyDB.Address = location.Address;
                    buyDB.City = location.City;
                    buyDB.FloorNo = location.FloorNo;
                    buyDB.State = location.State;
                    buyDB.PinCode = location.PinCode;
                    buyDB.StreetName = location.StreetName;


                }
            
        }
        //List<LocationModel> IBuy.GetBuy(int Id, string includeProperties)
        //{
        //    return _context.Buys
        //   .Where(buy => buy.OrderId == Id)
        //   .ToList();
        //}
    }
}
