using Microsoft.AspNetCore.Mvc.Rendering;
using Shopping.Models;

namespace Shopping.ViewModel
{
    public class BuyVM
    {
        public BuyModel Buy { get; set; } = new BuyModel();


        public IEnumerable<BuyModel> Buys { get; set; } = new List<BuyModel>();


    }
}
