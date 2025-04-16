using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBA.Auth.Migrations
{
    /// <inheritdoc />
    public partial class IdentityUserUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22c74fbc-9b0d-4848-85db-f09d58750006",
                columns: new[] { "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp" },
                values: new object[] { "03212827700", true, "22c74fbc-9b0d-4848-85db-f09d58750006" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "46eb923d-8529-4b77-b311-96e98ea6ea06",
                columns: new[] { "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp" },
                values: new object[] { "03212827701", true, "46eb923d-8529-4b77-b311-96e98ea6ea06" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8118fea8-a644-4d67-9eca-1d689465a1bf",
                columns: new[] { "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp" },
                values: new object[] { "03212827702", true, "8118fea8-a644-4d67-9eca-1d689465a1bf" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22c74fbc-9b0d-4848-85db-f09d58750006",
                columns: new[] { "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp" },
                values: new object[] { null, false, null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "46eb923d-8529-4b77-b311-96e98ea6ea06",
                columns: new[] { "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp" },
                values: new object[] { null, false, null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8118fea8-a644-4d67-9eca-1d689465a1bf",
                columns: new[] { "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp" },
                values: new object[] { null, false, null });
        }
    }
}
