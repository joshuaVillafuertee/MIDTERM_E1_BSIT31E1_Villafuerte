using Microsoft.AspNetCore.Mvc;
using MIDTERM_E1_BSIT31E1_Villafuerte.Models;
using System.Linq;

namespace MIDTERM_E1_BSIT31E1_Villafuerte.Controllers
{
    public class BookController : Controller
    {
        private readonly BookService _service;

        public BookController()
        {
            _service = new BookService();
        }

        public IActionResult Index()
        {
            var books = _service.GetAll();
            return View(books);
        }

        public IActionResult Details(int id)
        {
            var book = _service.GetById(id);
            if (book == null) return NotFound();
            return View(book);
        }

        [HttpGet]
        public IActionResult Add() => View();

        [HttpPost]
        public IActionResult Add(AddBookView model)
        {
            if (!ModelState.IsValid) return View(model);
            _service.Add(model);
            TempData["Message"] = "Book added successfully!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = _service.GetById(id);
            if (book == null) return NotFound();

            var editModel = new EditBookView
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Genre = book.Genre,
                Copies = book.Copies,
                ImageUrl = book.ImageUrl
            };
            return View(editModel);
        }

        [HttpPost]
        public IActionResult Edit(EditBookView model)
        {
            if (!ModelState.IsValid) return View(model);
            _service.Update(model);
            TempData["Message"] = "Book updated successfully!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var book = _service.GetById(id);
            if (book == null) return NotFound();
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.Delete(id);
            TempData["Message"] = "Book deleted successfully!";
            return RedirectToAction("Index");
        }

        public IActionResult Archive(int id)
        {
            _service.Archive(id);
            TempData["Message"] = "Book archived successfully!";
            return RedirectToAction("Index");
        }

        public IActionResult ArchiveList()
        {
            var archived = _service.GetAllRaw()
                .Where(b => b.IsArchived)
                .Select(b => new BookListView
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Genre = b.Genre,
                    Copies = b.Copies,
                    ImageUrl = b.ImageUrl,
                    IsArchived = b.IsArchived
                })
                .ToList();

            return View(archived);
        }

        public IActionResult Restore(int id)
        {
            _service.Restore(id);
            TempData["Message"] = "Book restored successfully!";
            return RedirectToAction("ArchiveList");
        }
    }
}
