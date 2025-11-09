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
        public DbSet<Publisher> Publisher { get; set; } = default!; 
        public DbSet<Pop_Dan_Ioan_LAB2.Models.Author> Author { get; set; } = default!;
        public DbSet<Category> Category { get; set; } = default!;
        public DbSet<Pop_Dan_Ioan_LAB2.Models.Member> Member { get; set; } = default!;
        public DbSet<Pop_Dan_Ioan_LAB2.Models.Borrowing> Borrowing { get; set; }
    }
}
