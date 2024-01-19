using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollegeSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCourseFileRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Files",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Lecture_Files",
                table: "Files");

            migrationBuilder.CreateIndex(
                name: "IX_Files_CourseId",
                table: "Files",
                column: "CourseId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Files",
                table: "Files",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "course_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Lectures_LectureId",
                table: "Files",
                column: "LectureId",
                principalTable: "Lectures",
                principalColumn: "lecture_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Files",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_Lectures_LectureId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_CourseId",
                table: "Files");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Files",
                table: "Files",
                column: "AssignmentId",
                principalTable: "Courses",
                principalColumn: "course_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lecture_Files",
                table: "Files",
                column: "LectureId",
                principalTable: "Lectures",
                principalColumn: "lecture_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
