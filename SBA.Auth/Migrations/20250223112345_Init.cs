using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SBA.Auth.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestInfras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Updated_At = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestInfras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestProjs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Updated_At = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestProjs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TestInfras",
                columns: new[] { "Id", "Created_At", "Desc", "Status", "Title", "Updated_At" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "TestInfra 1 Desc", 0, "TestInfra 1", new DateTimeOffset(new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 2, new DateTimeOffset(new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "TestInfra 2 Desc", 0, "TestInfra 2", new DateTimeOffset(new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 3, new DateTimeOffset(new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "TestInfra 3 Desc", 0, "TestInfra 3", new DateTimeOffset(new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "TestProjs",
                columns: new[] { "Id", "Created_At", "Desc", "Status", "Title", "Updated_At" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "TestProj 1 Desc", 0, "TestProj 1", new DateTimeOffset(new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 2, new DateTimeOffset(new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "TestProj 2 Desc", 0, "TestProj 2", new DateTimeOffset(new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 3, new DateTimeOffset(new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "TestProj 3 Desc", 0, "TestProj 3", new DateTimeOffset(new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestInfras");

            migrationBuilder.DropTable(
                name: "TestProjs");
        }
    }
}
