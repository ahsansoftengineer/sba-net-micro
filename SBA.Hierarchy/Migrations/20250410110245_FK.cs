using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBA.Hierarchy.Migrations
{
    /// <inheritdoc />
    public partial class FK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectzLookups_ProjectzLookupBases_ProjectzLookupBaseId",
                table: "ProjectzLookups");

            migrationBuilder.DropIndex(
                name: "IX_ProjectzLookups_ProjectzLookupBaseId",
                table: "ProjectzLookups");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectzLookups_ProjectzLookupBaseId",
                table: "ProjectzLookups",
                column: "ProjectzLookupBaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectzLookups_ProjectzLookupBases_ProjectzLookupBaseId",
                table: "ProjectzLookups",
                column: "ProjectzLookupBaseId",
                principalTable: "ProjectzLookupBases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectzLookups_ProjectzLookupBases_ProjectzLookupBaseId",
                table: "ProjectzLookups");

            migrationBuilder.DropIndex(
                name: "IX_ProjectzLookups_ProjectzLookupBaseId",
                table: "ProjectzLookups");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectzLookups_ProjectzLookupBaseId",
                table: "ProjectzLookups",
                column: "ProjectzLookupBaseId",
                unique: true,
                filter: "[ProjectzLookupBaseId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectzLookups_ProjectzLookupBases_ProjectzLookupBaseId",
                table: "ProjectzLookups",
                column: "ProjectzLookupBaseId",
                principalTable: "ProjectzLookupBases",
                principalColumn: "Id");
        }
    }
}
