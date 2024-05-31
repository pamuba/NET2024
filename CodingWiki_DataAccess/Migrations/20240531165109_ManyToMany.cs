using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fluent_AuthorFluent_Book",
                columns: table => new
                {
                    Fluent_AuthorsAuthor_Id = table.Column<int>(type: "int", nullable: false),
                    Fluent_BooksBook_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fluent_AuthorFluent_Book", x => new { x.Fluent_AuthorsAuthor_Id, x.Fluent_BooksBook_Id });
                    table.ForeignKey(
                        name: "FK_Fluent_AuthorFluent_Book_Fluent_Author_Fluent_AuthorsAuthor_Id",
                        column: x => x.Fluent_AuthorsAuthor_Id,
                        principalTable: "Fluent_Author",
                        principalColumn: "Author_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fluent_AuthorFluent_Book_Fluent_Book_Fluent_BooksBook_Id",
                        column: x => x.Fluent_BooksBook_Id,
                        principalTable: "Fluent_Book",
                        principalColumn: "Book_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_AuthorFluent_Book_Fluent_BooksBook_Id",
                table: "Fluent_AuthorFluent_Book",
                column: "Fluent_BooksBook_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fluent_AuthorFluent_Book");
        }
    }
}
