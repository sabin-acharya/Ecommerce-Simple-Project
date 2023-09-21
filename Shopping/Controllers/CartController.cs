using Microsoft.AspNetCore.Mvc;
using Shopping.Data;
using Shopping.Models;
using Shopping.ViewModel;
using Shopping.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Octokit;
using Microsoft.AspNetCore.Identity;
using Shopping.Data.Migrations;

namespace Shopping.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<Data.ApplicationUser> _userManager;
        private string id;

        public CartController(ApplicationDbContext context, IUnitOfWork unitOfWork, UserManager<Data.ApplicationUser> userManager)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _userManager = userManager;

        }
        
        //public IActionResult ListItems(int id)
        //{

        //}
       
        public async Task<IActionResult> Index()
        {
            var ap = await _userManager.GetUserAsync(User);
          var  id= ap.Id;
            ProductVM provm = new ProductVM();
            provm.Products = _unitOfWork.Product.GetAll();
            
            if (ap != null)
            {
                // Assuming that you have a method to retrieve cart items by UserId
                var cartItems = _unitOfWork.CartItems.GetUserCartItems(id, includeProperties:"Products");

                if (cartItems != null)
                {
                    CartViewModel cvm = new CartViewModel();
                    cvm.CartItems = cartItems;
                  
                    return View(cvm);
                }
            }

            // Handle the case where the user is not authenticated or has no cart items
            return RedirectToAction("AddCart");
        }

        [HttpGet]
        public async Task<IActionResult> AddCart(int id)
        {

            CartViewModel cartvm = new CartViewModel();
            cartvm.CartItem.Product = _unitOfWork.Product.GetT(x => x.Id == id);
            if (cartvm != null)
            {
                return View(cartvm);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCart(int id, int quantity)
        {
            if (!User.Identity.IsAuthenticated)
            {

                return RedirectToAction("Login");
            }

            var ap = await _userManager.GetUserAsync(User);
            var products = _unitOfWork.Product.GetT(x => x.Id == id);

            var cart = _unitOfWork.Carts.GetT(x => x.UserId == ap.Id);

            if (cart == null)
            {
                cart = new Cart
                {
                    UserId = ap.Id
                };
                _unitOfWork.Carts.Add(cart);
                _unitOfWork.Save();
            }

            var cartItem = new CartItem
            {
                ProductId = id,
                Quantity = quantity,
                TotalPrice = (long)(quantity * products.Price),
                CartId = cart.Id


              };

            _unitOfWork.CartItems.Add(cartItem);
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Remove(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var cart = _unitOfWork.CartItems.GetT(x => x.Id == id);
            if (cart == null)
            {
                return NotFound();
            }
            return View(cart);
        }


        [HttpPost]
        public IActionResult Removepo(int id)
        {
            var cart = _unitOfWork.CartItems.GetT(x => x.Id == id);
            if (cart == null || id == 0)
            {
                return NotFound();
            }
            _unitOfWork.CartItems.Delete(cart);
            _unitOfWork.Save();
            TempData["success"] = "Deleted Done";
            return RedirectToAction("Index");

        }
        

        //public IActionResult Buy(int id)
        //{

        //}






    }
    
}
