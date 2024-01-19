using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollegeSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class DeleteEmailVerfiedAtColumnInStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email_verified_at",
                table: "Student");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "email_verified_at",
                table: "Student",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
