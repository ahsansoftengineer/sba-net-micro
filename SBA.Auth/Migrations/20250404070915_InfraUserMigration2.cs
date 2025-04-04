using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SBA.Auth.Migrations
{
    /// <inheritdoc />
    public partial class InfraUserMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { "22c74fbc-9b0d-4848-85db-f09d58750006", 0, "bf049a3f-0c08-4d4f-b147-7f1c54377606", null, "InfraUser_1@yopmail.com", true, false, null, "INFRAUSER_1@YOPMAIL.COM", "INFRAUSER_1@YOPMAIL.COM", "AQAAAAIAAYagAAAAEK16QQ7WMj4IayBT3vsWsONtzUQNE5tLxzZXSTdwXYMArLwZOBoDfS4QuD56fToUWA==", null, false, "dfb4666e-e9ed-4229-b4a2-8b494854014c", null, false, null, "InfraUser_1@yopmail.com" },
                    { "46eb923d-8529-4b77-b311-96e98ea6ea06", 0, "a4266fb6-ea65-4a31-9115-3bbb0c076298", null, "InfraUser_2@yopmail.com", true, false, null, "INFRAUSER_2@YOPMAIL.COM", "INFRAUSER_2@YOPMAIL.COM", "AQAAAAIAAYagAAAAEHIWqTopGIl6FuUT33Ssl5fwWlYUwvZWUGilfimys9b/PtozTrruDFe98iOu27W7xA==", null, false, "8b35d684-4619-4039-9c9f-e9b6b2468e47", null, false, null, "InfraUser_2@yopmail.com" },
                    { "8118fea8-a644-4d67-9eca-1d689465a1bf", 0, "3b2eb138-7728-4db8-abc8-dc30a7f3b51a", null, "InfraUser_3@yopmail.com", true, false, null, "INFRAUSER_3@YOPMAIL.COM", "INFRAUSER_3@YOPMAIL.COM", "AQAAAAIAAYagAAAAEDZEnDIArG11tuY25E0ltLvRRwASJtPannrE5N39A2RMTW1ZeUhCQORV0pqmevAmvQ==", null, false, "bd762241-2668-4878-bfa8-f4789532642b", null, false, null, "InfraUser_3@yopmail.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22c74fbc-9b0d-4848-85db-f09d58750006");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "46eb923d-8529-4b77-b311-96e98ea6ea06");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8118fea8-a644-4d67-9eca-1d689465a1bf");
        }
    }
}
