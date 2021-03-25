using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LabFileStorage.DAL.Migrations
{
    public partial class Testencrypt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FileMetadata",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 3, 3, 17, 38, 3, 743, DateTimeKind.Local).AddTicks(3911));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2b$10$jMI6IC8X.dSWoAhq0MBajOd4Uo1URKACjyYxlDOXQ0TOrj6hitxHq");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 3, 17, 38, 3, 743, DateTimeKind.Local).AddTicks(3911),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "FileMetadata",
                columns: new[] { "Id", "CreationDate", "DownloadsCounter", "Extension", "FileName", "PathToFile", "Size" },
                values: new object[] { 1, new DateTime(2021, 3, 3, 17, 38, 3, 720, DateTimeKind.Local).AddTicks(4561), 0L, ".ext", "filename", "samplepath", 0L });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "v");
        }
    }
}
