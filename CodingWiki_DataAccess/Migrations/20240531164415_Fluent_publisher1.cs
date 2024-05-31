using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CodingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Fluent_publisher1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Author_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Author_Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Fluent_Author",
                columns: table => new
                {
                    Author_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fluent_Author", x => x.Author_Id);
                });

            migrationBuilder.CreateTable(
                name: "Fluent_BookDetail",
                columns: table => new
                {
                    BookDetail_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoOfChapters = table.Column<int>(type: "int", nullable: false),
                    NumberOfPages = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceRange = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fluent_BookDetail", x => x.BookDetail_Id);
                });

            migrationBuilder.CreateTable(
                name: "Fluent_Publisher",
                columns: table => new
                {
                    Publisher_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fluent_Publisher", x => x.Publisher_Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Publisher_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Publisher_Id);
                });

            migrationBuilder.CreateTable(
                name: "SubCategorys",
                columns: table => new
                {
                    SubCategory_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategorys", x => x.SubCategory_Id);
                });

            migrationBuilder.CreateTable(
                name: "Fluent_Book",
                columns: table => new
                {
                    Book_Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISBN = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: false),
                    Publisher_Id = table.Column<int>(type: "int", nullable: false),
                    Fluent_PublisherPublisher_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fluent_Book", x => x.Book_Id);
                    table.ForeignKey(
                        name: "FK_Fluent_Book_Fluent_BookDetail_Book_Id",
                        column: x => x.Book_Id,
                        principalTable: "Fluent_BookDetail",
                        principalColumn: "BookDetail_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fluent_Book_Fluent_Publisher_Fluent_PublisherPublisher_Id",
                        column: x => x.Fluent_PublisherPublisher_Id,
                        principalTable: "Fluent_Publisher",
                        principalColumn: "Publisher_Id");
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Book_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISBN = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: false),
                    Publisher_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Book_Id);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_Publisher_Id",
                        column: x => x.Publisher_Id,
                        principalTable: "Publishers",
                        principalColumn: "Publisher_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthorMap",
                columns: table => new
                {
                    Book_Id = table.Column<int>(type: "int", nullable: false),
                    Author_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthorMap", x => new { x.Author_Id, x.Book_Id });
                    table.ForeignKey(
                        name: "FK_BookAuthorMap_Authors_Author_Id",
                        column: x => x.Author_Id,
                        principalTable: "Authors",
                        principalColumn: "Author_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthorMap_Books_Book_Id",
                        column: x => x.Book_Id,
                        principalTable: "Books",
                        principalColumn: "Book_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookDetails",
                columns: table => new
                {
                    BookDetail_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfChapters = table.Column<int>(type: "int", nullable: false),
                    NumberOfPages = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceRange = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Book_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookDetails", x => x.BookDetail_Id);
                    table.ForeignKey(
                        name: "FK_BookDetails_Books_Book_Id",
                        column: x => x.Book_Id,
                        principalTable: "Books",
                        principalColumn: "Book_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Publisher_Id", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "CA", "Longman" },
                    { 2, "CA", "Longman" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Book_Id", "ISBN", "Price", "Publisher_Id", "Title" },
                values: new object[,]
                {
                    { 1, "123456", 123.456m, 1, "Superman" },
                    { 2, "143456", 223.456m, 2, "Ironman" },
                    { 3, "143456", 223.456m, 1, "Ironman" },
                    { 4, "143456", 223.456m, 1, "Ironman" },
                    { 5, "143456", 223.456m, 1, "Ironman" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthorMap_Book_Id",
                table: "BookAuthorMap",
                column: "Book_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BookDetails_Book_Id",
                table: "BookDetails",
                column: "Book_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_Publisher_Id",
                table: "Books",
                column: "Publisher_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_Book_Fluent_PublisherPublisher_Id",
                table: "Fluent_Book",
                column: "Fluent_PublisherPublisher_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthorMap");

            migrationBuilder.DropTable(
                name: "BookDetails");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Fluent_Author");

            migrationBuilder.DropTable(
                name: "Fluent_Book");

            migrationBuilder.DropTable(
                name: "SubCategorys");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Fluent_BookDetail");

            migrationBuilder.DropTable(
                name: "Fluent_Publisher");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
