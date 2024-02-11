using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiteManagement.Migrations
{
    /// <inheritdoc />
    public partial class apartment_number_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Apartments_ApartmentId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Apartments_ApartmentId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "ApartmentId",
                table: "Users",
                newName: "ApartmentsId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_ApartmentId",
                table: "Users",
                newName: "IX_Users_ApartmentsId");

            migrationBuilder.RenameColumn(
                name: "ApartmentId",
                table: "Invoices",
                newName: "ApartmentsId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_ApartmentId",
                table: "Invoices",
                newName: "IX_Invoices_ApartmentsId");

            migrationBuilder.AddColumn<int>(
                name: "ApartmentNumber",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ApartmentNumber",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ApartmentNumber",
                table: "Apartments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Apartments_ApartmentsId",
                table: "Invoices",
                column: "ApartmentsId",
                principalTable: "Apartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Apartments_ApartmentsId",
                table: "Users",
                column: "ApartmentsId",
                principalTable: "Apartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Apartments_ApartmentsId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Apartments_ApartmentsId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ApartmentNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ApartmentNumber",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "ApartmentsId",
                table: "Users",
                newName: "ApartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_ApartmentsId",
                table: "Users",
                newName: "IX_Users_ApartmentId");

            migrationBuilder.RenameColumn(
                name: "ApartmentsId",
                table: "Invoices",
                newName: "ApartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_ApartmentsId",
                table: "Invoices",
                newName: "IX_Invoices_ApartmentId");

            migrationBuilder.AlterColumn<string>(
                name: "ApartmentNumber",
                table: "Apartments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Apartments_ApartmentId",
                table: "Invoices",
                column: "ApartmentId",
                principalTable: "Apartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Apartments_ApartmentId",
                table: "Users",
                column: "ApartmentId",
                principalTable: "Apartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
