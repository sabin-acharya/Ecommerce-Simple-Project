using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shopping.Data;
using Shopping.Data.Migrations;
using Shopping.Repository.Interface;
using Shopping.ViewModel;
using CategoryVM = Shopping.ViewModel.CategoryVM;

namespace Shopping.Areas.Admin.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: Admin/Categories
        
        public async Task<IActionResult> Index()
        {
            CategoryVM categoryVM = new CategoryVM();
            categoryVM.Categories = _unitOfWork.Category.GetAll();
            return View(categoryVM);

        }

        // GET: Admin/Categories/Details/5
        [HttpGet]
        
        public IActionResult CreateUpdate(int? id)
        {
            CategoryVM vm = new CategoryVM();
            if (id == null || id == 0)
            {
                return View(vm);
            }
            else
            {
                vm.Category = _unitOfWork.Category.GetT(x => x.Id == id);
                if (vm.Category == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(vm);
                }
            }
        }
        //[HttpGet]
        //public IActionResult Update(int id)
        //{
        //    CategoryVM vm = new CategoryVM();
        //    if (id == null || id == 0)
        //    {
        //        return View(vm);
        //    }
        //    else
        //    {
        //        vm.Category = _unitOfWork.Category.GetT(x => x.Id == id);
        //        if (vm.Category == null)
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            return View(vm);
        //        }
        //    }
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Update(CategoryVM ca)
        //{

        //}




        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUpdate(CategoryVM vm)
        {
            if (ModelState.IsValid)
            {
                if (vm.Category.Id == 0)
                {
                    _unitOfWork.Category.Add(vm.Category);
                    TempData["success"] = "Category Created Done";

                }
                else
                {
                    _unitOfWork.Category.Update(vm.Category);
                    TempData["success"] = "Category Updated Done";
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
            var category = _unitOfWork.Category.GetT(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var category = _unitOfWork.Category.GetT(x => x.Id == id);
            if (category == null || id == 0)
            {
                return NotFound();
            }
            _unitOfWork.Category.Delete(category);
            _unitOfWork.Save();
            TempData["success"] = "category Deleted Done";
            return RedirectToAction("Index");

        }
    }
}
