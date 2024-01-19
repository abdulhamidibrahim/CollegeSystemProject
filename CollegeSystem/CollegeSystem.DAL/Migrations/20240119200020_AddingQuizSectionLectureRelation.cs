using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollegeSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddingQuizSectionLectureRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quizzes_Courses",
                table: "Quizzes");

            migrationBuilder.RenameColumn(
                name: "course_id",
                table: "Quizzes",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Quizzes_course_id",
                table: "Quizzes",
                newName: "IX_Quizzes_CourseId");

            migrationBuilder.AddColumn<long>(
                name: "LectureId",
                table: "Quizzes",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SectionId",
                table: "Quizzes",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_LectureId",
                table: "Quizzes",
                column: "LectureId");

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_SectionId",
                table: "Quizzes",
                column: "SectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quizzes_Courses_CourseId",
                table: "Quizzes",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "course_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Quizzes_Lectures_LectureId",
                table: "Quizzes",
                column: "LectureId",
                principalTable: "Lectures",
                principalColumn: "lecture_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Quizzes_Sections_SectionId",
                table: "Quizzes",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "sections_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quizzes_Courses_CourseId",
                table: "Quizzes");

            migrationBuilder.DropForeignKey(
                name: "FK_Quizzes_Lectures_LectureId",
                table: "Quizzes");

            migrationBuilder.DropForeignKey(
                name: "FK_Quizzes_Sections_SectionId",
                table: "Quizzes");

            migrationBuilder.DropIndex(
                name: "IX_Quizzes_LectureId",
                table: "Quizzes");

            migrationBuilder.DropIndex(
                name: "IX_Quizzes_SectionId",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "LectureId",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "Quizzes");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Quizzes",
                newName: "course_id");

            migrationBuilder.RenameIndex(
                name: "IX_Quizzes_CourseId",
                table: "Quizzes",
                newName: "IX_Quizzes_course_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Quizzes_Courses",
                table: "Quizzes",
                column: "course_id",
                principalTable: "Courses",
                principalColumn: "course_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
