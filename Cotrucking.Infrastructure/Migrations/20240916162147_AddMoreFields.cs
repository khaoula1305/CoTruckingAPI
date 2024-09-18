using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cotrucking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContactInformation",
                table: "Users",
                newName: "PersonalPhoneNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PersonalPhoneNumber",
                table: "Users",
                newName: "ContactInformation");
        }
    }
}
