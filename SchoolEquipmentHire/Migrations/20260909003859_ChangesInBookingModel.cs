using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolEquipmentHire.Migrations
{
    /// <inheritdoc />
    public partial class ChangesInBookingModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Booking",
                newName: "BookingID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookingID",
                table: "Booking",
                newName: "ID");
        }
    }
}
