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
        //rename to Fluent_BookDetail
        public DbSet<Fluent_BookDetail> BookDetails_fluent { get; set; }

        public DbSet<Fluent_Book> Books_fluent { get; set; }
        public DbSet<Fluent_Author> Fluent_Author { get; set; }
        public DbSet<Fluent_Publisher> Fluent_Publisher { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=MLBSRL1-106854;Database=CodingWiki;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //////////////////////////////FLUENT API////////////////////////////

            modelBuilder.Entity<Fluent_BookDetail>().ToTable("Fluent_BookDetail");
            modelBuilder.Entity<Fluent_BookDetail>().Property(u=>u.NumberOfChapters).HasColumnName("NoOfChapters");
            // IsRequired  HasKey
            modelBuilder.Entity<Fluent_BookDetail>().Property(u => u.NumberOfChapters).IsRequired();
            modelBuilder.Entity<Fluent_BookDetail>().HasKey(u => u.BookDetail_Id);
            modelBuilder.Entity<Fluent_BookDetail>().Property(u => u.PriceRange).IsRequired();
            modelBuilder.Entity<Fluent_BookDetail>().HasOne(b => b.Fluent_Book).WithOne(b => b.Fluent_BookDetail)
                .HasForeignKey<Fluent_Book>(u=>u.Book_Id);


            modelBuilder.Entity<Fluent_Book>().ToTable("Fluent_Book");
            modelBuilder.Entity<Fluent_Book>().Property(u => u.ISBN).IsRequired();
            modelBuilder.Entity<Fluent_Book>().Property(u => u.ISBN).HasMaxLength(20);
            modelBuilder.Entity<Fluent_Book>().HasKey(u => u.Book_Id);
            modelBuilder.Entity<Fluent_Book>().Ignore(u => u.PriceRange);
            modelBuilder.Entity<Fluent_Book>().HasOne(u => u.Fluent_Publisher).WithMany(u => u.Fluent_Book)
                .HasForeignKey(u => u.Publisher_Id);


            modelBuilder.Entity<Fluent_Author>().ToTable("Fluent_Author");
            modelBuilder.Entity<Fluent_Author>().Property(u => u.FirstName).HasMaxLength(20);
            modelBuilder.Entity<Fluent_Author>().HasKey(u => u.Author_Id);
            modelBuilder.Entity<Fluent_Author>().Property(u => u.FirstName).IsRequired();
            modelBuilder.Entity<Fluent_Author>().Property(u => u.LastName).IsRequired();
            modelBuilder.Entity<Fluent_Author>().Ignore(u => u.FullName);


            modelBuilder.Entity<Fluent_Publisher>().ToTable("Fluent_Publisher");
            modelBuilder.Entity<Fluent_Publisher>().HasKey(u => u.Publisher_Id);
            modelBuilder.Entity<Fluent_Publisher>().Property(u => u.Name).IsRequired();



            ////////////////////////////////////////////////////////////////////




            modelBuilder.Entity<Book>().Property(u => u.Price).HasPrecision(10,5);
            modelBuilder.Entity<Fluent_Book>().Property(u => u.Price).HasPrecision(10, 5);

            modelBuilder.Entity<BookAuthorMap>().HasKey(u => new { u.Author_Id, u.Book_Id});

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Publisher_Id = 1, Name = "Longman", Location = "CA" },
                new Publisher { Publisher_Id = 2, Name = "Longman", Location = "CA" }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book { Book_Id = 1, ISBN = "123456", Price = 123.456m, Title = "Superman", Publisher_Id = 1 },
                new Book { Book_Id = 2, ISBN = "143456", Price = 223.456m, Title = "Ironman", Publisher_Id = 2 }
            );

            var bookList = new Book[] {
                new Book { Book_Id = 3, ISBN = "143456", Price = 223.456m, Title = "Ironman",Publisher_Id=1 },
                new Book { Book_Id = 4, ISBN = "143456", Price = 223.456m, Title = "Ironman" ,Publisher_Id=1},
                new Book { Book_Id = 5, ISBN = "143456", Price = 223.456m, Title = "Ironman",Publisher_Id=1 }
            };

            modelBuilder.Entity<Book>().HasData(bookList);

        }
    }
}
