using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrivingSchoolApp.Migrations
{
    /// <inheritdoc />
    public partial class AddPersonSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Person_StudentId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Person_StudentId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_DrivingLessons_Person_InstructorId",
                table: "DrivingLessons");

            migrationBuilder.DropForeignKey(
                name: "FK_DrivingLessons_Person_StudentId",
                table: "DrivingLessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Person_TeacherId",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_StudyGroups_GroupId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Vehicles_AssignedVehicleId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_PracticeExams_Person_InstructorId",
                table: "PracticeExams");

            migrationBuilder.DropForeignKey(
                name: "FK_PracticeExams_Person_StudentId",
                table: "PracticeExams");

            migrationBuilder.DropForeignKey(
                name: "FK_TheoryExams_Person_StudentId",
                table: "TheoryExams");

            migrationBuilder.DropForeignKey(
                name: "FK_TheoryExams_Person_TeacherId",
                table: "TheoryExams");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_Person_PersonId",
                table: "UserProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                table: "Person");

            migrationBuilder.RenameTable(
                name: "Person",
                newName: "Persons");

            migrationBuilder.RenameIndex(
                name: "IX_Person_GroupId",
                table: "Persons",
                newName: "IX_Persons_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Person_AssignedVehicleId",
                table: "Persons",
                newName: "IX_Persons_AssignedVehicleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Persons_StudentId",
                table: "Applications",
                column: "StudentId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Persons_StudentId",
                table: "Attendances",
                column: "StudentId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DrivingLessons_Persons_InstructorId",
                table: "DrivingLessons",
                column: "InstructorId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DrivingLessons_Persons_StudentId",
                table: "DrivingLessons",
                column: "StudentId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Persons_TeacherId",
                table: "Lessons",
                column: "TeacherId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_StudyGroups_GroupId",
                table: "Persons",
                column: "GroupId",
                principalTable: "StudyGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Vehicles_AssignedVehicleId",
                table: "Persons",
                column: "AssignedVehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PracticeExams_Persons_InstructorId",
                table: "PracticeExams",
                column: "InstructorId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PracticeExams_Persons_StudentId",
                table: "PracticeExams",
                column: "StudentId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TheoryExams_Persons_StudentId",
                table: "TheoryExams",
                column: "StudentId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TheoryExams_Persons_TeacherId",
                table: "TheoryExams",
                column: "TeacherId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_Persons_PersonId",
                table: "UserProfiles",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Persons_StudentId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Persons_StudentId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_DrivingLessons_Persons_InstructorId",
                table: "DrivingLessons");

            migrationBuilder.DropForeignKey(
                name: "FK_DrivingLessons_Persons_StudentId",
                table: "DrivingLessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Persons_TeacherId",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_StudyGroups_GroupId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Vehicles_AssignedVehicleId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_PracticeExams_Persons_InstructorId",
                table: "PracticeExams");

            migrationBuilder.DropForeignKey(
                name: "FK_PracticeExams_Persons_StudentId",
                table: "PracticeExams");

            migrationBuilder.DropForeignKey(
                name: "FK_TheoryExams_Persons_StudentId",
                table: "TheoryExams");

            migrationBuilder.DropForeignKey(
                name: "FK_TheoryExams_Persons_TeacherId",
                table: "TheoryExams");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_Persons_PersonId",
                table: "UserProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "Person");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_GroupId",
                table: "Person",
                newName: "IX_Person_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_AssignedVehicleId",
                table: "Person",
                newName: "IX_Person_AssignedVehicleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                table: "Person",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Person_StudentId",
                table: "Applications",
                column: "StudentId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Person_StudentId",
                table: "Attendances",
                column: "StudentId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DrivingLessons_Person_InstructorId",
                table: "DrivingLessons",
                column: "InstructorId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DrivingLessons_Person_StudentId",
                table: "DrivingLessons",
                column: "StudentId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Person_TeacherId",
                table: "Lessons",
                column: "TeacherId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_StudyGroups_GroupId",
                table: "Person",
                column: "GroupId",
                principalTable: "StudyGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Vehicles_AssignedVehicleId",
                table: "Person",
                column: "AssignedVehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PracticeExams_Person_InstructorId",
                table: "PracticeExams",
                column: "InstructorId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PracticeExams_Person_StudentId",
                table: "PracticeExams",
                column: "StudentId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TheoryExams_Person_StudentId",
                table: "TheoryExams",
                column: "StudentId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TheoryExams_Person_TeacherId",
                table: "TheoryExams",
                column: "TeacherId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_Person_PersonId",
                table: "UserProfiles",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
