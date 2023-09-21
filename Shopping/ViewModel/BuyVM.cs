using Microsoft.AspNetCore.Mvc.Rendering;
using Shopping.Models;

namespace Shopping.ViewModel
{
    public class BuyVM
    {
        public int CartId { get; set; }

        public string CustomerName { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }


    }
}
