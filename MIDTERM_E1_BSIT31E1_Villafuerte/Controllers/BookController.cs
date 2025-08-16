using Microsoft.AspNetCore.Mvc;
using MIDTERM_E1_BSIT31E1_Villafuerte.Models;

namespace MIDTERM_E1_BSIT31E1_Villafuerte.Controllers
{
    public class BookController : Controller
    {
        private readonly BookService _service;

        public BookController()
        {
            _service = new BookService();
        }

        // Show all books
        public IActionResult Index()
        {
            // Map Book ? BookListView
            var books = _service.GetAll()
                .Select(b => new BookListView
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Genre = b.Genre,
                    Copies = b.Copies,
                    ImageUrl = b.ImageUrl
                })
                .ToList();

            return View(books);
        }

        // Show details
        public IActionResult Details(int id)
        {
            var book = _service.GetById(id);
            if (book == null) return NotFound();
            return View(book);
        }

        // Add book (GET)
        [HttpGet]
        public IActionResult Add() => View();

        // Add book (POST)
        [HttpPost]
        public IActionResult Add(AddBookView model)
        {
            if (ModelState.IsValid)
            {
                _service.Add(model);
                TempData["Message"] = "Book added successfully!";
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // Edit book (GET)
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

        // Edit book (POST)
        [HttpPost]
        public IActionResult Edit(EditBookView model)
        {
            if (ModelState.IsValid)
            {
                _service.Update(model);
                TempData["Message"] = "Book updated successfully!";
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // Delete book (GET) - confirmation page
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var book = _service.GetById(id);
            if (book == null) return NotFound();
            return View(book);
        }

        // Delete book (POST)
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.Delete(id);
            TempData["Message"] = "Book deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}
