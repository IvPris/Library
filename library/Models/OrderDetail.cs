namespace library.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int BookId { get; set; }
        public int Amount { get; set; }
        public virtual Book book { get; set; }
        public virtual Order order { get; set; }
    }
}