using BookShelf.Data;
using BookShelf.Data.Interfaces;
using BookShelf.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShelf.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var categories = _unitOfWork.Categories.GetAll().OrderBy(x=>x.DisplayOrder).ToList();
            if (categories.Count == 0)
            {
                ViewBag.NoData = "No items found.Try adding one.";
            }
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                if (_unitOfWork.Categories.GetAll().Count(x => x.DisplayOrder == obj.DisplayOrder)>0)
                {
                    ModelState.AddModelError("", "Display Order already exists");
                    return View(obj);
                }
                _unitOfWork.Categories.Add(obj);
                if(_unitOfWork.Save())
                TempData["Message"] = "Added";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            return View(_unitOfWork.Categories.GetCategory(id));
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteCategory(int id)
        {
            if (ModelState.IsValid)
            {
                if (_unitOfWork.Categories.GetCategory(id)==null)
                {
                    TempData["Message"] = "NotExists";
                    return RedirectToAction("Index");
                }
                Category data = _unitOfWork.Categories.GetCategory(id);
                if (data != null)
                {
                    _unitOfWork.Categories.Delete(data);
                    _unitOfWork.Save();
                    TempData["Message"] = "Deleted";
                    return RedirectToAction("Index");
                }                
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            return View(_unitOfWork.Categories.GetCategory(id));
        }

        [HttpPost]
        [ActionName("Edit")]
        public IActionResult EditCategory(Category obj)
        {
            if (ModelState.IsValid)
            {
                if (_unitOfWork.Categories.GetAll().Count(x => x.DisplayOrder == obj.DisplayOrder) > 0)
                {
                    ModelState.AddModelError("", "Display Order already exists");
                    return View(obj);
                }
                _unitOfWork.Categories.UpdateCategory(obj);
                if (_unitOfWork.Save())
                {
                    TempData["Message"] = "Updated";
                    return RedirectToAction("Index");
                }
            }
            return View(obj);
        }

    }
}
