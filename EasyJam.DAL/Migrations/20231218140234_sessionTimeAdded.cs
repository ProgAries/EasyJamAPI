using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyJamDAL.Migrations
{
    /// <inheritdoc />
    public partial class sessionTimeAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("bd6ec335-8ee4-4b42-a2ba-29d66c185810"));

            migrationBuilder.AddColumn<string>(
                name: "SessionTime",
                table: "Jams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "Email", "EncodedPassword", "FirstName", "LastName", "Salt" },
                values: new object[] { new Guid("8eb81c2b-8f96-4cc9-9006-1bcdaa41e30c"), "Test@test.com", new byte[] { 123, 71, 48, 54, 97, 188, 196, 149, 134, 119, 127, 149, 19, 190, 58, 76, 46, 85, 116, 86, 207, 194, 83, 223, 28, 70, 89, 77, 182, 48, 5, 161, 162, 42, 30, 177, 187, 100, 18, 62, 190, 65, 98, 193, 184, 131, 208, 18, 61, 246, 166, 180, 78, 248, 254, 128, 161, 18, 196, 88, 64, 95, 238, 183 }, "Rocco", "Pasanisi", new Guid("fdb83384-5396-4591-8878-3039edb58f62") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("8eb81c2b-8f96-4cc9-9006-1bcdaa41e30c"));

            migrationBuilder.DropColumn(
                name: "SessionTime",
                table: "Jams");

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "Email", "EncodedPassword", "FirstName", "LastName", "Salt" },
                values: new object[] { new Guid("bd6ec335-8ee4-4b42-a2ba-29d66c185810"), "Test@test.com", new byte[] { 26, 131, 106, 178, 63, 207, 244, 104, 132, 244, 56, 251, 81, 115, 20, 5, 191, 52, 216, 79, 255, 237, 171, 51, 46, 56, 173, 255, 119, 183, 158, 202, 21, 216, 44, 232, 55, 19, 64, 9, 66, 69, 188, 224, 143, 229, 208, 44, 200, 215, 194, 154, 116, 32, 35, 25, 52, 42, 115, 51, 159, 106, 103, 49 }, "Rocco", "Pasanisi", new Guid("d23e5346-8f7c-4f2c-8265-d3f0092af0a4") });
        }
    }
}
