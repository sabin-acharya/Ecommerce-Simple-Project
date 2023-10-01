using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Shopping.Models;
using Shopping.Repository.Interface;
using Shopping.ViewModel;
using System.Diagnostics;

namespace Shopping.Areas.Customer.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWorkRepo _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWorkRepo unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult HomeIndex()
        {
            ProductVM productvm = new ProductVM();
            productvm.Products = _unitOfWork.Product.GetAll();
            return View(productvm);
        }

        public IActionResult HomePrivacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //[HttpGet]
        //public IActionResult AddCart(int id)
        //{
        //    Cart cart = new Cart();
        //    cart.CartItems = _unitOfWork.cartItems
        //    if (.Product != null)
        //    {
        //        return View(prodvm);
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}

        //[HttpPost]
        //public IActionResult AddCart(Product productToAdd, int id)
        //{

        //    productToAdd = _unitOfWork.Product.GetT(x => x.Id == id);
        //    Cart cart = new Cart();


        //    if (productToAdd != null)
        //    {

        //        cart.CartItems.Add(productToAdd);
        //        _unitOfWork.Save();
        //    }

        //    return RedirectToAction("Index");
        //}
    }
       
}