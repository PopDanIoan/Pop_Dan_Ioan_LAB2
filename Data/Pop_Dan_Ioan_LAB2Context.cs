using Microsoft.EntityFrameworkCore;

using Pop_Dan_Ioan_LAB2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pop_Dan_Ioan_LAB2.Data
{
    public class Pop_Dan_Ioan_LAB2Context : DbContext
    {
        public Pop_Dan_Ioan_LAB2Context (DbContextOptions<Pop_Dan_Ioan_LAB2Context> options)
            : base(options)
        {
        }

        public DbSet<Book> Book { get; set; } = default!;
        public DbSet<BookPublisher> Publisher { get; set; } = default!; 
    }
}
