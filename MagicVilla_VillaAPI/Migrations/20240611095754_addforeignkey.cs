using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class addforeignkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VillaID",
                table: "VillaNumbres",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 11, 15, 27, 53, 458, DateTimeKind.Local).AddTicks(1449));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 11, 15, 27, 53, 458, DateTimeKind.Local).AddTicks(1502));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 11, 15, 27, 53, 458, DateTimeKind.Local).AddTicks(1510));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 11, 15, 27, 53, 458, DateTimeKind.Local).AddTicks(1518));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 11, 15, 27, 53, 458, DateTimeKind.Local).AddTicks(1526));

            migrationBuilder.CreateIndex(
                name: "IX_VillaNumbres_VillaID",
                table: "VillaNumbres",
                column: "VillaID");

            migrationBuilder.AddForeignKey(
                name: "FK_VillaNumbres_villas_VillaID",
                table: "VillaNumbres",
                column: "VillaID",
                principalTable: "villas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VillaNumbres_villas_VillaID",
                table: "VillaNumbres");

            migrationBuilder.DropIndex(
                name: "IX_VillaNumbres_VillaID",
                table: "VillaNumbres");

            migrationBuilder.DropColumn(
                name: "VillaID",
                table: "VillaNumbres");

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 10, 21, 0, 38, 853, DateTimeKind.Local).AddTicks(9836));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 10, 21, 0, 38, 853, DateTimeKind.Local).AddTicks(9859));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 10, 21, 0, 38, 853, DateTimeKind.Local).AddTicks(9862));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 10, 21, 0, 38, 853, DateTimeKind.Local).AddTicks(9865));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 10, 21, 0, 38, 853, DateTimeKind.Local).AddTicks(9869));
        }
    }
}
