using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodingWiki_DataAccess.Data.FluentConfig
{
    public class FluentAuthorConfig : IEntityTypeConfiguration<Fluent_Author>
    {
        public void Configure(EntityTypeBuilder<Fluent_Author> modelBuilder)
        {
            modelBuilder.ToTable("Fluent_Author");
            modelBuilder.Property(u => u.FirstName).HasMaxLength(20);
            modelBuilder.HasKey(u => u.Author_Id);
            modelBuilder.Property(u => u.FirstName).IsRequired();
            modelBuilder.Property(u => u.LastName).IsRequired();
            modelBuilder.Ignore(u => u.FullName);
        }
    }
}
