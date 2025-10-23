using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pop_Dan_Ioan_LAB2.Data;
using Pop_Dan_Ioan_LAB2.Models;

namespace Pop_Dan_Ioan_LAB2.Pages.Books
{
    public class CreateModel : BookCategoriesPageModel
    {
        private readonly Pop_Dan_Ioan_LAB2Context _context;

        public CreateModel(Pop_Dan_Ioan_LAB2Context context)
        {
            _context = context;
        }

        public SelectList AuthorSL { get; set; }
        public SelectList PublisherSL { get; set; }

        public IActionResult OnGet()
        {
            var book = new Book();
            book.BookCategories = new List<BookCategory>();
            PopulateAssignedCategoryData(_context, book);

            AuthorSL = new SelectList(_context.Author.Select(a => new {
                a.ID,
                Name = a.FirstName + " " + a.LastName
            }), "ID", "Name");

            PublisherSL = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            // Am modificat aici: vom lucra direct pe proprietatea 'Book'
            // care vine deja populată cu datele din formular.
            if (selectedCategories != null)
            {
                Book.BookCategories = new List<BookCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new BookCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    Book.BookCategories.Add(catToAdd);
                }
            }

            if (!ModelState.IsValid)
            {
                PopulateAssignedCategoryData(_context, Book);
                return Page();
            }

            _context.Book.Add(Book);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}