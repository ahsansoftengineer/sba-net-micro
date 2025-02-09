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
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                columns: new[] { "Id", "CreatedAt", "Desc", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3867), "BG 1 Desc", "BG 1", new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3867) },
                    { 2, new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3875), "BG 2 Desc", "BG 2", new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3876) },
                    { 3, new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3880), "BG 3 Desc", "BG 3", new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3881) }
                });

            migrationBuilder.InsertData(
                table: "Orgs",
                columns: new[] { "Id", "CreatedAt", "Desc", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3661), "Org 1 Desc", "Org 1", new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3665) },
                    { 2, new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3717), "Org 2 Desc", "Org 2", new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3717) },
                    { 3, new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3722), "Org 3 Desc", "Org 3", new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3722) }
                });

            migrationBuilder.InsertData(
                table: "LEs",
                columns: new[] { "Id", "BGId", "CreatedAt", "Desc", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3928), "LE 1 Desc", "LE 1", new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3928) },
                    { 2, 2, new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3938), "LE 2 Desc", "LE 2", new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3938) },
                    { 3, 3, new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3943), "LE 3 Desc", "LE 3", new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3943) }
                });

            migrationBuilder.InsertData(
                table: "Systemzs",
                columns: new[] { "Id", "CreatedAt", "Desc", "OrgId", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3791), "Systemz 1 Desc", 1, "Systemz 1", new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3791) },
                    { 2, new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3804), "Systemz 2 Desc", 2, "Systemz 2", new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3805) },
                    { 3, new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3809), "Systemz 3 Desc", 3, "Systemz 3", new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3810) }
                });

            migrationBuilder.InsertData(
                table: "OUs",
                columns: new[] { "Id", "Address", "CreatedAt", "Deposit", "Desc", "FooterImg", "LEId", "Law", "LogoImg", "Title", "TopImg", "UpdatedAt", "WarningImg" },
                values: new object[,]
                {
                    { 1, "OUAddress", new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3990), "OUDeposit", "OU 1 Desc", "OUFooterImg", 1, "OULaw", "OULogoImg", "OU 1", "OUTopImg", new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(3990), "OUWarningImg" },
                    { 2, "OUAddress", new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(4011), "OUDeposit", "OU 2 Desc", "OUFooterImg", 2, "OULaw", "OULogoImg", "OU 2", "OUTopImg", new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(4011), "OUWarningImg" },
                    { 3, "OUAddress", new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(4017), "OUDeposit", "OU 3 Desc", "OUFooterImg", 3, "OULaw", "OULogoImg", "OU 3", "OUTopImg", new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(4018), "OUWarningImg" }
                });

            migrationBuilder.InsertData(
                table: "SUs",
                columns: new[] { "Id", "CreatedAt", "Desc", "OUId", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(4066), "SU 1 Desc", 1, "SU 1", new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(4067) },
                    { 2, new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(4076), "SU 2 Desc", 2, "SU 2", new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(4077) },
                    { 3, new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(4081), "SU 3 Desc", 3, "SU 3", new DateTime(2025, 2, 9, 10, 23, 38, 778, DateTimeKind.Utc).AddTicks(4081) }
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
