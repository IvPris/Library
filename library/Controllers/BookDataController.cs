using library.Models;
using library.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace library.Controllers
{
    [Route("api/[controller]")]
    public class BookDataController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BookDataController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public IEnumerable<BookViewModel> LoadMoreBooks()
        {
            IEnumerable<Book> dbBooks = null;
            dbBooks = _bookRepository.Books.OrderBy(b => b.BookId).Take(6);
            List<BookViewModel> books = new List<BookViewModel>();

            foreach (var dbBook in dbBooks)
            {
                books.Add(MapDbBookToBookViewModel(dbBook));
            }
            return books;
        }

        private BookViewModel MapDbBookToBookViewModel(Book dbBook)
        {
            return new BookViewModel()
            {
                BookId = dbBook.BookId,
                Title = dbBook.Title,
                Author = dbBook.Author,
                Description = dbBook.Description,
                ImageUrl = dbBook.ImageUrl
            };
        }
    }
}