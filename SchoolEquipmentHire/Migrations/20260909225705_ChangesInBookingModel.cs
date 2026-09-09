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
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_AspNetUsers_AppUserId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_AppUserId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Booking");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Booking",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Booking_AppUserId",
                table: "Booking",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_AspNetUsers_AppUserId",
                table: "Booking",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
