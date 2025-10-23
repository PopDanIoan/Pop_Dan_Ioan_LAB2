using System.ComponentModel.DataAnnotations;

namespace Pop_Dan_Ioan_LAB2.Models
{
    public class Author
    {
        public int ID { get; set; } 

        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;

        public ICollection<Book>? Books { get; set; }
    }
}
