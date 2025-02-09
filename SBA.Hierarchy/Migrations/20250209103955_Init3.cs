using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SBA.Hierarchy.Migrations
{
    /// <inheritdoc />
    public partial class Init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BGs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "BGs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "BGs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "LEs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "LEs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "LEs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "OUs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "OUs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "OUs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Orgs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Orgs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Orgs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SUs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SUs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SUs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Systemzs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Systemzs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Systemzs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { null, null });

            migrationBuilder.InsertData(
                table: "TestInfras",
                columns: new[] { "Id", "CreatedAt", "Desc", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, null, "TestInfra 1 Desc", "TestInfra 1", null },
                    { 2, null, "TestInfra 2 Desc", "TestInfra 2", null },
                    { 3, null, "TestInfra 3 Desc", "TestInfra 3", null }
                });

            migrationBuilder.InsertData(
                table: "TestProjs",
                columns: new[] { "Id", "CreatedAt", "Desc", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, null, "TestProj 1 Desc", "TestProj 1", null },
                    { 2, null, "TestProj 2 Desc", "TestProj 2", null },
                    { 3, null, "TestProj 3 Desc", "TestProj 3", null }
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

            migrationBuilder.DeleteData(
                table: "TestProjs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TestProjs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TestProjs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "BGs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2041), new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2041) });

            migrationBuilder.UpdateData(
                table: "BGs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2048), new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2048) });

            migrationBuilder.UpdateData(
                table: "BGs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2051), new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2052) });

            migrationBuilder.UpdateData(
                table: "LEs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2083), new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2083) });

            migrationBuilder.UpdateData(
                table: "LEs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2089), new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2090) });

            migrationBuilder.UpdateData(
                table: "LEs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2092), new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2092) });

            migrationBuilder.UpdateData(
                table: "OUs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2198), new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2199) });

            migrationBuilder.UpdateData(
                table: "OUs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2215), new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2215) });

            migrationBuilder.UpdateData(
                table: "OUs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2220), new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2220) });

            migrationBuilder.UpdateData(
                table: "Orgs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(1896), new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(1898) });

            migrationBuilder.UpdateData(
                table: "Orgs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(1939), new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(1940) });

            migrationBuilder.UpdateData(
                table: "Orgs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(1943), new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(1943) });

            migrationBuilder.UpdateData(
                table: "SUs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2256), new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2256) });

            migrationBuilder.UpdateData(
                table: "SUs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2262), new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2262) });

            migrationBuilder.UpdateData(
                table: "SUs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2265), new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2265) });

            migrationBuilder.UpdateData(
                table: "Systemzs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(1991), new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(1992) });

            migrationBuilder.UpdateData(
                table: "Systemzs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2001), new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2001) });

            migrationBuilder.UpdateData(
                table: "Systemzs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2004), new DateTime(2025, 2, 9, 10, 29, 37, 461, DateTimeKind.Utc).AddTicks(2004) });
        }
    }
}
