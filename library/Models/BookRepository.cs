using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace library.Models
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _appDbContext;

        public BookRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Book> Books
        {
            get
            {
                return _appDbContext.Books.Include(c => c.Category);
            }
        }

        public IEnumerable<Book> BooksOfTheWeek
        {
            get
            {
                return _appDbContext.Books.Include(c => c.Category).Where(b => b.IsBookOfTheWeek);
            }
        }

        public Book getBookById(int bookId)
        {
            return _appDbContext.Books.FirstOrDefault(b => b.BookId == bookId);
        }
    }
}
