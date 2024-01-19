using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollegeSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFilesProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LectureAssignmentAnswerId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "LectureAssignmentId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "SectionAssignmenAnswertId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "SectionAssignmentId",
                table: "Files");

            // migrationBuilder.AlterColumn<long>(
            //     name: "sections_id",
            //     table: "Sections",
            //     type: "bigint",
            //     nullable: false,
            //     oldClrType: typeof(long),
            //     oldType: "bigint")
            //     .Annotation("SqlServer:Identity", "1, 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.AlterColumn<long>(
            //     name: "sections_id",
            //     table: "Sections",
            //     type: "bigint",
            //     nullable: false,
            //     oldClrType: typeof(long),
            //     oldType: "bigint")
            //     .OldAnnotation("SqlServer:Identity", "1, 1");

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

            migrationBuilder.AddColumn<long>(
                name: "SectionAssignmenAnswertId",
                table: "Files",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SectionAssignmentId",
                table: "Files",
                type: "bigint",
                nullable: true);
        }
    }
}
