using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrivingSchoolApp.Migrations
{
    /// <inheritdoc />
    public partial class AddIdentityToPerson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Persons",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_IdentityUserId",
                table: "Persons",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_AspNetUsers_IdentityUserId",
                table: "Persons",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_AspNetUsers_IdentityUserId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_IdentityUserId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Persons");
        }
    }
}
