using BookApi.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Defining relationship between book and book author
            modelBuilder.Entity<Book_Author>()
                .HasOne(b => b.Book)
                .WithMany(c => c.Book_Authors)
                .HasForeignKey(bi => bi.BookId);

            //Defining relationship between Book_author and author
            modelBuilder.Entity<Book_Author>()
                .HasOne(b => b.Authors)
                .WithMany(c => c.Book_Authors)
                .HasForeignKey(d => d.AuthorId);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Book_Author> Book_Authors { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
