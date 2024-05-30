using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CodingWiki_DataAccess.Data
{
    internal class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<SubCategory> SubCategorys { get; set; }

        public DbSet<BookDetail> BookDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=MLBSRL1-106854;Database=CodingWiki;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().Property(u => u.Price).HasPrecision(10,5);
            modelBuilder.Entity<BookAuthorMap>().HasKey(u => new { u.Author_Id, u.Book_Id});

            //modelBuilder.Entity<Book>().HasData(
            //    new Book { BookID = 1, ISBN = "123456", Price = 123.456m,Title = "Superman" },
            //    new Book { BookID = 2, ISBN = "143456", Price = 223.456m, Title = "Ironman" }
            //);

            //var bookList = new Book[] {
            //    new Book { BookID = 3, ISBN = "143456", Price = 223.456m, Title = "Ironman" },
            //    new Book { BookID = 4, ISBN = "143456", Price = 223.456m, Title = "Ironman" },
            //    new Book { BookID = 5, ISBN = "143456", Price = 223.456m, Title = "Ironman" }
            //};

            //modelBuilder.Entity<Book>().HasData(bookList);

        }
    }
}
