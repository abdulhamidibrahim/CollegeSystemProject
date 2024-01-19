using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollegeSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddingFileTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lecture_Assignment_Answers_Lecture_Assignments_1",
                table: "Lecture_Assignment_Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Lecture_Assignments_Courses_CourseId",
                table: "Lecture_Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Section_Assignment_Answers_Section_Assignments",
                table: "Section_Assignment_Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Section_Assignments_Courses_CourseId",
                table: "Section_Assignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Section_Assignments",
                table: "Section_Assignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lecture_Assignments",
                table: "Lecture_Assignments");

            migrationBuilder.DropColumn(
                name: "img",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "file",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "description",
                table: "Section_Assignments");

            migrationBuilder.DropColumn(
                name: "file",
                table: "Section_Assignments");

            migrationBuilder.DropColumn(
                name: "title",
                table: "Section_Assignments");

            migrationBuilder.DropColumn(
                name: "file",
                table: "Section_Assignment_Answers");

            migrationBuilder.DropColumn(
                name: "file",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "description",
                table: "Lecture_Assignments");

            migrationBuilder.DropColumn(
                name: "file",
                table: "Lecture_Assignments");

            migrationBuilder.DropColumn(
                name: "title",
                table: "Lecture_Assignments");

            migrationBuilder.DropColumn(
                name: "file",
                table: "Lecture_Assignment_Answers");

            migrationBuilder.DropColumn(
                name: "img",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "file",
                table: "Assignments");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Section_Assignments",
                newName: "CourseId1");

            migrationBuilder.RenameIndex(
                name: "IX_Section_Assignments_CourseId",
                table: "Section_Assignments",
                newName: "IX_Section_Assignments_CourseId1");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Lecture_Assignments",
                newName: "CourseId1");

            migrationBuilder.RenameIndex(
                name: "IX_Lecture_Assignments_CourseId",
                table: "Lecture_Assignments",
                newName: "IX_Lecture_Assignments_CourseId1");

            // migrationBuilder.AlterColumn<long>(
            //     name: "section_assignment_id",
            //     table: "Section_Assignments",
            //     type: "bigint",
            //     nullable: false,
            //     oldClrType: typeof(long),
            //     oldType: "bigint")
            //     .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<long>(
                name: "assignment_id",
                table: "Section_Assignments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "FileId",
                table: "Section_Assignment_Answers",
                type: "int",
                nullable: true);

            // migrationBuilder.AlterColumn<long>(
            //     name: "lecture_assignment_id",
            //     table: "Lecture_Assignments",
            //     type: "bigint",
            //     nullable: false,
            //     oldClrType: typeof(long),
            //     oldType: "bigint")
            //     .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<long>(
                name: "assignment_id",
                table: "Lecture_Assignments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "FileId",
                table: "Lecture_Assignment_Answers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FileId",
                table: "Assignments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Section_Assignments",
                table: "Section_Assignments",
                column: "assignment_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lecture_Assignments",
                table: "Lecture_Assignments",
                column: "assignment_id");

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LectureId = table.Column<long>(type: "bigint", nullable: false),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    StudentId = table.Column<long>(type: "bigint", nullable: false),
                    SectionId = table.Column<long>(type: "bigint", nullable: false),
                    AssignmentId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assignments_Files",
                        column: x => x.AssignmentId,
                        principalTable: "Assignments",
                        principalColumn: "assignment_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Courses_Files",
                        column: x => x.AssignmentId,
                        principalTable: "Courses",
                        principalColumn: "course_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Files_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lecture_Files",
                        column: x => x.LectureId,
                        principalTable: "Lectures",
                        principalColumn: "lecture_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sections_Files",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "sections_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Section_Assignment_Answers_FileId",
                table: "Section_Assignment_Answers",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_Lecture_Assignment_Answers_FileId",
                table: "Lecture_Assignment_Answers",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_AssignmentId",
                table: "Files",
                column: "AssignmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Files_LectureId",
                table: "Files",
                column: "LectureId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_SectionId",
                table: "Files",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_StudentId",
                table: "Files",
                column: "StudentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Lecture_Assignment_Answers_Files_FileId",
                table: "Lecture_Assignment_Answers",
                column: "FileId",
                principalTable: "Files",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lecture_Assignment_Answers_Lecture_Assignments_1",
                table: "Lecture_Assignment_Answers",
                column: "lecture_assignment_id",
                principalTable: "Lecture_Assignments",
                principalColumn: "assignment_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lecture_Assignments_Assignments_assignment_id",
                table: "Lecture_Assignments",
                column: "assignment_id",
                principalTable: "Assignments",
                principalColumn: "assignment_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lecture_Assignments_Courses_CourseId1",
                table: "Lecture_Assignments",
                column: "CourseId1",
                principalTable: "Courses",
                principalColumn: "course_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Section_Assignment_Answers_Files_FileId",
                table: "Section_Assignment_Answers",
                column: "FileId",
                principalTable: "Files",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Section_Assignment_Answers_Section_Assignments",
                table: "Section_Assignment_Answers",
                column: "section_assignment_id",
                principalTable: "Section_Assignments",
                principalColumn: "assignment_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Section_Assignments_Assignments_assignment_id",
                table: "Section_Assignments",
                column: "assignment_id",
                principalTable: "Assignments",
                principalColumn: "assignment_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Section_Assignments_Courses_CourseId1",
                table: "Section_Assignments",
                column: "CourseId1",
                principalTable: "Courses",
                principalColumn: "course_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lecture_Assignment_Answers_Files_FileId",
                table: "Lecture_Assignment_Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Lecture_Assignment_Answers_Lecture_Assignments_1",
                table: "Lecture_Assignment_Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Lecture_Assignments_Assignments_assignment_id",
                table: "Lecture_Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Lecture_Assignments_Courses_CourseId1",
                table: "Lecture_Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Section_Assignment_Answers_Files_FileId",
                table: "Section_Assignment_Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Section_Assignment_Answers_Section_Assignments",
                table: "Section_Assignment_Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Section_Assignments_Assignments_assignment_id",
                table: "Section_Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Section_Assignments_Courses_CourseId1",
                table: "Section_Assignments");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Section_Assignments",
                table: "Section_Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Section_Assignment_Answers_FileId",
                table: "Section_Assignment_Answers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lecture_Assignments",
                table: "Lecture_Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Lecture_Assignment_Answers_FileId",
                table: "Lecture_Assignment_Answers");

            migrationBuilder.DropColumn(
                name: "assignment_id",
                table: "Section_Assignments");

            migrationBuilder.DropColumn(
                name: "FileId",
                table: "Section_Assignment_Answers");

            migrationBuilder.DropColumn(
                name: "assignment_id",
                table: "Lecture_Assignments");

            migrationBuilder.DropColumn(
                name: "FileId",
                table: "Lecture_Assignment_Answers");

            migrationBuilder.DropColumn(
                name: "FileId",
                table: "Assignments");

            migrationBuilder.RenameColumn(
                name: "CourseId1",
                table: "Section_Assignments",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Section_Assignments_CourseId1",
                table: "Section_Assignments",
                newName: "IX_Section_Assignments_CourseId");

            migrationBuilder.RenameColumn(
                name: "CourseId1",
                table: "Lecture_Assignments",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Lecture_Assignments_CourseId1",
                table: "Lecture_Assignments",
                newName: "IX_Lecture_Assignments_CourseId");

            migrationBuilder.AddColumn<string>(
                name: "img",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "file",
                table: "Sections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "section_assignment_id",
                table: "Section_Assignments",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Section_Assignments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "file",
                table: "Section_Assignments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "title",
                table: "Section_Assignments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "file",
                table: "Section_Assignment_Answers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "file",
                table: "Lectures",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "lecture_assignment_id",
                table: "Lecture_Assignments",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Lecture_Assignments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "file",
                table: "Lecture_Assignments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "title",
                table: "Lecture_Assignments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "file",
                table: "Lecture_Assignment_Answers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "img",
                table: "Courses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "file",
                table: "Assignments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Section_Assignments",
                table: "Section_Assignments",
                column: "section_assignment_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lecture_Assignments",
                table: "Lecture_Assignments",
                column: "lecture_assignment_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lecture_Assignment_Answers_Lecture_Assignments_1",
                table: "Lecture_Assignment_Answers",
                column: "lecture_assignment_id",
                principalTable: "Lecture_Assignments",
                principalColumn: "lecture_assignment_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lecture_Assignments_Courses_CourseId",
                table: "Lecture_Assignments",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "course_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Section_Assignment_Answers_Section_Assignments",
                table: "Section_Assignment_Answers",
                column: "section_assignment_id",
                principalTable: "Section_Assignments",
                principalColumn: "section_assignment_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Section_Assignments_Courses_CourseId",
                table: "Section_Assignments",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "course_id");
        }
    }
}
