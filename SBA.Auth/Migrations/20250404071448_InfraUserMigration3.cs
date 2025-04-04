using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBA.Auth.Migrations
{
    /// <inheritdoc />
    public partial class InfraUserMigration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22c74fbc-9b0d-4848-85db-f09d58750006",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "c019aae7-ab2a-4d1e-b8d7-637e5298eca4", new DateTimeOffset(new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "AQAAAAIAAYagAAAAEJLXCITbNTKE+DDO3EoeFiN2ioNWsnN/bXZkKQ/TmThjaO4pAxL+RAWm1rY/GsxMOQ==", null, new DateTimeOffset(new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "46eb923d-8529-4b77-b311-96e98ea6ea06",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "04a51e36-58c1-4053-986a-1d861ba91b0b", new DateTimeOffset(new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "AQAAAAIAAYagAAAAEDzwKnEdo5BxnzVvEmpsa6nvmHM/Cp6ERtd5Xv+XV5TDJapbZaCk0mS6YkfxR/7x7Q==", null, new DateTimeOffset(new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8118fea8-a644-4d67-9eca-1d689465a1bf",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "473cb184-01ca-45f4-a26b-778947edda62", new DateTimeOffset(new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "AQAAAAIAAYagAAAAEOTiXXeqjxp1wScckUAyHRKNg9dtGWZUZSRJ/9mBDyyktbs9b+hGNxDj4edP9B5oaQ==", null, new DateTimeOffset(new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22c74fbc-9b0d-4848-85db-f09d58750006",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "bf049a3f-0c08-4d4f-b147-7f1c54377606", null, "AQAAAAIAAYagAAAAEK16QQ7WMj4IayBT3vsWsONtzUQNE5tLxzZXSTdwXYMArLwZOBoDfS4QuD56fToUWA==", "dfb4666e-e9ed-4229-b4a2-8b494854014c", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "46eb923d-8529-4b77-b311-96e98ea6ea06",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "a4266fb6-ea65-4a31-9115-3bbb0c076298", null, "AQAAAAIAAYagAAAAEHIWqTopGIl6FuUT33Ssl5fwWlYUwvZWUGilfimys9b/PtozTrruDFe98iOu27W7xA==", "8b35d684-4619-4039-9c9f-e9b6b2468e47", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8118fea8-a644-4d67-9eca-1d689465a1bf",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp", "UpdatedAt" },
                values: new object[] { "3b2eb138-7728-4db8-abc8-dc30a7f3b51a", null, "AQAAAAIAAYagAAAAEDZEnDIArG11tuY25E0ltLvRRwASJtPannrE5N39A2RMTW1ZeUhCQORV0pqmevAmvQ==", "bd762241-2668-4878-bfa8-f4789532642b", null });
        }
    }
}
