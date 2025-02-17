using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SBA.Hierarchy.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BGs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_At = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Updated_At = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BGs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orgs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_At = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Updated_At = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orgs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestInfras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_At = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Updated_At = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestInfras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestProjs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_At = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Updated_At = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestProjs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LEs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BGId = table.Column<int>(type: "int", nullable: false),
                    Created_At = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Updated_At = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LEs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LEs_BGs_BGId",
                        column: x => x.BGId,
                        principalTable: "BGs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Systemzs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrgId = table.Column<int>(type: "int", nullable: false),
                    Created_At = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Updated_At = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Systemzs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Systemzs_Orgs_OrgId",
                        column: x => x.OrgId,
                        principalTable: "Orgs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LEId = table.Column<int>(type: "int", nullable: false),
                    Law = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deposit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TopImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarningImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FooterImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Updated_At = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OUs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OUs_LEs_LEId",
                        column: x => x.LEId,
                        principalTable: "LEs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OUId = table.Column<int>(type: "int", nullable: false),
                    Created_At = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Updated_At = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SUs_OUs_OUId",
                        column: x => x.OUId,
                        principalTable: "OUs",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "BGs",
                columns: new[] { "Id", "Created_At", "Desc", "Title", "Updated_At" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "BG 1 Desc", "BG 1", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 2, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "BG 2 Desc", "BG 2", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 3, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "BG 3 Desc", "BG 3", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Orgs",
                columns: new[] { "Id", "Created_At", "Desc", "Title", "Updated_At" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "Org 1 Desc", "Org 1", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 2, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "Org 2 Desc", "Org 2", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 3, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "Org 3 Desc", "Org 3", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "TestInfras",
                columns: new[] { "Id", "Created_At", "Desc", "Title", "Updated_At" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "TestInfra 1 Desc", "TestInfra 1", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 2, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "TestInfra 2 Desc", "TestInfra 2", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 3, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "TestInfra 3 Desc", "TestInfra 3", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "TestProjs",
                columns: new[] { "Id", "Created_At", "Desc", "Title", "Updated_At" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "TestProj 1 Desc", "TestProj 1", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 2, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "TestProj 2 Desc", "TestProj 2", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 3, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "TestProj 3 Desc", "TestProj 3", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "LEs",
                columns: new[] { "Id", "BGId", "Created_At", "Desc", "Title", "Updated_At" },
                values: new object[,]
                {
                    { 1, 1, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "LE 1 Desc", "LE 1", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 2, 2, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "LE 2 Desc", "LE 2", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 3, 3, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "LE 3 Desc", "LE 3", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Systemzs",
                columns: new[] { "Id", "Created_At", "Desc", "OrgId", "Title", "Updated_At" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "Systemz 1 Desc", 1, "Systemz 1", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 2, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "Systemz 2 Desc", 2, "Systemz 2", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 3, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "Systemz 3 Desc", 3, "Systemz 3", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "OUs",
                columns: new[] { "Id", "Address", "Created_At", "Deposit", "Desc", "FooterImg", "LEId", "Law", "LogoImg", "Title", "TopImg", "Updated_At", "WarningImg" },
                values: new object[,]
                {
                    { 1, "OUAddress", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "OUDeposit", "OU 1 Desc", "OUFooterImg", 1, "OULaw", "OULogoImg", "OU 1", "OUTopImg", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "OUWarningImg" },
                    { 2, "OUAddress", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "OUDeposit", "OU 2 Desc", "OUFooterImg", 2, "OULaw", "OULogoImg", "OU 2", "OUTopImg", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "OUWarningImg" },
                    { 3, "OUAddress", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "OUDeposit", "OU 3 Desc", "OUFooterImg", 3, "OULaw", "OULogoImg", "OU 3", "OUTopImg", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "OUWarningImg" }
                });

            migrationBuilder.InsertData(
                table: "SUs",
                columns: new[] { "Id", "Created_At", "Desc", "OUId", "Title", "Updated_At" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "SU 1 Desc", 1, "SU 1", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 2, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "SU 2 Desc", 2, "SU 2", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 3, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "SU 3 Desc", 3, "SU 3", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LEs_BGId",
                table: "LEs",
                column: "BGId");

            migrationBuilder.CreateIndex(
                name: "IX_OUs_LEId",
                table: "OUs",
                column: "LEId");

            migrationBuilder.CreateIndex(
                name: "IX_SUs_OUId",
                table: "SUs",
                column: "OUId");

            migrationBuilder.CreateIndex(
                name: "IX_Systemzs_OrgId",
                table: "Systemzs",
                column: "OrgId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SUs");

            migrationBuilder.DropTable(
                name: "Systemzs");

            migrationBuilder.DropTable(
                name: "TestInfras");

            migrationBuilder.DropTable(
                name: "TestProjs");

            migrationBuilder.DropTable(
                name: "OUs");

            migrationBuilder.DropTable(
                name: "Orgs");

            migrationBuilder.DropTable(
                name: "LEs");

            migrationBuilder.DropTable(
                name: "BGs");
        }
    }
}
