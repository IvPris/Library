using library.Models;
using System.Collections.Generic;

namespace library.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Book> BooksOfTheWeek { get; set; }
    }
}