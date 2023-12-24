using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollegeSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    parent_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.parent_id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    course_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    level = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    term = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    hours = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    link = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    img = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.course_id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    dept_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    head_of_department = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.dept_id);
                });

            migrationBuilder.CreateTable(
                name: "Parent_calls",
                columns: table => new
                {
                    message_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    parent_email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parent_calls", x => x.message_id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "parent_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "parent_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "parent_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "parent_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parent",
                columns: table => new
                {
                    parent_id = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parent", x => x.parent_id);
                    table.ForeignKey(
                        name: "FK_Parent_AspNetUsers_parent_id",
                        column: x => x.parent_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "parent_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    parent_id = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.parent_id);
                    table.ForeignKey(
                        name: "FK_Staff_AspNetUsers_parent_id",
                        column: x => x.parent_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "parent_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "All_Quizzes",
                columns: table => new
                {
                    all_quizzes_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    instructor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    max_degree = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    max_time = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    course_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_All_Quizzes", x => x.all_quizzes_id);
                    table.ForeignKey(
                        name: "FK_All_Quizzes_Courses",
                        column: x => x.course_id,
                        principalTable: "Courses",
                        principalColumn: "course_id");
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    assignment_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    course_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.assignment_id);
                    table.ForeignKey(
                        name: "FK_Assignments_Courses",
                        column: x => x.course_id,
                        principalTable: "Courses",
                        principalColumn: "course_id");
                });

            migrationBuilder.CreateTable(
                name: "Lectures",
                columns: table => new
                {
                    lecture_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    file = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    course_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecture", x => x.lecture_id);
                    table.ForeignKey(
                        name: "FK_Lecture_Courses",
                        column: x => x.course_id,
                        principalTable: "Courses",
                        principalColumn: "course_id");
                });

            migrationBuilder.CreateTable(
                name: "Quizzes",
                columns: table => new
                {
                    quiz_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    instructor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    max_degree = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    max_time = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    course_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.quiz_id);
                    table.ForeignKey(
                        name: "FK_Quizzes_Courses",
                        column: x => x.course_id,
                        principalTable: "Courses",
                        principalColumn: "course_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    sections_id = table.Column<long>(type: "bigint", nullable: false),
                    title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    file = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    course_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.sections_id);
                    table.ForeignKey(
                        name: "FK_Sections_Courses",
                        column: x => x.course_id,
                        principalTable: "Courses",
                        principalColumn: "course_id");
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    parent_id = table.Column<long>(type: "bigint", nullable: false),
                    arabic_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    university_email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    email_verified_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ssn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    parent_phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    parent_email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Dept_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.parent_id);
                    table.ForeignKey(
                        name: "FK_Student_AspNetUsers_parent_id",
                        column: x => x.parent_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "parent_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_Departments_Dept_Id",
                        column: x => x.Dept_Id,
                        principalTable: "Departments",
                        principalColumn: "dept_id");
                });

            migrationBuilder.CreateTable(
                name: "Course_Staff",
                columns: table => new
                {
                    course_staff_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    course_id = table.Column<long>(type: "bigint", nullable: true),
                    StaffId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course_Staff", x => x.course_staff_id);
                    table.ForeignKey(
                        name: "FK_Course_Staff_Courses",
                        column: x => x.course_id,
                        principalTable: "Courses",
                        principalColumn: "course_id");
                    table.ForeignKey(
                        name: "FK_Course_Staff_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "parent_id");
                });

            migrationBuilder.CreateTable(
                name: "Active_All_Quizzes",
                columns: table => new
                {
                    active_all_quizzes_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    all_quizzes_id = table.Column<long>(type: "bigint", nullable: true),
                    start_date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Active_All_Quizzes", x => x.active_all_quizzes_id);
                    table.ForeignKey(
                        name: "FK_Active_All_Quizzes_All_Quizzes",
                        column: x => x.all_quizzes_id,
                        principalTable: "All_Quizzes",
                        principalColumn: "all_quizzes_id");
                });

            migrationBuilder.CreateTable(
                name: "All_Questions",
                columns: table => new
                {
                    all_questions_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    choice1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    choice2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    choice3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    choice4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    choice5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    all_quizzes_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_All_Questions", x => x.all_questions_id);
                    table.ForeignKey(
                        name: "FK_All_Questions_All_Quizzes",
                        column: x => x.all_quizzes_id,
                        principalTable: "All_Quizzes",
                        principalColumn: "all_quizzes_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assignment_Answers",
                columns: table => new
                {
                    assignment_answer_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    file = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    assignment_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignment_Answers", x => x.assignment_answer_id);
                    table.ForeignKey(
                        name: "FK_Assignment_Answers_Assignments",
                        column: x => x.assignment_id,
                        principalTable: "Assignments",
                        principalColumn: "assignment_id");
                });

            migrationBuilder.CreateTable(
                name: "Lecture_Assignments",
                columns: table => new
                {
                    lecture_assignment_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lecture_id = table.Column<long>(type: "bigint", nullable: true),
                    CourseId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecture_Assignments", x => x.lecture_assignment_id);
                    table.ForeignKey(
                        name: "FK_Lecture_Assignments_Courses_CourseId",
                        column: x => x.CourseId,
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
                name: "Active_Quizzes",
                columns: table => new
                {
                    active_quizzes_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quiz_id = table.Column<long>(type: "bigint", nullable: true),
                    start_date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Active_Quizzes", x => x.active_quizzes_id);
                    table.ForeignKey(
                        name: "FK_Active_Quizzes_Quizzes",
                        column: x => x.quiz_id,
                        principalTable: "Quizzes",
                        principalColumn: "quiz_id");
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    question = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    answer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    choice1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    choice2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    choice3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    choice4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    choice5 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    quiz_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.id);
                    table.ForeignKey(
                        name: "FK_Questions_Quizzes",
                        column: x => x.quiz_id,
                        principalTable: "Quizzes",
                        principalColumn: "quiz_id");
                });

            migrationBuilder.CreateTable(
                name: "Section_Assignments",
                columns: table => new
                {
                    section_assignment_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    section_id = table.Column<long>(type: "bigint", nullable: true),
                    CourseId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Section_Assignments", x => x.section_assignment_id);
                    table.ForeignKey(
                        name: "FK_Section_Assignments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "course_id");
                    table.ForeignKey(
                        name: "FK_Section_Assignments_Sections",
                        column: x => x.section_id,
                        principalTable: "Sections",
                        principalColumn: "sections_id");
                });

            migrationBuilder.CreateTable(
                name: "Temp_Attendances",
                columns: table => new
                {
                    temp_attendance_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    course_id = table.Column<long>(type: "bigint", nullable: true),
                    section_id = table.Column<long>(type: "bigint", nullable: true),
                    lecture_id = table.Column<long>(type: "bigint", nullable: true),
                    x = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    y = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    random_code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temp_Attendances", x => x.temp_attendance_id);
                    table.ForeignKey(
                        name: "FK_Temp_Attendances_Courses",
                        column: x => x.course_id,
                        principalTable: "Courses",
                        principalColumn: "course_id");
                    table.ForeignKey(
                        name: "FK_Temp_Attendances_Lectures_1",
                        column: x => x.lecture_id,
                        principalTable: "Lectures",
                        principalColumn: "lecture_id");
                    table.ForeignKey(
                        name: "FK_Temp_Attendances_Sections_2",
                        column: x => x.section_id,
                        principalTable: "Sections",
                        principalColumn: "sections_id");
                });

            migrationBuilder.CreateTable(
                name: "Answer_All_Quizzes",
                columns: table => new
                {
                    answer_all_quizzes_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    student_mark = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    all_quizzes_id = table.Column<long>(type: "bigint", nullable: true),
                    course_id = table.Column<long>(type: "bigint", nullable: true),
                    StudentId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer_All_Quizzes", x => x.answer_all_quizzes_id);
                    table.ForeignKey(
                        name: "FK_Answer_All_Quizzes_All_Quizzes",
                        column: x => x.all_quizzes_id,
                        principalTable: "All_Quizzes",
                        principalColumn: "all_quizzes_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Answer_All_Quizzes_Courses_2",
                        column: x => x.course_id,
                        principalTable: "Courses",
                        principalColumn: "course_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Answer_All_Quizzes_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "parent_id");
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    answer_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    student_mark = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    quiz_id = table.Column<long>(type: "bigint", nullable: true),
                    course_id = table.Column<long>(type: "bigint", nullable: true),
                    StudentId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.answer_id);
                    table.ForeignKey(
                        name: "FK_Answers_Courses",
                        column: x => x.course_id,
                        principalTable: "Courses",
                        principalColumn: "course_id");
                    table.ForeignKey(
                        name: "FK_Answers_Quizzes_1",
                        column: x => x.quiz_id,
                        principalTable: "Quizzes",
                        principalColumn: "quiz_id");
                    table.ForeignKey(
                        name: "FK_Answers_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "parent_id");
                });

            migrationBuilder.CreateTable(
                name: "Course_Users",
                columns: table => new
                {
                    course_user_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    degree = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    course_id = table.Column<long>(type: "bigint", nullable: true),
                    StudentId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course_Users", x => x.course_user_id);
                    table.ForeignKey(
                        name: "FK_Course_Users_Courses_1",
                        column: x => x.course_id,
                        principalTable: "Courses",
                        principalColumn: "course_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Course_Users_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "parent_id");
                });

            migrationBuilder.CreateTable(
                name: "perm_attendances",
                columns: table => new
                {
                    perm_attendance_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<int>(type: "int", nullable: true),
                    course_id = table.Column<long>(type: "bigint", nullable: true),
                    section_id = table.Column<long>(type: "bigint", nullable: true),
                    lecture_id = table.Column<long>(type: "bigint", nullable: false),
                    StudentId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_perm_attendances", x => x.perm_attendance_id);
                    table.ForeignKey(
                        name: "FK_perm_attendances_Courses",
                        column: x => x.course_id,
                        principalTable: "Courses",
                        principalColumn: "course_id");
                    table.ForeignKey(
                        name: "FK_perm_attendances_Lectures_2",
                        column: x => x.lecture_id,
                        principalTable: "Lectures",
                        principalColumn: "lecture_id");
                    table.ForeignKey(
                        name: "FK_perm_attendances_Sections_1",
                        column: x => x.section_id,
                        principalTable: "Sections",
                        principalColumn: "sections_id");
                    table.ForeignKey(
                        name: "FK_perm_attendances_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "parent_id");
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    post_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    img = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.post_id);
                    table.ForeignKey(
                        name: "FK_Posts_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "parent_id");
                });

            migrationBuilder.CreateTable(
                name: "Lecture_Assignment_Answers",
                columns: table => new
                {
                    lecture_assignment_answer_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    file = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lecture_assignment_id = table.Column<long>(type: "bigint", nullable: true),
                    StudentId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecture_Assignment_Answers", x => x.lecture_assignment_answer_id);
                    table.ForeignKey(
                        name: "FK_Lecture_Assignment_Answers_Lecture_Assignments_1",
                        column: x => x.lecture_assignment_id,
                        principalTable: "Lecture_Assignments",
                        principalColumn: "lecture_assignment_id");
                    table.ForeignKey(
                        name: "FK_Lecture_Assignment_Answers_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "parent_id");
                });

            migrationBuilder.CreateTable(
                name: "Section_Assignment_Answers",
                columns: table => new
                {
                    section_assignment_answer_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    file = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                        principalColumn: "section_assignment_id");
                    table.ForeignKey(
                        name: "FK_Section_Assignment_Answers_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "parent_id");
                });

            migrationBuilder.CreateTable(
                name: "PostUsers",
                columns: table => new
                {
                    post_user_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    post_id = table.Column<long>(type: "bigint", nullable: true),
                    student_id = table.Column<long>(type: "bigint", nullable: true),
                    staff_id = table.Column<long>(type: "bigint", nullable: true),
                    StaffId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostUsers", x => x.post_user_id);
                    table.ForeignKey(
                        name: "FK_PostUsers_Staff_StaffId1",
                        column: x => x.StaffId1,
                        principalTable: "Staff",
                        principalColumn: "parent_id");
                    table.ForeignKey(
                        name: "FK_Post_Users_Staffs",
                        column: x => x.staff_id,
                        principalTable: "Posts",
                        principalColumn: "post_id");
                    table.ForeignKey(
                        name: "FK_Post_Users_Students",
                        column: x => x.student_id,
                        principalTable: "Student",
                        principalColumn: "parent_id");
                });

            migrationBuilder.CreateTable(
                name: "Replies",
                columns: table => new
                {
                    reply_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    post_id = table.Column<long>(type: "bigint", nullable: true),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Replies", x => x.reply_id);
                    table.ForeignKey(
                        name: "FK_Replies_Posts",
                        column: x => x.post_id,
                        principalTable: "Posts",
                        principalColumn: "post_id");
                    table.ForeignKey(
                        name: "FK_Replies_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "parent_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Active_All_Quizzes_all_quizzes_id",
                table: "Active_All_Quizzes",
                column: "all_quizzes_id");

            migrationBuilder.CreateIndex(
                name: "IX_Active_Quizzes_quiz_id",
                table: "Active_Quizzes",
                column: "quiz_id");

            migrationBuilder.CreateIndex(
                name: "IX_All_Questions_all_quizzes_id",
                table: "All_Questions",
                column: "all_quizzes_id");

            migrationBuilder.CreateIndex(
                name: "IX_All_Quizzes_course_id",
                table: "All_Quizzes",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_All_Quizzes_all_quizzes_id",
                table: "Answer_All_Quizzes",
                column: "all_quizzes_id");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_All_Quizzes_course_id",
                table: "Answer_All_Quizzes",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_All_Quizzes_StudentId",
                table: "Answer_All_Quizzes",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_course_id",
                table: "Answers",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_quiz_id",
                table: "Answers",
                column: "quiz_id");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_StudentId",
                table: "Answers",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_Answers_assignment_id",
                table: "Assignment_Answers",
                column: "assignment_id");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_course_id",
                table: "Assignments",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_Course_Staff_course_id",
                table: "Course_Staff",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_Course_Staff_StaffId",
                table: "Course_Staff",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_Users_course_id",
                table: "Course_Users",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_Course_Users_StudentId",
                table: "Course_Users",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Lecture_Assignment_Answers_lecture_assignment_id",
                table: "Lecture_Assignment_Answers",
                column: "lecture_assignment_id");

            migrationBuilder.CreateIndex(
                name: "IX_Lecture_Assignment_Answers_StudentId",
                table: "Lecture_Assignment_Answers",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Lecture_Assignments_CourseId",
                table: "Lecture_Assignments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Lecture_Assignments_lecture_id",
                table: "Lecture_Assignments",
                column: "lecture_id");

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_course_id",
                table: "Lectures",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_perm_attendances_course_id",
                table: "perm_attendances",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_perm_attendances_lecture_id",
                table: "perm_attendances",
                column: "lecture_id");

            migrationBuilder.CreateIndex(
                name: "IX_perm_attendances_section_id",
                table: "perm_attendances",
                column: "section_id");

            migrationBuilder.CreateIndex(
                name: "IX_perm_attendances_StudentId",
                table: "perm_attendances",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_StudentId",
                table: "Posts",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_PostUsers_staff_id",
                table: "PostUsers",
                column: "staff_id");

            migrationBuilder.CreateIndex(
                name: "IX_PostUsers_StaffId1",
                table: "PostUsers",
                column: "StaffId1");

            migrationBuilder.CreateIndex(
                name: "IX_PostUsers_student_id",
                table: "PostUsers",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_quiz_id",
                table: "Questions",
                column: "quiz_id");

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_course_id",
                table: "Quizzes",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_post_id",
                table: "Replies",
                column: "post_id");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_StudentId",
                table: "Replies",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_Assignment_Answers_section_assignment_id",
                table: "Section_Assignment_Answers",
                column: "section_assignment_id");

            migrationBuilder.CreateIndex(
                name: "IX_Section_Assignment_Answers_StudentId",
                table: "Section_Assignment_Answers",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_Assignments_CourseId",
                table: "Section_Assignments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_Assignments_section_id",
                table: "Section_Assignments",
                column: "section_id");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_course_id",
                table: "Sections",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Dept_Id",
                table: "Student",
                column: "Dept_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Temp_Attendances_course_id",
                table: "Temp_Attendances",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_Temp_Attendances_lecture_id",
                table: "Temp_Attendances",
                column: "lecture_id");

            migrationBuilder.CreateIndex(
                name: "IX_Temp_Attendances_section_id",
                table: "Temp_Attendances",
                column: "section_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Active_All_Quizzes");

            migrationBuilder.DropTable(
                name: "Active_Quizzes");

            migrationBuilder.DropTable(
                name: "All_Questions");

            migrationBuilder.DropTable(
                name: "Answer_All_Quizzes");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Assignment_Answers");

            migrationBuilder.DropTable(
                name: "Course_Staff");

            migrationBuilder.DropTable(
                name: "Course_Users");

            migrationBuilder.DropTable(
                name: "Lecture_Assignment_Answers");

            migrationBuilder.DropTable(
                name: "Parent");

            migrationBuilder.DropTable(
                name: "Parent_calls");

            migrationBuilder.DropTable(
                name: "perm_attendances");

            migrationBuilder.DropTable(
                name: "PostUsers");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Replies");

            migrationBuilder.DropTable(
                name: "Section_Assignment_Answers");

            migrationBuilder.DropTable(
                name: "Temp_Attendances");

            migrationBuilder.DropTable(
                name: "All_Quizzes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Lecture_Assignments");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Quizzes");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Section_Assignments");

            migrationBuilder.DropTable(
                name: "Lectures");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
