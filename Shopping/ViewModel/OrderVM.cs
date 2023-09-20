using Shopping.Models;

namespace Shopping.ViewModel
{
    public class OrderVM
    {
        public Order Order { get; set; } = new Order();

        public IEnumerable<Order> Orders { get; set; } = new List<Order>();
    }
}
