using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SBA.Hierarchy.Migrations
{
    /// <inheritdoc />
    public partial class Seeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "GlobalLookupzzBases",
                columns: new[] { "Id", "Created_At", "Desc", "Name", "Status", "Updated_At" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "GlobalLookupzzBase 1 Desc", "GlobalLookupzzBase 1", 0, new DateTimeOffset(new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 2, new DateTimeOffset(new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "GlobalLookupzzBase 2 Desc", "GlobalLookupzzBase 2", 0, new DateTimeOffset(new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 3, new DateTimeOffset(new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "GlobalLookupzzBase 3 Desc", "GlobalLookupzzBase 3", 0, new DateTimeOffset(new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "GlobalLookupzzs",
                columns: new[] { "Id", "Code", "Created_At", "Desc", "GlobalLookupzzBaseId", "Name", "Status", "Updated_At" },
                values: new object[,]
                {
                    { 1, "111-111-111", new DateTimeOffset(new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "GlobalLookupzz 1 Desc", 1, "GlobalLookupzz 1", 0, new DateTimeOffset(new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 2, "222-222-222", new DateTimeOffset(new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "GlobalLookupzz 2 Desc", 2, "GlobalLookupzz 2", 0, new DateTimeOffset(new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 3, "333-333-333", new DateTimeOffset(new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "GlobalLookupzz 3 Desc", 3, "GlobalLookupzz 3", 0, new DateTimeOffset(new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GlobalLookupzzs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GlobalLookupzzs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GlobalLookupzzs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "GlobalLookupzzBases",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GlobalLookupzzBases",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GlobalLookupzzBases",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
