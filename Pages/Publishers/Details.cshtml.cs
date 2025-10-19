using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pop_Dan_Ioan_LAB2.Data;
using Pop_Dan_Ioan_LAB2.Models;

namespace Pop_Dan_Ioan_LAB2.Pages.Publishers
{
    public class DetailsModel : PageModel
    {
        private readonly Pop_Dan_Ioan_LAB2.Data.Pop_Dan_Ioan_LAB2Context _context;

        public DetailsModel(Pop_Dan_Ioan_LAB2.Data.Pop_Dan_Ioan_LAB2Context context)
        {
            _context = context;
        }

        public BookPublisher BookPublisher { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookpublisher = await _context.Publisher.FirstOrDefaultAsync(m => m.ID == id);
            if (bookpublisher == null)
            {
                return NotFound();
            }
            else
            {
                BookPublisher = bookpublisher;
            }
            return Page();
        }
    }
}
