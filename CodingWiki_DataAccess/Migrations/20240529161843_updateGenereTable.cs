using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updateGenereTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Generes",
                table: "Generes");

            migrationBuilder.RenameTable(
                name: "Generes",
                newName: "tb_generes");

            migrationBuilder.RenameColumn(
                name: "GenereName",
                table: "tb_generes",
                newName: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_generes",
                table: "tb_generes",
                column: "GenereId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_generes",
                table: "tb_generes");

            migrationBuilder.RenameTable(
                name: "tb_generes",
                newName: "Generes");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Generes",
                newName: "GenereName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Generes",
                table: "Generes",
                column: "GenereId");
        }
    }
}
