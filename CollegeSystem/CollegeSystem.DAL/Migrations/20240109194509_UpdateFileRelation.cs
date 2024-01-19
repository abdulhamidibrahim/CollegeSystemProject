using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollegeSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFileRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Lectures_LectureId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_Student_StudentId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_AssignmentId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_StudentId",
                table: "Files");

            migrationBuilder.AlterColumn<long>(
                name: "StudentId",
                table: "Files",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "LectureId",
                table: "Files",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_Files_AssignmentId",
                table: "Files",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_StudentId",
                table: "Files",
                column: "StudentId",
                unique: true,
                filter: "[StudentId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Lectures_LectureId",
                table: "Files",
                column: "LectureId",
                principalTable: "Lectures",
                principalColumn: "lecture_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Student_StudentId",
                table: "Files",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Lectures_LectureId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_Student_StudentId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_AssignmentId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_StudentId",
                table: "Files");

            migrationBuilder.AlterColumn<long>(
                name: "StudentId",
                table: "Files",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "LectureId",
                table: "Files",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Files_AssignmentId",
                table: "Files",
                column: "AssignmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Files_StudentId",
                table: "Files",
                column: "StudentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Lectures_LectureId",
                table: "Files",
                column: "LectureId",
                principalTable: "Lectures",
                principalColumn: "lecture_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Student_StudentId",
                table: "Files",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
