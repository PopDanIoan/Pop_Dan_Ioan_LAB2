using Pop_Dan_Ioan_LAB2.Models;

namespace Pop_Dan_Ioan_LAB2.ViewModels
{
    public class CategoryIndexData
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}