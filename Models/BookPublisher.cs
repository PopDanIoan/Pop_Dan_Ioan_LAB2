

namespace Pop_Dan_Ioan_LAB2.Models
{
    public class BookPublisher
    {
        public int ID { get; set; }
        public string PublisherName { get; set; } = null!;
        public ICollection<Book>? Books { get; set; }
    }
}
