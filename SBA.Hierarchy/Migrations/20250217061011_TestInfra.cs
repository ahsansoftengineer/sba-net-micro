using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SBA.Hierarchy.Migrations
{
    /// <inheritdoc />
    public partial class TestInfra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TestInfras",
                columns: new[] { "Id", "Created_At", "Desc", "IsActive", "IsDeleted", "Title", "Updated_At" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "TestInfra 1 Desc", false, false, "TestInfra 1", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 2, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "TestInfra 2 Desc", false, false, "TestInfra 2", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 3, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "TestInfra 3 Desc", false, false, "TestInfra 3", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TestInfras",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TestInfras",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TestInfras",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
