using Microsoft.AspNetCore.Mvc;
using Shopping.Repository.Interface;
using Shopping.ViewModel;

namespace Shopping.Controllers
{
    public class OrderController : Controller
    {

        private readonly IUnitOfWorkRepo _unitofwork;
        public OrderController(IUnitOfWorkRepo unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public IActionResult OrderIndex(int? id)
        {


            var order = _unitofwork.Order.GetAll();
            
           
            _unitofwork.Save();
            return View();
        }

        [HttpGet]
        public IActionResult OrderSaveOrder(int? id) 
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
        public IActionResult OrderSaveOrder(OrderVM orderVM, int id)
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
                return RedirectToAction("OrderIndex");
            }
            return RedirectToAction("OrderIndex");
        }
    }
}
