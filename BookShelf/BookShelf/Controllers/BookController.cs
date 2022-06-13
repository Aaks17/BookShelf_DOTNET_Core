using BookShelf.Data.Interfaces;
using BookShelf.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookShelf.Controllers
{
    public class BookController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public BookController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var books = _unitOfWork.Books.GetAll(null, includeProperties: "Author,Category").OrderBy(x => x.Name).ToList();
            if (books.Count == 0)
            {
                ViewBag.NoData = "No items found.Try adding one.";
            }
            return View(books);
        }

        public IActionResult Create()
        {

            IEnumerable<SelectListItem> authorList = _unitOfWork.Authors.GetAll().Select(c => new SelectListItem()
            {
                Text = c.Name,
                Value = c.AuthorId.ToString()
            });
            IEnumerable<SelectListItem> categoryList = _unitOfWork.Categories.GetAll().Select(c => new SelectListItem()
            {
                Text = c.Name,
                Value = c.CategoryId.ToString()
            });
            ViewBag.AuthorList = authorList;
            ViewBag.CategoryList = categoryList;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Book obj)
        {
            _unitOfWork.Books.Add(obj);
            if (_unitOfWork.Save())
            {
                TempData["Message"] = "Added";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int id)
        {
            return View(_unitOfWork.Books.GetBook(id));
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteBook(int id)
        {
            if (ModelState.IsValid)
            {
                if (_unitOfWork.Books.GetBook(id) == null)
                {
                    TempData["Message"] = "NotExists";
                    return RedirectToAction("Index");
                }
                Book data = _unitOfWork.Books.GetBook(id);
                if (data != null)
                {
                    _unitOfWork.Books.Delete(data);
                    _unitOfWork.Save();
                    TempData["Message"] = "Deleted";
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            IEnumerable<SelectListItem> authorList = _unitOfWork.Authors.GetAll().Select(c => new SelectListItem()
            {
                Text = c.Name,
                Value = c.AuthorId.ToString()
            });
            IEnumerable<SelectListItem> categoryList = _unitOfWork.Categories.GetAll().Select(c => new SelectListItem()
            {
                Text = c.Name,
                Value = c.CategoryId.ToString()
            });
            ViewBag.AuthorList = authorList;
            ViewBag.CategoryList = categoryList;
            return View(_unitOfWork.Books.GetBook(id));
        }

        [HttpPost]
        [ActionName("Edit")]
        public IActionResult EditBook(Book obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Books.UpdateBook(obj);
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
