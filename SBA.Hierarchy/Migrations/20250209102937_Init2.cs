using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBA.Hierarchy.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BGs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3867), new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3867) });

            migrationBuilder.UpdateData(
                table: "BGs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3875), new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3876) });

            migrationBuilder.UpdateData(
                table: "BGs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3880), new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3881) });

            migrationBuilder.UpdateData(
                table: "LEs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3928), new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3928) });

            migrationBuilder.UpdateData(
                table: "LEs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3938), new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3938) });

            migrationBuilder.UpdateData(
                table: "LEs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3943), new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3943) });

            migrationBuilder.UpdateData(
                table: "OUs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3990), new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3990) });

            migrationBuilder.UpdateData(
                table: "OUs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(4011), new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(4011) });

            migrationBuilder.UpdateData(
                table: "OUs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(4017), new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(4018) });

            migrationBuilder.UpdateData(
                table: "Orgs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3661), new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3665) });

            migrationBuilder.UpdateData(
                table: "Orgs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3717), new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3717) });

            migrationBuilder.UpdateData(
                table: "Orgs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3722), new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3722) });

            migrationBuilder.UpdateData(
                table: "SUs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(4066), new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(4067) });

            migrationBuilder.UpdateData(
                table: "SUs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(4076), new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(4077) });

            migrationBuilder.UpdateData(
                table: "SUs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(4081), new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(4081) });

            migrationBuilder.UpdateData(
                table: "Systemzs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3791), new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3791) });

            migrationBuilder.UpdateData(
                table: "Systemzs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3804), new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3805) });

            migrationBuilder.UpdateData(
                table: "Systemzs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3809), new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3810) });
        }
    }
}
