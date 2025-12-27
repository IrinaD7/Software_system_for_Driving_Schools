using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrivingSchoolApp.Migrations
{
    /// <inheritdoc />
    public partial class FixAssignedVehicle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AssignedVehicle",
                table: "Person",
                newName: "AssignedVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_AssignedVehicleId",
                table: "Person",
                column: "AssignedVehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Vehicles_AssignedVehicleId",
                table: "Person",
                column: "AssignedVehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Vehicles_AssignedVehicleId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_AssignedVehicleId",
                table: "Person");

            migrationBuilder.RenameColumn(
                name: "AssignedVehicleId",
                table: "Person",
                newName: "AssignedVehicle");
        }
    }
}
