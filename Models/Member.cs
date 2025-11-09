using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Pop_Dan_Ioan_LAB2.Models
{
    public class Member
    {
        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Adress { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }

        [Display(Name = "Full Name")]
        public string? FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        // Această linie a fost mutată ÎNĂUNTRUL clasei
        public ICollection<Borrowing>? Borrowings { get; set; }
    }
}