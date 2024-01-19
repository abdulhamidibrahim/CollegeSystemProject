using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollegeSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class GetRidOfFileRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Answers_Assignments",
                table: "Assignment_Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Courses",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Answers_Files",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Files",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Files",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Files",
                table: "Files");

            migrationBuilder.DropTable(
                name: "Lecture_Assignment_Answers");

            migrationBuilder.DropTable(
                name: "Section_Assignment_Answers");

            migrationBuilder.DropTable(
                name: "Lecture_Assignments");

            migrationBuilder.DropTable(
                name: "Section_Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Files_AssignmentAnswerId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_AssignmentId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_CourseId",
                table: "Files");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Assignment_Answers",
                table: "Assignment_Answers");

            migrationBuilder.RenameColumn(
                name: "AssignmentId",
                table: "Files",
                newName: "SectionAssignmentId");

            migrationBuilder.RenameColumn(
                name: "AssignmentAnswerId",
                table: "Files",
                newName: "SectionAssignmenAnswertId");

            migrationBuilder.RenameColumn(
                name: "course_id",
                table: "Assignments",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Assignments_course_id",
                table: "Assignments",
                newName: "IX_Assignments_CourseId");

            migrationBuilder.AddColumn<byte[]>(
                name: "FileContent",
                table: "Sections",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<string>(
                name: "FileExtension",
                table: "Sections",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Sections",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<long>(
                name: "SectionId",
                table: "Files",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "LectureAssignmentAnswerId",
                table: "Files",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LectureAssignmentId",
                table: "Files",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "FileContent",
                table: "Assignments",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<string>(
                name: "FileExtension",
                table: "Assignments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Assignments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "LectureId",
                table: "Assignments",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SectionId",
                table: "Assignments",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "assignment_id",
                table: "Assignment_Answers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            // migrationBuilder.AlterColumn<long>(
            //     name: "assignment_answer_id",
            //     table: "Assignment_Answers",
            //     type: "bigint",
            //     nullable: false,
            //     oldClrType: typeof(long),
            //     oldType: "bigint")
            //     .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<long>(
                name: "StudentId",
                table: "Assignment_Answers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<byte[]>(
                name: "FileContent",
                table: "Assignment_Answers",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<string>(
                name: "FileExtension",
                table: "Assignment_Answers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Assignment_Answers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assignment_Answers",
                table: "Assignment_Answers",
                columns: new[] { "assignment_answer_id", "StudentId" });
            

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_LectureId",
                table: "Assignments",
                column: "LectureId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_SectionId",
                table: "Assignments",
                column: "SectionId",
                unique: true,
                filter: "[SectionId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_Answers_Assignments",
                table: "Assignment_Answers",
                column: "assignment_id",
                principalTable: "Assignments",
                principalColumn: "assignment_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_Answers_Student",
                table: "Assignment_Answers",
                column: "assignment_answer_id",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Courses_CourseId",
                table: "Assignments",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "course_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Lectures_LectureId",
                table: "Assignments",
                column: "LectureId",
                principalTable: "Lectures",
                principalColumn: "lecture_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Sections_SectionId",
                table: "Assignments",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "sections_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Images",
                table: "Files",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "course_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Sections_SectionId",
                table: "Files",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "sections_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Answers_Assignments",
                table: "Assignment_Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Answers_Student",
                table: "Assignment_Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Courses_CourseId",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Lectures_LectureId",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Sections_SectionId",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Images",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_Sections_SectionId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_CourseId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_LectureId",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_SectionId",
                table: "Assignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Assignment_Answers",
                table: "Assignment_Answers");

            migrationBuilder.DropColumn(
                name: "FileContent",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "FileExtension",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "LectureAssignmentAnswerId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "LectureAssignmentId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "FileContent",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "FileExtension",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "LectureId",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Assignment_Answers");

            migrationBuilder.DropColumn(
                name: "FileContent",
                table: "Assignment_Answers");

            migrationBuilder.DropColumn(
                name: "FileExtension",
                table: "Assignment_Answers");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Assignment_Answers");

            migrationBuilder.RenameColumn(
                name: "SectionAssignmentId",
                table: "Files",
                newName: "AssignmentId");

            migrationBuilder.RenameColumn(
                name: "SectionAssignmenAnswertId",
                table: "Files",
                newName: "AssignmentAnswerId");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Assignments",
                newName: "course_id");

            migrationBuilder.RenameIndex(
                name: "IX_Assignments_CourseId",
                table: "Assignments",
                newName: "IX_Assignments_course_id");

            migrationBuilder.AlterColumn<long>(
                name: "SectionId",
                table: "Files",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "assignment_id",
                table: "Assignment_Answers",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "assignment_answer_id",
                table: "Assignment_Answers",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assignment_Answers",
                table: "Assignment_Answers",
                column: "assignment_answer_id");

            migrationBuilder.CreateTable(
                name: "Lecture_Assignments",
                columns: table => new
                {
                    assignment_id = table.Column<long>(type: "bigint", nullable: false),
                    lecture_id = table.Column<long>(type: "bigint", nullable: true),
                    CourseId1 = table.Column<long>(type: "bigint", nullable: true),
                    lecture_assignment_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecture_Assignments", x => x.assignment_id);
                    table.ForeignKey(
                        name: "FK_Lecture_Assignments_Assignments_assignment_id",
                        column: x => x.assignment_id,
                        principalTable: "Assignments",
                        principalColumn: "assignment_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lecture_Assignments_Courses_CourseId1",
                        column: x => x.CourseId1,
                        principalTable: "Courses",
                        principalColumn: "course_id");
                    table.ForeignKey(
                        name: "FK_Lecture_Assignments_Lectures",
                        column: x => x.lecture_id,
                        principalTable: "Lectures",
                        principalColumn: "lecture_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Section_Assignments",
                columns: table => new
                {
                    assignment_id = table.Column<long>(type: "bigint", nullable: false),
                    section_id = table.Column<long>(type: "bigint", nullable: true),
                    CourseId1 = table.Column<long>(type: "bigint", nullable: true),
                    section_assignment_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Section_Assignments", x => x.assignment_id);
                    table.ForeignKey(
                        name: "FK_Section_Assignments_Assignments_assignment_id",
                        column: x => x.assignment_id,
                        principalTable: "Assignments",
                        principalColumn: "assignment_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Section_Assignments_Courses_CourseId1",
                        column: x => x.CourseId1,
                        principalTable: "Courses",
                        principalColumn: "course_id");
                    table.ForeignKey(
                        name: "FK_Section_Assignments_Sections",
                        column: x => x.section_id,
                        principalTable: "Sections",
                        principalColumn: "sections_id");
                });

            migrationBuilder.CreateTable(
                name: "Lecture_Assignment_Answers",
                columns: table => new
                {
                    assignment_answer_id = table.Column<long>(type: "bigint", nullable: false),
                    lecture_assignment_id = table.Column<long>(type: "bigint", nullable: true),
                    StudentId = table.Column<long>(type: "bigint", nullable: true),
                    lecture_assignment_answer_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecture_Assignment_Answers", x => x.assignment_answer_id);
                    table.ForeignKey(
                        name: "FK_Lecture_Assignment_Answers_Assignment_Answers_assignment_answer_id",
                        column: x => x.assignment_answer_id,
                        principalTable: "Assignment_Answers",
                        principalColumn: "assignment_answer_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lecture_Assignment_Answers_Lecture_Assignments_1",
                        column: x => x.lecture_assignment_id,
                        principalTable: "Lecture_Assignments",
                        principalColumn: "assignment_id");
                    table.ForeignKey(
                        name: "FK_Lecture_Assignment_Answers_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Section_Assignment_Answers",
                columns: table => new
                {
                    section_assignment_answer_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    section_assignment_id = table.Column<long>(type: "bigint", nullable: true),
                    StudentId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Section_Assignment_Answers", x => x.section_assignment_answer_id);
                    table.ForeignKey(
                        name: "FK_Section_Assignment_Answers_Section_Assignments",
                        column: x => x.section_assignment_id,
                        principalTable: "Section_Assignments",
                        principalColumn: "assignment_id");
                    table.ForeignKey(
                        name: "FK_Section_Assignment_Answers_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Files_AssignmentAnswerId",
                table: "Files",
                column: "AssignmentAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_AssignmentId",
                table: "Files",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_CourseId",
                table: "Files",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Lecture_Assignment_Answers_lecture_assignment_id",
                table: "Lecture_Assignment_Answers",
                column: "lecture_assignment_id");

            migrationBuilder.CreateIndex(
                name: "IX_Lecture_Assignment_Answers_StudentId",
                table: "Lecture_Assignment_Answers",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Lecture_Assignments_CourseId1",
                table: "Lecture_Assignments",
                column: "CourseId1");

            migrationBuilder.CreateIndex(
                name: "IX_Lecture_Assignments_lecture_id",
                table: "Lecture_Assignments",
                column: "lecture_id");

            migrationBuilder.CreateIndex(
                name: "IX_Section_Assignment_Answers_section_assignment_id",
                table: "Section_Assignment_Answers",
                column: "section_assignment_id");

            migrationBuilder.CreateIndex(
                name: "IX_Section_Assignment_Answers_StudentId",
                table: "Section_Assignment_Answers",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_Assignments_CourseId1",
                table: "Section_Assignments",
                column: "CourseId1");

            migrationBuilder.CreateIndex(
                name: "IX_Section_Assignments_section_id",
                table: "Section_Assignments",
                column: "section_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_Answers_Assignments",
                table: "Assignment_Answers",
                column: "assignment_id",
                principalTable: "Assignments",
                principalColumn: "assignment_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Courses",
                table: "Assignments",
                column: "course_id",
                principalTable: "Courses",
                principalColumn: "course_id");

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
                name: "FK_Courses_Files",
                table: "Files",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "course_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Files",
                table: "Files",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "sections_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
