using Microsoft.AspNetCore.Mvc;
using Shopping.Data.Migrations;
using Shopping.Models;
using Shopping.Repository.Interface;
using Shopping.ViewModel;

namespace Shopping.Controllers
{
    
    public class LocationController : Controller
    {
        private readonly IUnitOfWorkRepo _unitofwork;
        

        public LocationController(IUnitOfWorkRepo unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public IActionResult LocationIndex()
        {
            return View();
        }

       
        public IActionResult LocationSaveOrder(int? id)
        {
            CartItemModel ci = new CartItemModel();
            id = ci.Id;
            LocationVM vm = new LocationVM();
            ViewBag.CartItemId = id;
            if (id != null )
            {
                return View(vm);
            }
            return View();
            
        }
        [HttpPost]
        public IActionResult LocationSaveOrder(LocationVM lovm)
        {
            if (lovm.Location != null)
            {

                if (lovm.Location.Id == 0)
                {
                    _unitofwork.Locations.Add(lovm.Location);
                    TempData["success"] = "Location Added Done";
                }
                else
                {
                    _unitofwork.Locations.Update(lovm.Location);
                    TempData["success"] = "Location Updated Done";
                }
                _unitofwork.Save();

            }
            
            else
            {
                return NotFound();
            };

            var Id = TempData["CartItem_Id"] as int?;

            BuyCartIdModel buyCartIdModel = new BuyCartIdModel
            {
                CartItemId = (int) Id,
                LocationId = lovm.Location.Id

            };
            _unitofwork.BuyCartId.Add(buyCartIdModel);
            _unitofwork.Save();

            CartViewModel cartViewModel = new CartViewModel();
            cartViewModel.CartItem = _unitofwork.CartItems.GetT( x => x.Id == Id );
            _unitofwork.CartItems.Delete(cartViewModel.CartItem);
            _unitofwork.Save();

            return RedirectToAction("CartIndex", "Cart");
        }


       

    }
}
