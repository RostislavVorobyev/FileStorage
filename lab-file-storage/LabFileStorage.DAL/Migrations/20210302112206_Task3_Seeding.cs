using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LabFileStorage.DAL.Migrations
{
    public partial class Task3_Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FileMetadata",
                columns: new[] { "FileName", "CreationDate", "DownloadsCounter", "Extension", "PathToFile", "Size" },
                values: new object[] { "filename", new DateTime(2021, 3, 2, 14, 22, 6, 132, DateTimeKind.Local).AddTicks(4167), 0L, ".ext", "samplepath", 0L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FileMetadata",
                keyColumn: "FileName",
                keyValue: "filename");
        }
    }
}
