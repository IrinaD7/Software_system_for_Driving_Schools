using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrivingSchoolApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateApplicationMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Applications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Passport",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Patronymic",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "PaymentDeadline",
                table: "Applications",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudyProgramId",
                table: "Applications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_StudyProgramId",
                table: "Applications",
                column: "StudyProgramId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_StudyPrograms_StudyProgramId",
                table: "Applications",
                column: "StudyProgramId",
                principalTable: "StudyPrograms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_StudyPrograms_StudyProgramId",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_StudyProgramId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "Passport",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "Patronymic",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "PaymentDeadline",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "StudyProgramId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Applications");
        }
    }
}
