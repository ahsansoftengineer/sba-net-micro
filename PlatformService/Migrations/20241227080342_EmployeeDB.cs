using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PlatformService.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ID", "Gender", "Name" },
                values: new object[,]
                {
                    { 1, "Male", "Ahsan" },
                    { 2, "Male", "Asim" },
                    { 3, "Female", "Sumaya" }
                });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "ID", "Cost", "Name", "Publisher" },
                values: new object[,]
                {
                    { 1, "Free", "Dot Net", "Microsoft" },
                    { 2, "Free", "SQL Server Express", "Microsoft" },
                    { 3, "Free", "Kubernetes", "Cloud Native Computing Foundation" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "ID",
                keyValue: 3);
        }
    }
}
