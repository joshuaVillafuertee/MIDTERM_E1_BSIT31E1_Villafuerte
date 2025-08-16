using System.Collections.Generic;
using System.Linq;

namespace MIDTERM_E1_BSIT31E1_Villafuerte.Models
{
    public class BookService
    {
        // canonical in-memory store of "Book" entities
        private static readonly List<Book> _books = new()
        {
            new Book { Id = 1, Title = "1984", Author = "George Orwell", Genre = "Fiction", Copies = 1, ImageUrl = "/images/1984.jpg" },
            new Book { Id = 2, Title = "Harry Potter", Author = "J.K. Rowling", Genre = "Fantasy", Copies = 1, ImageUrl = "/images/harrypotter.jpg" },
            new Book { Id = 3, Title = "The Hobbit", Author = "J.R.R. Tolkien", Genre = "Fantasy", Copies = 1, ImageUrl = "/images/hobbit.jpg" }
        };

        // Return list view models for Index
        public List<BookListView> GetAll()
        {
            return _books
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
        }

        // NOTE: nullable return fixes "Possible null reference return"
        public Book? GetById(int id) => _books.FirstOrDefault(b => b.Id == id);

        public void Add(AddBookView model)
        {
            var newId = _books.Any() ? _books.Max(b => b.Id) + 1 : 1;
            var book = new Book
            {
                Id = newId,
                Title = model.Title,
                Author = model.Author,
                Genre = model.Genre,
                Copies = model.Copies,
                ImageUrl = string.IsNullOrWhiteSpace(model.ImageUrl) ? "/images/placeholder.png" : model.ImageUrl
            };
            _books.Add(book);
        }

        public void Update(EditBookView model)
        {
            var book = GetById(model.Id);
            if (book is null) return;

            book.Title = model.Title;
            book.Author = model.Author;
            book.Genre = model.Genre;
            book.Copies = model.Copies;
            book.ImageUrl = string.IsNullOrWhiteSpace(model.ImageUrl) ? "/images/placeholder.png" : model.ImageUrl;
        }

        public void Delete(int id)
        {
            var book = GetById(id);
            if (book is null) return;

            _books.Remove(book);
        }
    }
}
