namespace library.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public bool IsBookOfTheWeek { get; set; }
        public virtual Category Category { get; set; }
    }
}