using Microsoft.AspNetCore.Mvc.Rendering;
using Shopping.Models;

namespace Shopping.ViewModel
{
    public class BuyVM
    {
        public Buy Buy { get; set; } = new Buy();


        public IEnumerable<Buy> Buys { get; set; } = new List<Buy>();


    }
}
