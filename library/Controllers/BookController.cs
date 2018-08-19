using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using library.Models;
using library.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace library.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryRepository _categoryRepository;

        public BookController(IBookRepository bookRepository, ICategoryRepository categoryRepository)
        {
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult List(string category)
        {
            IEnumerable<Book> books;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                books = _bookRepository.Books.OrderBy(b => b.BookId);
                currentCategory = "All books";
            }
            else
            {
                books = _bookRepository.Books.Where(b => b.Category.CategoryName == category)
                   .OrderBy(b => b.BookId);
                currentCategory = _categoryRepository.Categories.FirstOrDefault(c => c.CategoryName == category).CategoryName;
            }

            return View(new BooksListViewModel
            {
                Books = books,
                CurrentCategory = currentCategory
            });
        }

        public IActionResult Details(int id)
        {
            var book = _bookRepository.getBookById(id);
            if (book == null)
                return NotFound();

            return View(book);
        }
    }
}
