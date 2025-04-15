using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBA.Auth.Migrations
{
    /// <inheritdoc />
    public partial class Inits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22c74fbc-9b0d-4848-85db-f09d58750006",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEMW6dhuNBiPMjOeoh/TnbBWygLWjcQy7bV6XlzctkUF5F34rNtcRS8VmsYbMgvvD5Q==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "46eb923d-8529-4b77-b311-96e98ea6ea06",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEFy7f8/zItfWU4XNy/66GES2HZl/XgorLdBiwhfS+AqbFmhf5rW/dOJtUWzr8wfy6A==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8118fea8-a644-4d67-9eca-1d689465a1bf",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEHb6XOGk+aQfxMfF7i9ZWsSQpaXc/ehMJv3FlusE6cfHQ0gmWhdIU1+500ygTKt0SA==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22c74fbc-9b0d-4848-85db-f09d58750006",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEACmShpP3LWgwsZwhZISwadM6d/EtzQ0WMkq/Bxig2P6XzeL4P2BJb+oC+rs6sFdJg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "46eb923d-8529-4b77-b311-96e98ea6ea06",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEPB7kfoIF5a0f/xqp1pdXMQAYZtvzQ2n8fxgXEGhjOP1aXilANBvPkwwhBlpRry1AQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8118fea8-a644-4d67-9eca-1d689465a1bf",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEGjg05pvktKMxHjB3nhkrG/ugiQvLkZVjwmu8gzE4+nH4XXwV90eyhEmGkrj9qFVBA==");
        }
    }
}
