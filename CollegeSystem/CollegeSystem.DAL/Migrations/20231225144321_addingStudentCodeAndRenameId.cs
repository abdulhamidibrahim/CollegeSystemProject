using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollegeSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addingStudentCodeAndRenameId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parent_AspNetUsers_parent_id",
                table: "Parent");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Student_StudentId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_AspNetUsers_parent_id",
                table: "Staff");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_AspNetUsers_parent_id",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Departments_Dept_Id",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Posts_StudentId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "parent_id",
                table: "Student",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "parent_id",
                table: "Staff",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "parent_id",
                table: "Parent",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "parent_id",
                table: "AspNetUsers",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Parent_AspNetUsers_Id",
                table: "Parent",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_AspNetUsers_Id",
                table: "Staff",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_AspNetUsers_Id",
                table: "Student",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Departments",
                table: "Student",
                column: "Dept_Id",
                principalTable: "Departments",
                principalColumn: "dept_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parent_AspNetUsers_Id",
                table: "Parent");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_AspNetUsers_Id",
                table: "Staff");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_AspNetUsers_Id",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Departments",
                table: "Student");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Student",
                newName: "parent_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Staff",
                newName: "parent_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Parent",
                newName: "parent_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AspNetUsers",
                newName: "parent_id");

            migrationBuilder.AddColumn<long>(
                name: "StudentId",
                table: "Posts",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_StudentId",
                table: "Posts",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parent_AspNetUsers_parent_id",
                table: "Parent",
                column: "parent_id",
                principalTable: "AspNetUsers",
                principalColumn: "parent_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Student_StudentId",
                table: "Posts",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "parent_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_AspNetUsers_parent_id",
                table: "Staff",
                column: "parent_id",
                principalTable: "AspNetUsers",
                principalColumn: "parent_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_AspNetUsers_parent_id",
                table: "Student",
                column: "parent_id",
                principalTable: "AspNetUsers",
                principalColumn: "parent_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Departments_Dept_Id",
                table: "Student",
                column: "Dept_Id",
                principalTable: "Departments",
                principalColumn: "dept_id");
        }
    }
}
