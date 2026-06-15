using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolEquipmentHire.Migrations
{
    /// <inheritdoc />
    public partial class ChangesInUserModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstMidName",
                table: "User",
                newName: "FirstName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "User",
                newName: "FirstMidName");
        }
    }
}
