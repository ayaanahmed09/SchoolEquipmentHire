using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolEquipmentHire.Migrations
{
    /// <inheritdoc />
    public partial class AddBookingQuantity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuantityBooked",
                table: "Booking",
                newName: "Quantity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Booking",
                newName: "QuantityBooked");
        }
    }
}
