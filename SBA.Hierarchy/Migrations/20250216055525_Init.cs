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
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Updated_At = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BGs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Updated_At = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BGs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Updated_At = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Industrys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Updated_At = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Industrys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orgs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Updated_At = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orgs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Updated_At = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Updated_At = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestInfras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Updated_At = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
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
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Updated_At = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
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
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BGId = table.Column<int>(type: "int", nullable: false),
                    Created_At = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Updated_At = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
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
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrgId = table.Column<int>(type: "int", nullable: false),
                    Created_At = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Updated_At = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
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
                name: "Citys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    Created_At = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Updated_At = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Citys_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LEId = table.Column<int>(type: "int", nullable: false),
                    Law = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deposit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TopImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarningImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FooterImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Updated_At = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
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
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OUId = table.Column<int>(type: "int", nullable: false),
                    Created_At = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Updated_At = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
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
                columns: new[] { "Id", "Created_At", "Desc", "IsActive", "IsDeleted", "Title", "Updated_At" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "BG 1 Desc", false, false, "BG 1", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 2, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "BG 2 Desc", false, false, "BG 2", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 3, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "BG 3 Desc", false, false, "BG 3", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "Id", "Created_At", "Desc", "IsActive", "IsDeleted", "Title", "Updated_At" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "Bank 1 Desc", false, false, "Bank 1", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 2, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "Bank 2 Desc", false, false, "Bank 2", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 3, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "Bank 3 Desc", false, false, "Bank 3", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Created_At", "Desc", "IsActive", "IsDeleted", "Title", "Updated_At" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "Brand 1 Desc", false, false, "Brand 1", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 2, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "Brand 2 Desc", false, false, "Brand 2", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 3, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "Brand 3 Desc", false, false, "Brand 3", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Industrys",
                columns: new[] { "Id", "Created_At", "Desc", "IsActive", "IsDeleted", "Title", "Updated_At" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "Industry 1 Desc", false, false, "Industry 1", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 2, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "Industry 2 Desc", false, false, "Industry 2", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 3, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "Industry 3 Desc", false, false, "Industry 3", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Orgs",
                columns: new[] { "Id", "Created_At", "Desc", "IsActive", "IsDeleted", "Title", "Updated_At" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "Org 1 Desc", false, false, "Org 1", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 2, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "Org 2 Desc", false, false, "Org 2", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 3, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "Org 3 Desc", false, false, "Org 3", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Professions",
                columns: new[] { "Id", "Created_At", "Desc", "IsActive", "IsDeleted", "Title", "Updated_At" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "Profession 1 Desc", false, false, "Profession 1", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 2, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "Profession 2 Desc", false, false, "Profession 2", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 3, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "Profession 3 Desc", false, false, "Profession 3", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Created_At", "Desc", "IsActive", "IsDeleted", "Title", "Updated_At" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "State 1 Desc", false, false, "State 1", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 2, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "State 2 Desc", false, false, "State 2", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 3, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "State 3 Desc", false, false, "State 3", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "TestInfras",
                columns: new[] { "Id", "Created_At", "Desc", "IsActive", "IsDeleted", "Title", "Updated_At" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "TestInfra 1 Desc", false, false, "TestInfra 1", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 2, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "TestInfra 2 Desc", false, false, "TestInfra 2", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 3, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "TestInfra 3 Desc", false, false, "TestInfra 3", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "TestProjs",
                columns: new[] { "Id", "Created_At", "Desc", "IsActive", "IsDeleted", "Title", "Updated_At" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "TestProj 1 Desc", false, false, "TestProj 1", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 2, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "TestProj 2 Desc", false, false, "TestProj 2", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 3, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "TestProj 3 Desc", false, false, "TestProj 3", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Citys",
                columns: new[] { "Id", "Created_At", "Desc", "IsActive", "IsDeleted", "StateId", "Title", "Updated_At" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "City 1 Desc", false, false, 1, "City 1", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 2, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "City 2 Desc", false, false, 2, "City 2", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 3, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "City 3 Desc", false, false, 3, "City 3", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "LEs",
                columns: new[] { "Id", "BGId", "Created_At", "Desc", "IsActive", "IsDeleted", "Title", "Updated_At" },
                values: new object[,]
                {
                    { 1, 1, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "LE 1 Desc", false, false, "LE 1", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 2, 2, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "LE 2 Desc", false, false, "LE 2", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 3, 3, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "LE 3 Desc", false, false, "LE 3", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Systemzs",
                columns: new[] { "Id", "Created_At", "Desc", "IsActive", "IsDeleted", "OrgId", "Title", "Updated_At" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "Systemz 1 Desc", false, false, 1, "Systemz 1", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 2, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "Systemz 2 Desc", false, false, 2, "Systemz 2", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 3, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "Systemz 3 Desc", false, false, 3, "Systemz 3", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "OUs",
                columns: new[] { "Id", "Address", "Created_At", "Deposit", "Desc", "FooterImg", "IsActive", "IsDeleted", "LEId", "Law", "LogoImg", "Title", "TopImg", "Updated_At", "WarningImg" },
                values: new object[,]
                {
                    { 1, "OUAddress", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "OUDeposit", "OU 1 Desc", "OUFooterImg", false, false, 1, "OULaw", "OULogoImg", "OU 1", "OUTopImg", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "OUWarningImg" },
                    { 2, "OUAddress", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "OUDeposit", "OU 2 Desc", "OUFooterImg", false, false, 2, "OULaw", "OULogoImg", "OU 2", "OUTopImg", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "OUWarningImg" },
                    { 3, "OUAddress", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "OUDeposit", "OU 3 Desc", "OUFooterImg", false, false, 3, "OULaw", "OULogoImg", "OU 3", "OUTopImg", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "OUWarningImg" }
                });

            migrationBuilder.InsertData(
                table: "SUs",
                columns: new[] { "Id", "Created_At", "Desc", "IsActive", "IsDeleted", "OUId", "Title", "Updated_At" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "SU 1 Desc", false, false, 1, "SU 1", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 2, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "SU 2 Desc", false, false, 2, "SU 2", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) },
                    { 3, new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)), "SU 3 Desc", false, false, 3, "SU 3", new DateTimeOffset(new DateTime(2025, 2, 10, 8, 21, 57, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0)) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Citys_StateId",
                table: "Citys",
                column: "StateId");

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
                name: "Banks");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Citys");

            migrationBuilder.DropTable(
                name: "Industrys");

            migrationBuilder.DropTable(
                name: "Professions");

            migrationBuilder.DropTable(
                name: "SUs");

            migrationBuilder.DropTable(
                name: "Systemzs");

            migrationBuilder.DropTable(
                name: "TestInfras");

            migrationBuilder.DropTable(
                name: "TestProjs");

            migrationBuilder.DropTable(
                name: "States");

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
