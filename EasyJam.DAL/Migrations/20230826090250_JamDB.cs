using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyJamDAL.Migrations
{
    /// <inheritdoc />
    public partial class JamDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EncodedPassword = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Salt = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mic1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mic2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Drum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gtr1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gtr2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Keys = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Other1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Other2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Other3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Musiciens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instrument1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instrument2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instrument3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musiciens", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "Email", "EncodedPassword", "FirstName", "LastName", "Salt" },
                values: new object[] { new Guid("bb1cf296-3bb7-4d3a-b885-0ac8fd45c7a1"), "Test@test.com", new byte[] { 146, 25, 219, 89, 59, 125, 56, 49, 142, 175, 121, 167, 254, 85, 140, 36, 4, 90, 13, 50, 155, 108, 200, 182, 93, 34, 227, 155, 85, 4, 131, 16, 215, 145, 130, 94, 142, 11, 188, 248, 154, 19, 134, 31, 173, 243, 103, 100, 228, 78, 209, 217, 169, 117, 119, 254, 105, 15, 35, 34, 143, 190, 223, 52 }, "Rocco", "Pasanisi", new Guid("6f2b1ff4-6df0-4bd7-bbea-ac9536f1eb41") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Jams");

            migrationBuilder.DropTable(
                name: "Musiciens");
        }
    }
}
