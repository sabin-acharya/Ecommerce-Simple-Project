using Microsoft.AspNetCore.Mvc;
using Shopping.Data.Migrations;
using Shopping.Models;
using Shopping.Repository.Interface;
using Shopping.ViewModel;

namespace Shopping.Controllers
{
    public class BuyController : Controller
    {
        private readonly IUnitOfWork _unitofwork;
        public BuyController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SaveOrder(int? id)
        {
           
            BuyVM vm = new BuyVM();
            ViewBag.CartItemId = id;
            if (id != null || id != 0)
            {
                return View(vm);
            }
            return View();
            //else
            //{
            //    vm.Buy = _unitofwork.Buys.GetT(x => x.Id == id);
            //    if (vm.Buy == null)
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        return View(vm);
            //    }
            //}
        }
        [HttpPost]
        public IActionResult SaveOrder([FromBody]BuyVM buyvm, int Id)
        {
            //if (ModelState.IsValid && buyvm != null && buyvm.Buy != null)
            //{
            //    CartViewModel cart = new CartViewModel();

            //    var cartItems = _unitofwork.CartItems.GetUserCartItems(id,  includeProperties: "Products");
            //    buyvm.Buy.CartItemId = cart.CartItem.Id;
            //    if (buyvm.Buy.Id == 0)
            //    {
            //        _unitofwork.Buys.Add(buyvm.Buy);
            //        TempData["success"] = "Category Created Done";
             
            //    }

            //    _unitofwork.Save();
            //    return RedirectToAction("Index");

            //}
            Id = buyvm.Buy.CartItemId;
            if(Id == 0) 
            { 
                CartViewModel cvm = new CartViewModel();
                cvm.CartItems = _unitofwork.CartItems.GetAll();
                foreach (var cartItem in cvm.CartItems)
                {
                     Id = cartItem.Id;
                    
                    _unitofwork.Save();
                }
            }

            _unitofwork.Buys.Add(buyvm.Buy);
            _unitofwork.Save();
            return RedirectToAction("Index");
        }
            //{
            //    int id = buyvm.Buy.Id;

            //    // Check if 'buy' and 'Cartitem' are not null before accessing their properties
            //    var buy = _unitofwork.Buys.GetT(x => x.Id == id);
            //    var Cartitem = _unitofwork.CartItems.GetT(x => x.Id == id);

            //    if (buy != null && Cartitem != null)
            //    {
            //        id = buy.CartItemId;

            //        if (id == 0)
            //        {
            //            buy.CartItemId = Cartitem.Id;

            //            _unitofwork.Buys.Add(buy);
            //            _unitofwork.Save();
            //        }
            //    }
            

            
        

    }
}
