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
    public class IndexModel : PageModel
    {
        private readonly Pop_Dan_Ioan_LAB2.Data.Pop_Dan_Ioan_LAB2Context _context;

        public IndexModel(Pop_Dan_Ioan_LAB2.Data.Pop_Dan_Ioan_LAB2Context context)
        {
            _context = context;
        }

        public IList<BookPublisher> BookPublisher { get;set; } = default!;

        public async Task OnGetAsync()
        {
            BookPublisher = await _context.Publisher
                .Include(p => p.Books)
                .ToListAsync();

        }
    }
}
