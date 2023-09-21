using Microsoft.AspNetCore.Mvc;
using Shopping.Repository.Interface;
using Shopping.ViewModel;

namespace Shopping.Controllers
{
    public class OrderController : Controller
    {

        private readonly IUnitOfWork _unitofwork;
        public OrderController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public IActionResult Index(int? id)
        {


            var order = _unitofwork.Order.GetAll();
            
           
            _unitofwork.Save();
            return View();
        }

        [HttpGet]
        public IActionResult SaveOrder(int? id) 
        {
            OrderVM vm = new OrderVM();
           
            if (id == null || id == 0)
            {
                return View(vm);
            }
            else
            {
                vm.Order = _unitofwork.Order.GetT(x => x.Id == id);
                if (vm.Order == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(vm);
                }
            }
        }

        [HttpPost]
        public IActionResult SaveOrder(OrderVM orderVM, int id)
        {
            if(ModelState.IsValid)
            {
                OrderVM ordervm = new OrderVM();
                ordervm.Order = _unitofwork.Order.GetT(x => x.Id == id);
                 var item = _unitofwork.CartItems.GetT(x => x.Id == id);
                
                if(ordervm.Order.CartItemsId == null)
                {
                    ordervm.Order.CartItemsId = item.Id;
                    _unitofwork.Save();
                }

              
                _unitofwork.Save();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
