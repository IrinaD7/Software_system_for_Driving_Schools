using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrivingSchoolApp.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdToPerson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_AspNetUsers_IdentityUserId",
                table: "Persons");

            migrationBuilder.RenameColumn(
                name: "IdentityUserId",
                table: "Persons",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_IdentityUserId",
                table: "Persons",
                newName: "IX_Persons_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_AspNetUsers_UserId",
                table: "Persons",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_AspNetUsers_UserId",
                table: "Persons");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Persons",
                newName: "IdentityUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_UserId",
                table: "Persons",
                newName: "IX_Persons_IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_AspNetUsers_IdentityUserId",
                table: "Persons",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
