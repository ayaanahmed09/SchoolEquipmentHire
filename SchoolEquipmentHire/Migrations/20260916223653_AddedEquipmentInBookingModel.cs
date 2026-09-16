using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolEquipmentHire.Migrations
{
    /// <inheritdoc />
    public partial class AddedEquipmentInBookingModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 1,
                column: "ImageUrl",
                value: "~/images/Football.png");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 2,
                column: "ImageUrl",
                value: "~/images/Basketball.png");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 3,
                column: "ImageUrl",
                value: "~/images/TableTennisRacket.png");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 4,
                column: "ImageUrl",
                value: "~/images/TennisBall.png");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 5,
                column: "ImageUrl",
                value: "~/images/BadmintonRacket.png");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 6,
                column: "ImageUrl",
                value: "~/images/Cone.png");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_EquipmentID",
                table: "Booking",
                column: "EquipmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Equipment_EquipmentID",
                table: "Booking",
                column: "EquipmentID",
                principalTable: "Equipment",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Equipment_EquipmentID",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_EquipmentID",
                table: "Booking");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 1,
                column: "ImageUrl",
                value: "~/images/equipments/Football.png");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 2,
                column: "ImageUrl",
                value: "~/images/equipments/Basketball.png");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 3,
                column: "ImageUrl",
                value: "~/images/equipments/TableTennisRacket.png");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 4,
                column: "ImageUrl",
                value: "~/images/equipments/TennisBall.png");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 5,
                column: "ImageUrl",
                value: "~/images/equipments/BadmintonRacket.png");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "ID",
                keyValue: 6,
                column: "ImageUrl",
                value: "~/images/equipments/Cone.png");
        }
    }
}
