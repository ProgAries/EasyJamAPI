using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyJamDAL.Migrations
{
    /// <inheritdoc />
    public partial class ChordProgressionAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("8eb81c2b-8f96-4cc9-9006-1bcdaa41e30c"));

            migrationBuilder.CreateTable(
                name: "Chords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chord = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chords", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "Email", "EncodedPassword", "FirstName", "LastName", "Salt" },
                values: new object[] { new Guid("4253a3ec-d1cf-4807-bd6a-af564b01c17e"), "Test@test.com", new byte[] { 178, 9, 240, 198, 219, 186, 132, 253, 20, 159, 108, 197, 225, 33, 197, 210, 105, 231, 218, 35, 192, 197, 25, 86, 211, 45, 155, 29, 53, 37, 62, 159, 46, 225, 128, 140, 166, 116, 146, 133, 142, 18, 51, 1, 252, 106, 78, 194, 86, 94, 121, 233, 41, 102, 103, 2, 94, 85, 203, 125, 218, 71, 228, 118 }, "Rocco", "Pasanisi", new Guid("3757f170-f7d6-4f9a-8a4d-064fcea84a66") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chords");

            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("4253a3ec-d1cf-4807-bd6a-af564b01c17e"));

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "Email", "EncodedPassword", "FirstName", "LastName", "Salt" },
                values: new object[] { new Guid("8eb81c2b-8f96-4cc9-9006-1bcdaa41e30c"), "Test@test.com", new byte[] { 123, 71, 48, 54, 97, 188, 196, 149, 134, 119, 127, 149, 19, 190, 58, 76, 46, 85, 116, 86, 207, 194, 83, 223, 28, 70, 89, 77, 182, 48, 5, 161, 162, 42, 30, 177, 187, 100, 18, 62, 190, 65, 98, 193, 184, 131, 208, 18, 61, 246, 166, 180, 78, 248, 254, 128, 161, 18, 196, 88, 64, 95, 238, 183 }, "Rocco", "Pasanisi", new Guid("fdb83384-5396-4591-8878-3039edb58f62") });
        }
    }
}
