using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pop_Dan_Ioan_LAB2.Data;
using Pop_Dan_Ioan_LAB2.Models;

namespace Pop_Dan_Ioan_LAB2.Pages.Borrowings
{
    public class EditModel : PageModel
    {
        private readonly Pop_Dan_Ioan_LAB2Context _context;

        public EditModel(Pop_Dan_Ioan_LAB2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Borrowing Borrowing { get; set; } = default!;

        public SelectList MemberSL { get; set; }
        public SelectList BookSL { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowing = await _context.Borrowing.FirstOrDefaultAsync(m => m.ID == id);
            if (borrowing == null)
            {
                return NotFound();
            }
            Borrowing = borrowing;

            var bookList = _context.Book
                .Include(b => b.Author)
                .Select(x => new {
                    x.ID,
                    BookFullName = x.Title + " - " + x.Author.FirstName + " " + x.Author.LastName
                });

            BookSL = new SelectList(bookList, "ID", "BookFullName", Borrowing.BookID);
            MemberSL = new SelectList(_context.Member, "ID", "FullName", Borrowing.MemberID);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Borrowing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Borrowing.Any(e => e.ID == Borrowing.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }
    }
}