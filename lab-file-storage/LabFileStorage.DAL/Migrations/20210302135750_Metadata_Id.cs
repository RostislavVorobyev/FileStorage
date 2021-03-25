using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LabFileStorage.DAL.Migrations
{
    public partial class Metadata_Id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FileMetadata",
                table: "FileMetadata");

            migrationBuilder.DeleteData(
                table: "FileMetadata",
                keyColumn: "FileName",
                keyValue: "filename");

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                table: "FileMetadata",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "FileMetadata",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FileMetadata",
                table: "FileMetadata",
                column: "Id");

            migrationBuilder.InsertData(
                table: "FileMetadata",
                columns: new[] { "Id", "CreationDate", "DownloadsCounter", "Extension", "FileName", "PathToFile", "Size" },
                values: new object[] { 1, new DateTime(2021, 3, 2, 16, 57, 50, 237, DateTimeKind.Local).AddTicks(7521), 0L, ".ext", "filename", "samplepath", 0L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FileMetadata",
                table: "FileMetadata");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FileMetadata");

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                table: "FileMetadata",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FileMetadata",
                table: "FileMetadata",
                column: "FileName");

            migrationBuilder.UpdateData(
                table: "FileMetadata",
                keyColumn: "FileName",
                keyValue: "filename",
                column: "CreationDate",
                value: new DateTime(2021, 3, 2, 14, 22, 6, 132, DateTimeKind.Local).AddTicks(4167));
        }
    }
}
