using System.Text;
using CollegeSystem.DAL.Context;
using CollegeSystem.DAL.Models;
using CollegeSystem.DL;
using FCISystem.DAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using User.Management.Services.Models;
using User.Management.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});

//add connection string
builder.Services.AddDbContext<CollegeSystemDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CollegeSystemDbConnection")));



builder.Services.AddIdentity<ApplicationUser, IdentityRole<long>>()
    .AddEntityFrameworkStores<CollegeSystemDbContext>()
    .AddDefaultTokenProviders();
    


builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 8;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
});


#region Resolving Managers Services

builder.Services.AddScoped<IStudentManager, StudentManager>();
builder.Services.AddScoped<ICourseManager, CourseManager>();
builder.Services.AddScoped<IParentManager, ParentManager>();
builder.Services.AddScoped<IDepartmentManager, DepartmentManager>();
builder.Services.AddScoped<ILectureManager, LectureManager>();
builder.Services.AddScoped<IPostManager, PostManager>();
builder.Services.AddScoped<IPostUsersManager, PostUsersManager>();
builder.Services.AddScoped<ISectionManager, SectionManager>();
builder.Services.AddScoped<IStaffManager, StaffManager>();
builder.Services.AddScoped<IQuestionManager, QuestionManager>();
builder.Services.AddScoped<IAllQuestionManager, AllQuestionManager>();
builder.Services.AddScoped<IReplyManager, ReplyManager>();
builder.Services.AddScoped<IActiveAllQuizManager, ActiveAllQuizManager>();
builder.Services.AddScoped<IActiveQuizManager, ActiveQuizManager>();
builder.Services.AddScoped<IAllQuizManager, AllQuizManager>();
builder.Services.AddScoped<IAnswerAllQuizManager, AnswerAllQuizManager>();
builder.Services.AddScoped<IAnswerRepo, AnswerRepo>();
builder.Services.AddScoped<IAssignmentManager, AssignmentManager>();
builder.Services.AddScoped<IAssignmentAnswerManager, AssignmentAnswerManager>();
builder.Services.AddScoped<ICourseManager, CourseManager>();
builder.Services.AddScoped<ICourseManager, CourseManager>();
builder.Services.AddScoped<ICourseStaffManager, CourseStaffManager>();
builder.Services.AddScoped<ICourseUserManager, CourseUserManager>();
builder.Services.AddScoped<ILectureAssignmentManager, LectureAssignmentManager>();
builder.Services.AddScoped<ILectureAssignmentAnswerManager, LectureAssignmentAnswerManager>();
builder.Services.AddScoped<IParentCallManager, ParentCallManager>();
builder.Services.AddScoped<IPermAttendanceManager, PermAttendanceManager>();
builder.Services.AddScoped<IQuizManager, QuizManager>();
builder.Services.AddScoped<ISectionAssignmentAnswerManager, SectionAssignmentAnswerManager>();
builder.Services.AddScoped<ITempAttendanceManager, TempAttendanceManager>();


#endregion

#region Resolving Repo Services

builder.Services.AddScoped<IStudentRepo, StudentRepo>();
builder.Services.AddScoped<ICourseRepo, CourseRepo>();
builder.Services.AddScoped<IParentRepo, ParentRepo>();
builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();
builder.Services.AddScoped<ILectureRepo, LectureRepo>();
builder.Services.AddScoped<IPostRepo, PostRepo>();
builder.Services.AddScoped<IPostUsersRepo, PostUsersRepo>();
builder.Services.AddScoped<ISectionRepo, SectionRepo>();
builder.Services.AddScoped<IStaffRepo, StaffRepo>();
builder.Services.AddScoped<IQuestionRepo, QuestionsRepo>();
builder.Services.AddScoped<IAllQuestionRepo, AllQuestionsRepo>();
builder.Services.AddScoped<IActiveAllQuizRepo, ActiveAllQuizRepo>();
builder.Services.AddScoped<IActiveQuizRepo, ActiveQuizRepo>();
builder.Services.AddScoped<IAllQuizRepo, AllQuizRepo>();
builder.Services.AddScoped<IAnswerAllQuizRepo, AnswerAllQuizRepo>();
builder.Services.AddScoped<IAssignmentRepo,AssignmentRepo >();
builder.Services.AddScoped<IAnswerRepo, AnswerRepo>();
builder.Services.AddScoped<IAssignmentAnswerRepo, AssignmentAnswerRepo>();
builder.Services.AddScoped<IReplyRepo, ReplyRepo>();
builder.Services.AddScoped<ICourseStaffRepo, CourseStaffRepo>();
builder.Services.AddScoped<ICourseUserRepo, CourseUserRepo>();
builder.Services.AddScoped<ILectureAssignmentRepo, LectureAssignmentRepo>();
builder.Services.AddScoped<ILectureAssignmentAnswerRepo, LectureAssignmentAnswerRepo>();
builder.Services.AddScoped<IParentCallRepo, ParentCallRepo>();
builder.Services.AddScoped<IPermAttendanceRepo, PermAttendanceRepo>();
builder.Services.AddScoped<IQuizRepo, QuizRepo>();
builder.Services.AddScoped<ISectionAssignmentRepo, SectionAssignmentRepo>();
builder.Services.AddScoped<ISectionAssignmentAnswerRepo, SectionAssignmentAnswerRepo>();
builder.Services.AddScoped<ITempAttendanceRepo, TempAttendanceRepo>();


#endregion

//add Email Configuration from appsettings.json to EmailConfiguration class
var emailConfig = builder.Configuration
    .GetSection("EmailConfiguration")
    .Get<EmailConfiguration>();

builder.Services.AddSingleton(emailConfig);

builder.Services.AddSingleton<IEmailService, EmailService>();

// builder.Services.AddHostedService<SeedData>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; // if not valid redirect to login form 
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["JWT:issuer"],
        ValidAudience = builder.Configuration["JWT:audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:secret"]!))
    };
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();