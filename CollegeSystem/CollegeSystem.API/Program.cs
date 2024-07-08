using System.Text;
using CollegeSystem.BL.Managers.File;
using CollegeSystem.BL.Utilities;
using CollegeSystem.BL.Utilities.ConnectionStrings;
using CollegeSystem.DAL.Configuration;
using CollegeSystem.DAL.Context;
using CollegeSystem.DAL.Models;
using CollegeSystem.DAL.UnitOfWork;
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
    options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});

//add connection string
builder.Services.AddDbContext<CollegeSystemDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(ServerConnection))));
        // option => option.CommandTimeout(300)));




builder.Services.AddIdentity<ApplicationUser, IdentityRole<long>>()
    .AddEntityFrameworkStores<CollegeSystemDbContext>()
    .AddDefaultTokenProviders();
    

builder.Services.AddIdentityCore<Admin>()
    .AddRoles<IdentityRole<long>>()
    .AddEntityFrameworkStores<CollegeSystemDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddIdentityCore<Student>()
    .AddRoles<IdentityRole<long>>()
    .AddEntityFrameworkStores<CollegeSystemDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddIdentityCore<Parent>()
    .AddRoles<IdentityRole<long>>()
    .AddEntityFrameworkStores<CollegeSystemDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddIdentityCore<Staff>()
    .AddRoles<IdentityRole<long>>()
    .AddEntityFrameworkStores<CollegeSystemDbContext>()
    .AddDefaultTokenProviders();



builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 8;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    
    
    options.Lockout.MaxFailedAccessAttempts = 5;
    
    // Default inactivity timeout is 5 minutes
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    
    // Add Config for Email required  
    // options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedEmail = true;
});

builder.Services.Configure<DataProtectionTokenProviderOptions>(options =>
{
    options.TokenLifespan = TimeSpan.FromHours(2);
});

// builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
// {
//     config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
//     config.AddEnvironmentVariables();
// });

// builder.Services.AddCors(options =>
// {
//     options.AddPolicy("AllowAll",
//         builder =>
//         {
//             builder.AllowAnyOrigin()
//                 .AllowAnyMethod()
//                 .AllowAnyHeader();
//         });
// });
//
//expose port 80 and 443
// builder.Services.AddCors(options =>
// {
//     options.AddPolicy("AllowAll",
//         builder =>
//         {
//             builder.AllowAnyOrigin()
//                 .AllowAnyMethod()
//                 .AllowAnyHeader();
//         });
// });
// builder.WebHost.ConfigureKestrel(serverOptions =>
// {
//     serverOptions.Limits.MaxRequestBodySize = 52428800; // 50MB
// });

    // builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
    //     .ConfigureWebHostDefaults(webBuilder =>
    //     {
    //         webBuilder.UseUrls("http://*:80");
    //         webBuilder.UseStartup<Startup>();
    //    


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<UserUtility>();

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
// builder.Services.AddScoped<IAllQuestionManager, AllQuestionManager>();
builder.Services.AddScoped<IReplyManager, ReplyManager>();
// builder.Services.AddScoped<IActiveAllQuizManager, ActiveAllQuizManager>();
// builder.Services.AddScoped<IActiveQuizManager, ActiveQuizManager>();
// builder.Services.AddScoped<IAllQuizManager, AllQuizManager>();
// builder.Services.AddScoped<IAnswerAllQuizManager, AnswerAllQuizManager>();
// builder.Services.AddScoped<IAnswerManager, AnswerManager>();
builder.Services.AddScoped<IAssignmentManager, AssignmentManager>();
builder.Services.AddScoped<IAttendanceManager, AttendanceManager>();
// builder.Services.AddScoped<IAssignmentAnswerManager, AssignmentAnswerManager>();
builder.Services.AddScoped<ICourseManager, CourseManager>();
builder.Services.AddScoped<ICourseManager, CourseManager>();
builder.Services.AddScoped<ICourseStaffManager, CourseStaffManager>();
// builder.Services.AddScoped<ICourseUserManager, CourseUserManager>();
builder.Services.AddScoped<IParentCallManager, ParentCallManager>();
// builder.Services.AddScoped<IPermAttendanceManager, PermAttendanceManager>();
builder.Services.AddScoped<IQuizManager, QuizManager>();
builder.Services.AddScoped<IQRCodeManager, QRCodeManager>();
builder.Services.AddScoped<IMeetingManager, MeetingManager>();
builder.Services.AddScoped<IFileManager, FileManager>();
builder.Services.AddScoped<IFileRepo, FileRepo>();
builder.Services.AddScoped<IGroupManager, GroupManager>();
// builder.Services.AddScoped<ITempAttendanceManager, TempAttendanceManager>();

// builder.Services.AddScoped<QRCodeGenerator>();
#endregion

//add Email Configuration from appsettings.json to EmailConfiguration class
var emailConfig = builder.Configuration
    .GetSection("EmailConfiguration")
    .Get<EmailConfiguration>();

builder.Services.AddSingleton(emailConfig);

builder.Services.AddSingleton<IEmailService, EmailService>();

builder.Services.AddCors(
        options =>
    {
        options.AddPolicy("CorsPolicy",
            b =>
            {
                b.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
    });

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

builder.Services.AddMigrate();

var app = builder.Build();

// app.UseDeveloperExceptionPage();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI();
    // (c =>
    // {
    //     c.SwaggerEndpoint("/swagger/v1/swagger.json", "CollegeSystem.API v1");
    //     c.RoutePrefix = string.Empty;
    // });
// }

// app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();
app.UseCors("CorsPolicy");
app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI
    (c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CollegeSystem.API v1");
        c.RoutePrefix = string.Empty;
    });

app.Run();