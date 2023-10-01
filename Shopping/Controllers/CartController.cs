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
        private readonly IUnitOfWorkRepo _unitOfWork;
        private readonly UserManager<Data.ApplicationUser> _userManager;
        private string id;

        public CartController(ApplicationDbContext context, IUnitOfWorkRepo unitOfWork, UserManager<Data.ApplicationUser> userManager)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _userManager = userManager;

        }
        
        
       
        public async Task<IActionResult> CartIndex()
        {
            var ap = await _userManager.GetUserAsync(User);
          var  id= ap.Id;
            ProductVM provm = new ProductVM();
            provm.Products = _unitOfWork.Product.GetAll();
            
            if (ap != null)
            {
                // retrieve cart items by UserId
                var cartItems = _unitOfWork.CartItems.GetUserCartItems(id, includeProperties:"Products");
                
                if (cartItems != null)
                {
                    CartViewModel cvm = new CartViewModel();
                    cvm.CartItems = cartItems;
                    //_unitOfWork.orders.Add(cvm.CartItem);
                    //_unitOfWork.Save();
                    return View(cvm);
                }
            }

            return RedirectToAction("CartAddCart");
        }




        [HttpGet]
        public async Task<IActionResult> CartAddCart(int id)
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
        public async Task<IActionResult> CartAddCart(CartViewModel cvm, int id, int quantity)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login");
            }

            var user = await _userManager.GetUserAsync(User);
            var product = _unitOfWork.Product.GetT(x => x.Id == id);
            var cart = _unitOfWork.Carts.GetT(x => x.UserId == user.Id);
            //Checking if the userID exist or not
            if (cart == null)
            {
                cart = new CartModel
                {
                    UserId = user.Id
                };
                _unitOfWork.Carts.Add(cart);
                _unitOfWork.Save();
            }


            // Check if the product already exists in the cart
            var cartItem = _unitOfWork.CartItems.GetT(x => x.ProductId == id && x.CartId == cart.Id);

            if (cartItem == null)
            {
                // If the cart item doesn't exist, create a new one
                cartItem = new CartItemModel
                {
                    ProductId = id,
                    Quantity = quantity,
                    CartId = cart.Id,
                    TotalPrice = (long)(quantity * product.Price)
                };
                _unitOfWork.CartItems.Add(cartItem);
                _unitOfWork.Save();
            }
            else
            {
                // If the cart item already exists,
                cartItem.Quantity += quantity;
                cartItem.TotalPrice = (long)(cartItem.Quantity * product.Price);
            }

            _unitOfWork.Save();

            // Create an order for the cart item
            OrderModel order = new OrderModel
            {
                CartItemsId = cartItem.Id,
                UserId = user.Id
            };

            _unitOfWork.Order.Add(order);
            _unitOfWork.Save();

            TempData["CartItem_Id"] = cartItem.Id;

            _unitOfWork.Save();
            return RedirectToAction(nameof(CartIndex));
        }




        [HttpGet]
        public IActionResult CartRemove(int? id)
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
        public IActionResult CartRemove(int id)
        {
            var cart = _unitOfWork.CartItems.GetT(x => x.Id == id);
            if (cart == null || id == 0)
            {
                return NotFound();
            }
            _unitOfWork.CartItems.Delete(cart);
            _unitOfWork.Save();
            TempData["success"] = "Deleted Done";
            return RedirectToAction("CartIndex");
        }
        
       

    }
    
}
