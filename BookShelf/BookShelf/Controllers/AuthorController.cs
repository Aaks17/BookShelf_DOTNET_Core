using BookShelf.Data.Interfaces;
using BookShelf.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShelf.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var authors = _unitOfWork.Authors.GetAll().OrderBy(x => x.Name).ToList();
            if (authors.Count == 0)
            {
                ViewBag.NoData = "No items found.Try adding one.";
            }
            return View(authors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Author obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Authors.Add(obj);
                if (_unitOfWork.Save())
                    TempData["Message"] = "Added";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            return View(_unitOfWork.Authors.GetAuthor(id));
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteAuthor(int id)
        {
            if (ModelState.IsValid)
            {
                if (_unitOfWork.Authors.GetAuthor(id) == null)
                {
                    TempData["Message"] = "NotExists";
                    return RedirectToAction("Index");
                }
                Author data = _unitOfWork.Authors.GetAuthor(id);
                if (data != null)
                {
                    _unitOfWork.Authors.Delete(data);
                    _unitOfWork.Save();
                    TempData["Message"] = "Deleted";
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            return View(_unitOfWork.Authors.GetAuthor(id));
        }

        [HttpPost]
        [ActionName("Edit")]
        public IActionResult EditAuthor(Author obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Authors.UpdateAuthor(obj);
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
