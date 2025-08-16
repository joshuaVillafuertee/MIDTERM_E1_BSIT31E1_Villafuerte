using System.Collections.Generic;
using System.Linq;

namespace MIDTERM_E1_BSIT31E1_Villafuerte.Models
{
    public class AuthorService
    {
        // temporary in-memory list
        private static readonly List<Author> _authors = new()
        {
            new Author { Id = 1, Name = "George Orwell", Birthdate = new DateTime(1903, 6, 25), Biography = "British novelist", ProfileImageUrl="/images/orwell.jpg" },
            new Author { Id = 2, Name = "J.K. Rowling", Birthdate = new DateTime(1965, 7, 31), Biography = "British author", ProfileImageUrl="/images/rowling.jpg" }
        };

        public List<Author> GetAll() => _authors;

        public Author? GetById(int id) => _authors.FirstOrDefault(a => a.Id == id);

        public void Add(Author model)
        {
            var newId = _authors.Any() ? _authors.Max(b => b.Id) + 1 : 1;
            model.Id = newId;
            _authors.Add(model);
        }

        public void Update(Author model)
        {
            var a = GetById(model.Id);
            if (a == null) return;

            a.Name = model.Name;
            a.Birthdate = model.Birthdate;
            a.Biography = model.Biography;
            a.ProfileImageUrl = model.ProfileImageUrl;
        }

        public void Delete(int id)
        {
            var a = GetById(id);
            if (a != null) _authors.Remove(a);
        }
    }
}
