using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Pop_Dan_Ioan_LAB2.Models
{
    public class Book
    {
        public int ID { get; set; }

        [Display(Name = "Book Title")]
        public string Title { get; set; } = null!;

        public string Author { get; set; } = null!;

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishingDate { get; set; }
    
        public int? PublisherID { get; set; }
        public BookPublisher? Publisher { get; set; }
    }
}