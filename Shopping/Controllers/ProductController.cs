using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shopping.Models;
using Shopping.Repository.Interface;
using Shopping.ViewModel;
namespace Shopping.Controllers
{
    [Authorize(Roles = "Admin")]
    
    public class ProductController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
            
        }
        public IActionResult AllProduct()
        {
            var products = _unitOfWork.Product.GetAll(includeProperties: "Category");
            return Json(new { data = products });
        }
        public IActionResult Index()
        {
            ProductVM productVM = new ProductVM();
            productVM.Products = _unitOfWork.Product.GetAll();
           return View(productVM);
        }

        [HttpGet]
        public IActionResult CreateUpdate(int? id) 
        {
            ProductVM vm = new ProductVM()
            {
                Product = new(),
                Categories = _unitOfWork.Category.GetAll().Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                })
            };

            if(id == null || id == 0)
            {
                return View(vm);
            }
            else
            {
                vm.Product = _unitOfWork.Product.GetT(x => x.Id == id);
				if (vm.Product == null)
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
        [ValidateAntiForgeryToken]
        public IActionResult CreateUpdate(ProductVM vm, IFormFile? file)
        {
            if(ModelState.IsValid)
            {
                string fileName = string.Empty;
                if (file != null)
                {
                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath,"ProductImage");
                    fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    string filePath = Path.Combine(uploadDir, fileName);

                    if (vm.Product.ImageUrl != null)
                    {
                        var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, vm.Product.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);

                        }
                    }
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    vm.Product.ImageUrl = @"\ProductImage\" + fileName;
                }
                if(vm.Product.Id ==  0)
                {
                    _unitOfWork.Product.Add(vm.Product);
                    TempData["success"] = " Product Created Done!";
                }
                else
                {
                    _unitOfWork.Product.Update(vm.Product);
                    TempData["success"] = "Product Update Done!";
                }
                _unitOfWork.Save();
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index"); 
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var product = _unitOfWork.Product.GetT(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var product = _unitOfWork.Product.GetT(x => x.Id == id);
            if (product == null || id == 0)
            {
                return NotFound();
            }
            _unitOfWork.Product.Delete(product);
            _unitOfWork.Save();
            TempData["success"] = "category Deleted Done";
            return RedirectToAction("Index");
            //var product = _unitOfWork.Product.GetT(x => x.Id == id);
            //if (product == null)
            //{
            //    return RedirectToAction("index");
            //}
            //else
            //{
            //    var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, product.ImageUrl.TrimStart('\\'));

            //    if (System.IO.File.Exists(oldImagePath))
            //    {
            //        System.IO.File.Delete(oldImagePath);
            //    }
            //    _unitOfWork.Product.Delete(product);
            //    _unitOfWork.Save();
            //    return RedirectToAction("index");

            //}

        }
    }
}
