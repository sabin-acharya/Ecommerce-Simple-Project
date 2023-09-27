using Shopping.Models;

namespace Shopping.ViewModel
{
    public class OrderVM
    {
        public OrderModel Order { get; set; } = new OrderModel();

        public IEnumerable<OrderModel> Orders { get; set; } = new List<OrderModel>();
    }
}
