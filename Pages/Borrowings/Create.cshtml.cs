using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pop_Dan_Ioan_LAB2.Data;
using Pop_Dan_Ioan_LAB2.Models;

namespace Pop_Dan_Ioan_LAB2.Pages.Borrowings
{
    public class CreateModel : PageModel
    {
        private readonly Pop_Dan_Ioan_LAB2Context _context;

        public CreateModel(Pop_Dan_Ioan_LAB2Context context)
        {
            _context = context;
        }

        public SelectList MemberSL { get; set; }
        public SelectList BookSL { get; set; }

        public IActionResult OnGet()
        {
            var bookList = _context.Book
                .Include(b => b.Author)
                .Select(x => new {
                    x.ID,
                    BookFullName = x.Title + " - " + x.Author.FirstName + " " + x.Author.LastName
                });

            BookSL = new SelectList(bookList, "ID", "BookFullName");
            MemberSL = new SelectList(_context.Member, "ID", "FullName");
            return Page();
        }

        [BindProperty]
        public Borrowing Borrowing { get; set; }
            
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Borrowing.Add(Borrowing);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}