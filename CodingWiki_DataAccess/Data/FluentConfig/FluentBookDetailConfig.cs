using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodingWiki_DataAccess.Data.FluentConfig
{
    public class FluentBookDetailConfig : IEntityTypeConfiguration<Fluent_BookDetail>
    {
        public void Configure(EntityTypeBuilder<Fluent_BookDetail> modelBuilder)
        {
            //name of the table
            modelBuilder.ToTable("Fluent_BookDetail");
            
            //name of the column
            modelBuilder.Property(u => u.NumberOfChapters).HasColumnName("NoOfChapters");
            
            //validators 
            modelBuilder.Property(u => u.NumberOfChapters).IsRequired();
            modelBuilder.HasKey(u => u.BookDetail_Id);
            modelBuilder.Property(u => u.PriceRange).IsRequired();

            //relations
            modelBuilder.HasOne(b => b.Fluent_Book).WithOne(b => b.Fluent_BookDetail)
                .HasForeignKey<Fluent_Book>(u => u.Book_Id);
        }
    }
}
