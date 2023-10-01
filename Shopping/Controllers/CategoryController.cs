using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shopping.Data;
using Shopping.Data.Migrations;
using Shopping.Repository.Interface;
using Shopping.ViewModel;
using CategoryVM = Shopping.ViewModel.CategoryVM;

namespace Shopping.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWorkRepo _unitOfWork;

        public CategoryController(ApplicationDbContext context, IUnitOfWorkRepo unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: Admin/Categories
        
        public async Task<IActionResult> CategoryIndex()
        {
            CategoryVM categoryVM = new CategoryVM();
            categoryVM.Categories = _unitOfWork.Category.GetAll();
            return View(categoryVM);

        }

       
        [HttpGet]
        
        public IActionResult CategoryCreateUpdate(int? id)
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
        public IActionResult CategoryCreateUpdate(CategoryVM vm)
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
                return RedirectToAction("CategoryIndex");

            }
            return RedirectToAction("CategoryIndex");
        }
        [HttpGet]
        public IActionResult CategoryDelete(int? id)
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
        [HttpPost, ActionName("CategoryDelete")]
        [ValidateAntiForgeryToken]
        public IActionResult CategoryDelete(int id)
        {
            var category = _unitOfWork.Category.GetT(x => x.Id == id);
            if (category == null || id == 0)
            {
                return NotFound();
            }
            _unitOfWork.Category.Delete(category);
            _unitOfWork.Save();
            TempData["success"] = "category Deleted Done";
            return RedirectToAction("CategoryIndex");

        }
    }
}
