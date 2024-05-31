using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ONETOMANY : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_Book_Fluent_Publisher_Fluent_PublisherPublisher_Id",
                table: "Fluent_Book");

            migrationBuilder.DropIndex(
                name: "IX_Fluent_Book_Fluent_PublisherPublisher_Id",
                table: "Fluent_Book");

            migrationBuilder.DropColumn(
                name: "Fluent_PublisherPublisher_Id",
                table: "Fluent_Book");

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_Book_Publisher_Id",
                table: "Fluent_Book",
                column: "Publisher_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_Book_Fluent_Publisher_Publisher_Id",
                table: "Fluent_Book",
                column: "Publisher_Id",
                principalTable: "Fluent_Publisher",
                principalColumn: "Publisher_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_Book_Fluent_Publisher_Publisher_Id",
                table: "Fluent_Book");

            migrationBuilder.DropIndex(
                name: "IX_Fluent_Book_Publisher_Id",
                table: "Fluent_Book");

            migrationBuilder.AddColumn<int>(
                name: "Fluent_PublisherPublisher_Id",
                table: "Fluent_Book",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_Book_Fluent_PublisherPublisher_Id",
                table: "Fluent_Book",
                column: "Fluent_PublisherPublisher_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_Book_Fluent_Publisher_Fluent_PublisherPublisher_Id",
                table: "Fluent_Book",
                column: "Fluent_PublisherPublisher_Id",
                principalTable: "Fluent_Publisher",
                principalColumn: "Publisher_Id");
        }
    }
}
