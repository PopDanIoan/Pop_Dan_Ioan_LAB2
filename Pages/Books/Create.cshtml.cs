using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pop_Dan_Ioan_LAB2.Data;
using Pop_Dan_Ioan_LAB2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace Pop_Dan_Ioan_LAB2.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly Pop_Dan_Ioan_LAB2.Data.Pop_Dan_Ioan_LAB2Context _context;

        public CreateModel(Pop_Dan_Ioan_LAB2.Data.Pop_Dan_Ioan_LAB2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Book.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
