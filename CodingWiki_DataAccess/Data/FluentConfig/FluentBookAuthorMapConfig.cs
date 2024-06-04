using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodingWiki_DataAccess.Data.FluentConfig
{
    public class FluentBookAuthorMapConfig : IEntityTypeConfiguration<Fluent_BookAuthorMap>
    {
        public void Configure(EntityTypeBuilder<Fluent_BookAuthorMap> modelBuilder)
        {
           
            modelBuilder.HasOne(u => u.Fluent_Book).WithMany(u => u.Fluent_BookAuthorMap)
                .HasForeignKey(u => u.Book_Id);
            modelBuilder.HasOne(u => u.Fluent_Author).WithMany(u => u.Fluent_BookAuthorMap)
               .HasForeignKey(u => u.Author_Id);
        }
    }
}
