using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolEquipmentHire.Migrations
{
    /// <inheritdoc />
    public partial class BookingModelChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_AspNetUsers_UserId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Booking");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Booking",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Booking",
                newName: "BookingID");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_UserId",
                table: "Booking",
                newName: "IX_Booking_UserID");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Booking",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_AspNetUsers_UserID",
                table: "Booking",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_AspNetUsers_UserID",
                table: "Booking");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Booking",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "BookingID",
                table: "Booking",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_UserID",
                table: "Booking",
                newName: "IX_Booking_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Booking",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_AspNetUsers_UserId",
                table: "Booking",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
