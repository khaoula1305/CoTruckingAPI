using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cotrucking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeLabelbyName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Label",
                table: "Shipments",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Label",
                table: "Countries",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "Companies",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Label",
                table: "Cities",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Shipments",
                newName: "Label");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Countries",
                newName: "Label");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Companies",
                newName: "CompanyName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Cities",
                newName: "Label");
        }
    }
}
