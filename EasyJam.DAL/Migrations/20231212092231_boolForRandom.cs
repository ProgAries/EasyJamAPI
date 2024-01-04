using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyJamDAL.Migrations
{
    /// <inheritdoc />
    public partial class boolForRandom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("bb1cf296-3bb7-4d3a-b885-0ac8fd45c7a1"));

            migrationBuilder.AddColumn<bool>(
                name: "IsRandom",
                table: "Jams",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "Email", "EncodedPassword", "FirstName", "LastName", "Salt" },
                values: new object[] { new Guid("bd6ec335-8ee4-4b42-a2ba-29d66c185810"), "Test@test.com", new byte[] { 26, 131, 106, 178, 63, 207, 244, 104, 132, 244, 56, 251, 81, 115, 20, 5, 191, 52, 216, 79, 255, 237, 171, 51, 46, 56, 173, 255, 119, 183, 158, 202, 21, 216, 44, 232, 55, 19, 64, 9, 66, 69, 188, 224, 143, 229, 208, 44, 200, 215, 194, 154, 116, 32, 35, 25, 52, 42, 115, 51, 159, 106, 103, 49 }, "Rocco", "Pasanisi", new Guid("d23e5346-8f7c-4f2c-8265-d3f0092af0a4") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: new Guid("bd6ec335-8ee4-4b42-a2ba-29d66c185810"));

            migrationBuilder.DropColumn(
                name: "IsRandom",
                table: "Jams");

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "Email", "EncodedPassword", "FirstName", "LastName", "Salt" },
                values: new object[] { new Guid("bb1cf296-3bb7-4d3a-b885-0ac8fd45c7a1"), "Test@test.com", new byte[] { 146, 25, 219, 89, 59, 125, 56, 49, 142, 175, 121, 167, 254, 85, 140, 36, 4, 90, 13, 50, 155, 108, 200, 182, 93, 34, 227, 155, 85, 4, 131, 16, 215, 145, 130, 94, 142, 11, 188, 248, 154, 19, 134, 31, 173, 243, 103, 100, 228, 78, 209, 217, 169, 117, 119, 254, 105, 15, 35, 34, 143, 190, 223, 52 }, "Rocco", "Pasanisi", new Guid("6f2b1ff4-6df0-4bd7-bbea-ac9536f1eb41") });
        }
    }
}
