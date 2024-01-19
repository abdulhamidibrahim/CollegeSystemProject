using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollegeSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAnswerCourseRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Courses",
                table: "Answers");

            migrationBuilder.RenameColumn(
                name: "course_id",
                table: "Answers",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_course_id",
                table: "Answers",
                newName: "IX_Answers_CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Courses_CourseId",
                table: "Answers",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "course_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Courses_CourseId",
                table: "Answers");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Answers",
                newName: "course_id");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_CourseId",
                table: "Answers",
                newName: "IX_Answers_course_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Courses",
                table: "Answers",
                column: "course_id",
                principalTable: "Courses",
                principalColumn: "course_id");
        }
    }
}
