using System.Collections.Generic;

namespace library.Models
{
    public interface IBookRepository
    {
        IEnumerable<Book> Books { get; }
        IEnumerable<Book> BooksOfTheWeek { get; }

        Book getBookById(int bookid);
    }
}