using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollegeSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFileAssignmentsRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Files",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Lecture_Assignment_Answers_Files_FileId",
                table: "Lecture_Assignment_Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Section_Assignment_Answers_Files_FileId",
                table: "Section_Assignment_Answers");

            migrationBuilder.DropIndex(
                name: "IX_Section_Assignment_Answers_FileId",
                table: "Section_Assignment_Answers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lecture_Assignment_Answers",
                table: "Lecture_Assignment_Answers");

            migrationBuilder.DropIndex(
                name: "IX_Lecture_Assignment_Answers_FileId",
                table: "Lecture_Assignment_Answers");

            migrationBuilder.DropIndex(
                name: "IX_Files_CourseId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "img",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "FileId",
                table: "Section_Assignment_Answers");

            migrationBuilder.DropColumn(
                name: "FileId",
                table: "Lecture_Assignment_Answers");

            migrationBuilder.DropColumn(
                name: "FileId",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "file",
                table: "Assignment_Answers");

            // migrationBuilder.AlterColumn<long>(
            //     name: "lecture_assignment_answer_id",
            //     table: "Lecture_Assignment_Answers",
            //     type: "bigint",
            //     nullable: false,
            //     oldClrType: typeof(long),
            //     oldType: "bigint")
            //     .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<long>(
                name: "assignment_answer_id",
                table: "Lecture_Assignment_Answers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "AssignmentId",
                table: "Files",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "AssignmentAnswerId",
                table: "Files",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lecture_Assignment_Answers",
                table: "Lecture_Assignment_Answers",
                column: "assignment_answer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Files_AssignmentAnswerId",
                table: "Files",
                column: "AssignmentAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_CourseId",
                table: "Files",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_Answers_Files",
                table: "Files",
                column: "AssignmentAnswerId",
                principalTable: "Assignment_Answers",
                principalColumn: "assignment_answer_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Files",
                table: "Files",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "assignment_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lecture_Assignment_Answers_Assignment_Answers_assignment_answer_id",
                table: "Lecture_Assignment_Answers",
                column: "assignment_answer_id",
                principalTable: "Assignment_Answers",
                principalColumn: "assignment_answer_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Answers_Files",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Files",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Lecture_Assignment_Answers_Assignment_Answers_assignment_answer_id",
                table: "Lecture_Assignment_Answers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lecture_Assignment_Answers",
                table: "Lecture_Assignment_Answers");

            migrationBuilder.DropIndex(
                name: "IX_Files_AssignmentAnswerId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_CourseId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "assignment_answer_id",
                table: "Lecture_Assignment_Answers");

            migrationBuilder.DropColumn(
                name: "AssignmentAnswerId",
                table: "Files");

            migrationBuilder.AddColumn<string>(
                name: "img",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FileId",
                table: "Section_Assignment_Answers",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "lecture_assignment_answer_id",
                table: "Lecture_Assignment_Answers",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "FileId",
                table: "Lecture_Assignment_Answers",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AssignmentId",
                table: "Files",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FileId",
                table: "Assignments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "file",
                table: "Assignment_Answers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lecture_Assignment_Answers",
                table: "Lecture_Assignment_Answers",
                column: "lecture_assignment_answer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Section_Assignment_Answers_FileId",
                table: "Section_Assignment_Answers",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_Lecture_Assignment_Answers_FileId",
                table: "Lecture_Assignment_Answers",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_CourseId",
                table: "Files",
                column: "CourseId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Files",
                table: "Files",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "assignment_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lecture_Assignment_Answers_Files_FileId",
                table: "Lecture_Assignment_Answers",
                column: "FileId",
                principalTable: "Files",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Section_Assignment_Answers_Files_FileId",
                table: "Section_Assignment_Answers",
                column: "FileId",
                principalTable: "Files",
                principalColumn: "Id");
        }
    }
}
