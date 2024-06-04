using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodingWiki_DataAccess.Data.FluentConfig
{
    public class FluentBookConfig : IEntityTypeConfiguration<Fluent_Book>
    {
        public void Configure(EntityTypeBuilder<Fluent_Book> modelBuilder)
        {
            modelBuilder.ToTable("Fluent_Book");
            modelBuilder.Property(u => u.ISBN).IsRequired();
            modelBuilder.Property(u => u.ISBN).HasMaxLength(20);
            modelBuilder.HasKey(u => u.Book_Id);
            modelBuilder.Ignore(u => u.PriceRange);
            modelBuilder.HasOne(u => u.Fluent_Publisher).WithMany(u => u.Fluent_Book)
                .HasForeignKey(u => u.Publisher_Id);
        }
    }
}
