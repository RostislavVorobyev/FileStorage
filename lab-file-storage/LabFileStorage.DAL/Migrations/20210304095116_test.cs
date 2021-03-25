using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LabFileStorage.DAL.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FileMetadata",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 3, 4, 12, 51, 16, 407, DateTimeKind.Local).AddTicks(9026));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FileMetadata",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 3, 2, 16, 57, 50, 237, DateTimeKind.Local).AddTicks(7521));
        }
    }
}
