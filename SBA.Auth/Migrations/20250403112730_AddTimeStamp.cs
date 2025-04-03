using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBA.Auth.Migrations
{
    /// <inheritdoc />
    public partial class AddTimeStamp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "832f9537-20c4-49ca-9f12-b8c5f9515c17",
                columns: new[] { "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c40418c-4ac7-4f2e-9def-8ceeb5f5c556",
                columns: new[] { "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4206884-fc69-4a1b-a4ca-81f4cf594ee5",
                columns: new[] { "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "832f9537-20c4-49ca-9f12-b8c5f9515c17",
                columns: new[] { "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c40418c-4ac7-4f2e-9def-8ceeb5f5c556",
                columns: new[] { "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4206884-fc69-4a1b-a4ca-81f4cf594ee5",
                columns: new[] { "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, null, null });
        }
    }
}
