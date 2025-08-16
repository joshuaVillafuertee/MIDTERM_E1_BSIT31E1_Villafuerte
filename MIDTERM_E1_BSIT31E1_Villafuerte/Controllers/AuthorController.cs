using Microsoft.AspNetCore.Mvc;
using MIDTERM_E1_BSIT31E1_Villafuerte.Models;

namespace MIDTERM_E1_BSIT31E1_Villafuerte.Controllers
{
    public class AuthorController : Controller
    {
        private readonly AuthorService _service;

        public AuthorController()
        {
            _service = new AuthorService();
        }

        public IActionResult Index()
        {
            return View(_service.GetAll());
        }

        public IActionResult Details(int id)
        {
            var author = _service.GetById(id);
            if (author == null) return NotFound();
            return View(author);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Author model)
        {
            if (ModelState.IsValid)
            {
                _service.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var a = _service.GetById(id);
            if (a == null) return NotFound();
            return View(a);
        }

        [HttpPost]
        public IActionResult Edit(Author model)
        {
            if (ModelState.IsValid)
            {
                _service.Update(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var a = _service.GetById(id);
            if (a == null) return NotFound();
            return View(a);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
