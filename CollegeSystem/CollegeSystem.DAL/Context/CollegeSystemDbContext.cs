using System;
using System.Collections.Generic;
using CollegeSystem.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using File = CollegeSystem.DAL.Models.File;

namespace CollegeSystem.DAL.Context;

public partial class CollegeSystemDbContext : IdentityDbContext<ApplicationUser,IdentityRole<long>,long>
{
    
    public CollegeSystemDbContext(DbContextOptions<CollegeSystemDbContext> options)
        : base(options)
    {
        if(Database.GetService<IDatabaseCreator>() is RelationalDatabaseCreator dbCreater)
        {
            // Create Database 
            if(!dbCreater.CanConnect())
            {
                dbCreater.Create();
            }
        
            // Create Tables
            if (!dbCreater.HasTables())
            {
                dbCreater.CreateTables();
            }
        }
    }

    public virtual DbSet<ActiveAllQuiz>? ActiveAllQuizzes { get; set; }

    public virtual DbSet<ActiveQuiz>? ActiveQuizzes { get; set; }

    public virtual DbSet<AllQuestion>? AllQuestions { get; set; }

    public virtual DbSet<AllQuiz>? AllQuizzes { get; set; }

    public virtual DbSet<Answer>? Answers { get; set; }
    
    public virtual DbSet<Admin>? Admins { get; set; }

    public virtual DbSet<AnswerAllQuiz>? AnswerAllQuizzes { get; set; }

    public virtual DbSet<Assignment>? Assignments { get; set; }

    public virtual DbSet<AssignmentAnswer>? AssignmentAnswers { get; set; }
    
    public virtual DbSet<AssignmentFile>? AssignmentFile { get; set; }

    public virtual DbSet<Course>? Courses { get; set; }

    public virtual DbSet<CourseStaff>? CourseStaffs { get; set; }

    public virtual DbSet<CourseUser>? CourseUsers { get; set; }

    public virtual DbSet<Department>? Departments { get; set; }
    
    public virtual DbSet<File>? Files { get; set; }
    
    public virtual DbSet<Lecture>? Lectures { get; set; }
    public virtual DbSet<Meeting>? Meetings { get; set; }

    public virtual DbSet<PostUser>? PostUsers { get; set; }
    
    public virtual DbSet<Parent>? Parents { get; set; }

    public virtual DbSet<ParentCall>? ParentCalls { get; set; }

    public virtual DbSet<PermAttendance>? PermAttendances { get; set; }

    public virtual DbSet<Post>? Posts { get; set; }

    public virtual DbSet<Question>? Questions { get; set; }

    public virtual DbSet<Quiz>? Quizzes { get; set; }

    public virtual DbSet<Reply>? Replies { get; set; }

    public virtual DbSet<Section>? Sections { get; set; }

    public virtual DbSet<Staff>? Staff { get; set; }

    public virtual DbSet<TempAttendance>? TempAttendances { get; set; }
    
    public virtual DbSet<Student>? Students { get; set; }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     var builder = new ConfigurationBuilder();
    //     builder.SetBasePath(Directory.GetCurrentDirectory());
    //     builder.AddJsonFile("appsettings.json");
    //     IConfiguration Configuration = builder.Build();
    //
    //     optionsBuilder.UseSqlServer(
    //         Configuration.GetConnectionString("DefaultConnection"));
    //     base.OnConfiguring(optionsBuilder);
    // }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    
        modelBuilder.Entity<ActiveAllQuiz>(entity =>
        {
            entity.HasKey(e => e.ActiveAllQuizzesId);

            entity.ToTable("Active_All_Quizzes");

            entity.Property(e => e.ActiveAllQuizzesId).HasColumnName("active_all_quizzes_id");
            entity.Property(e => e.AllQuizzesId).HasColumnName("all_quizzes_id");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("start_date");

            entity.HasOne(d => d.AllQuizzes).WithMany(p => p.ActiveAllQuizzes)
                .HasForeignKey(d => d.AllQuizzesId)
                .HasConstraintName("FK_Active_All_Quizzes_All_Quizzes");
        });

        modelBuilder.Entity<ActiveQuiz>(entity =>
        {
            entity.HasKey(e => e.ActiveQuizzesId);

            entity.ToTable("Active_Quizzes");

            entity.Property(e => e.ActiveQuizzesId).HasColumnName("active_quizzes_id");
            entity.Property(e => e.QuizId).HasColumnName("quiz_id");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("start_date");

            entity.HasOne(d => d.Quiz).WithMany(p => p.ActiveQuizzes)
                .HasForeignKey(d => d.QuizId)
                .HasConstraintName("FK_Active_Quizzes_Quizzes");
        });

        modelBuilder.Entity<AllQuestion>(entity =>
        {
            entity.HasKey(e => e.AllQuestionsId);

            entity.ToTable("All_Questions");

            entity.Property(e => e.AllQuestionsId).HasColumnName("all_questions_id");
            entity.Property(e => e.AllQuizzesId).HasColumnName("all_quizzes_id");
            entity.Property(e => e.Answer).HasColumnName("answer");
            entity.Property(e => e.Choice1).HasColumnName("choice1");
            entity.Property(e => e.Choice2).HasColumnName("choice2");
            entity.Property(e => e.Choice3).HasColumnName("choice3");
            entity.Property(e => e.Choice4).HasColumnName("choice4");
            entity.Property(e => e.Choice5).HasColumnName("choice5");
            entity.Property(e => e.Question).HasColumnName("question");

            entity.HasOne(d => d.AllQuizzes).WithMany(p => p.AllQuestions)
                .HasForeignKey(d => d.AllQuizzesId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_All_Questions_All_Quizzes");
        });

        modelBuilder.Entity<AllQuiz>(entity =>
        {
            entity.HasKey(e => e.AllQuizzesId);

            entity.ToTable("All_Quizzes");

            entity.Property(e => e.AllQuizzesId).HasColumnName("all_quizzes_id");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.Instructor)
                .HasMaxLength(50)
                .HasColumnName("instructor");
            entity.Property(e => e.MaxDegree)
                .HasMaxLength(50)
                .HasColumnName("max_degree");
            entity.Property(e => e.MaxTime)
                .HasMaxLength(50)
                .HasColumnName("max_time");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.Course).WithMany(p => p.AllQuizzes)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_All_Quizzes_Courses");
        });

        modelBuilder.Entity<Answer>(entity =>
        {
            entity.Property(e => e.AnswerId).HasColumnName("answer_id");
            // entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.QuizId).HasColumnName("quiz_id");
            entity.Property(e => e.StudentMark)
                .HasMaxLength(50)
                .HasColumnName("student_mark");
           

            // entity.HasOne(d => d.Course).WithMany(p => p.Answers)
            //     .HasForeignKey(d => d.CourseId)
            //     .HasConstraintName("FK_Answers_Courses");

            entity.HasOne(d => d.Quiz).WithMany(p => p.Answers)
                .HasForeignKey(d => d.QuizId)
                .HasConstraintName("FK_Answers_Quizzes_1");
            
        });

        modelBuilder.Entity<AnswerAllQuiz>(entity =>
        {
            entity.HasKey(e => e.AnswerAllQuizzesId);

            entity.ToTable("Answer_All_Quizzes");

            entity.Property(e => e.AnswerAllQuizzesId).HasColumnName("answer_all_quizzes_id");
            entity.Property(e => e.AllQuizzesId).HasColumnName("all_quizzes_id");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.StudentMark)
                .HasMaxLength(50)
                .HasColumnName("student_mark");

            entity.HasOne(d => d.AllQuizzes).WithMany(p => p.AnswerAllQuizzes)
                .HasForeignKey(d => d.AllQuizzesId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Answer_All_Quizzes_All_Quizzes");

            entity.HasOne(d => d.Course).WithMany(p => p.AnswerAllQuizzes)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Answer_All_Quizzes_Courses_2");

               });

        modelBuilder.Entity<Assignment>(entity =>
        {
            entity.Property(e => e.AssignmentId).HasColumnName("assignment_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");
            //
            // entity.HasOne(d => d.Course).WithMany(p => p.Assignments)
            //     .HasForeignKey(d => d.CourseId)
            //     .HasConstraintName("FK_Assignments_Courses");
            //
           // entity.HasMany(d=>d.File).WithOne(p=>p.Assignment)
           //     .HasForeignKey(d=>d.AssignmentId)
           //     .HasConstraintName("FK_Assignments_Files");
        });

        modelBuilder.Entity<AssignmentAnswer>(entity =>
        {
            entity.ToTable("Assignment_Answers");

            entity.Property(e => e.AssignmentAnswerId).HasColumnName("assignment_answer_id");
            entity.Property(e => e.AssignmentId).HasColumnName("assignment_id");

            entity.HasOne(d => d.Assignment).WithMany(p => p.AssignmentAnswers)
                .HasForeignKey(d => d.AssignmentId)
                .HasConstraintName("FK_Assignment_Answers_Assignments");
            
            // entity.HasMany(d => d.File).WithOne(p => p.AssignmentAnswer)
            //     .HasForeignKey(d => d.AssignmentAnswerId)
            //     .HasConstraintName("FK_Assignment_Answers_Files");
            
            entity.HasOne(d => d.Student).WithMany(p => p.AssignmentAnswers)
                .HasForeignKey(d => d.AssignmentAnswerId)
                .HasConstraintName("FK_Assignment_Answers_Student");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("code");
            entity.Property(e => e.Hours)
                .HasMaxLength(50)
                .HasColumnName("hours");
            entity.Property(e => e.Level)
                .HasMaxLength(50)
                .HasColumnName("level");
            entity.Property(e => e.Link)
                .HasMaxLength(50)
                .HasColumnName("link");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Term)
                .HasMaxLength(50)
                .HasColumnName("term");
            
            entity.HasOne(d=>d.Img)
                .WithOne(p=>p.Course)
                .HasForeignKey<File>(d=>d.CourseId)
                .HasConstraintName("FK_Courses_Images");
            
        });

        modelBuilder.Entity<CourseStaff>(entity =>
        {
            entity.ToTable("Course_Staff");

            entity.Property(e => e.CourseStaffId).HasColumnName("course_staff_id");
            entity.Property(e => e.CourseId).HasColumnName("course_id");

            entity.HasOne(d => d.Course).WithMany(p => p.CourseStaffs)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_Course_Staff_Courses");

                 });

        modelBuilder.Entity<CourseUser>(entity =>
        {
            entity.ToTable("Course_Users");

            entity.Property(e => e.CourseUserId).HasColumnName("course_user_id");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.Degree)
                .HasMaxLength(50)
                .HasColumnName("degree");

            entity.HasOne(d => d.Course).WithMany(p => p.CourseUsers)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Course_Users_Courses_1");

                   });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DeptId);

            entity.Property(e => e.DeptId).HasColumnName("dept_id");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("code");
            entity.Property(e => e.HeadOfDepartment)
                .HasMaxLength(50)
                .HasColumnName("head_of_department");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Lecture>(entity =>
        {
            entity.HasKey(e => e.LectureId).HasName("PK_Lecture");

            entity.Property(e => e.LectureId).HasColumnName("lecture_id");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");

            entity.HasOne(d => d.Course).WithMany(p => p.Lectures)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_Lecture_Courses");
            //
            // entity.HasMany(d => d.File).WithOne(p => p.Lecture)
            //     .HasForeignKey(d => d.LectureId)
            //     .HasConstraintName("FK_Lecture_Files");
        });

    
      
        modelBuilder.Entity<PostUser>(entity =>
        {
            entity.Property(e => e.PostUserId).HasColumnName("post_user_id");
            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.StaffId).HasColumnName("staff_id");
            entity.Property(e => e.StudentId).HasColumnName("student_id");
            
            entity.HasOne(d => d.Post).WithMany(p => p.PostUsers)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("FK_Post_Users_Posts");
            entity.HasOne(d => d.Student).WithMany(p => p.PostUsers)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_Post_Users_Students");
            entity.HasOne(d => d.Post).WithMany(p => p.PostUsers)
                .HasForeignKey(d => d.StaffId)
                .HasConstraintName("FK_Post_Users_Staffs");
            
        });
        
        modelBuilder.Entity<Parent>(entity =>
        {
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<ParentCall>(entity =>
        {
            entity.HasKey(e => e.MessageId);

            entity.ToTable("Parent_calls");

            entity.Property(e => e.MessageId).HasColumnName("message_id");
            entity.Property(e => e.File).HasColumnName("file");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.ParentEmail)
                .HasMaxLength(50)
                .HasColumnName("parent_email");
        });

        modelBuilder.Entity<PermAttendance>(entity =>
        {
            entity.ToTable("perm_attendances");

            entity.Property(e => e.PermAttendanceId).HasColumnName("perm_attendance_id");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.LectureId).HasColumnName("lecture_id");
            entity.Property(e => e.SectionId).HasColumnName("section_id");

            entity.HasOne(d => d.Course).WithMany(p => p.PermAttendances)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_perm_attendances_Courses");

            entity.HasOne(d => d.Lecture).WithMany(p => p.PermAttendances)
                .HasForeignKey(d => d.LectureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_perm_attendances_Lectures_2");

            entity.HasOne(d => d.Section).WithMany(p => p.PermAttendances)
                .HasForeignKey(d => d.SectionId)
                .HasConstraintName("FK_perm_attendances_Sections_1");

        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.Img)
                .HasMaxLength(50)
                .HasColumnName("img");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");

        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Answer)
                .HasMaxLength(50)
                .HasColumnName("answer");
            entity.Property(e => e.Degree)
                .HasMaxLength(50)
                .HasColumnName("degree");
            entity.Property(e => e.Choice1)
                .HasMaxLength(50)
                .HasColumnName("choice1");
            entity.Property(e => e.Choice2)
                .HasMaxLength(50)
                .HasColumnName("choice2");
            entity.Property(e => e.Choice3)
                .HasMaxLength(50)
                .HasColumnName("choice3");
            entity.Property(e => e.Choice4)
                .HasMaxLength(50)
                .HasColumnName("choice4");
            entity.Property(e => e.Choice5)
                .HasMaxLength(50)
                .HasColumnName("choice5");
            entity.Property(e => e.Question1)
                .HasMaxLength(50)
                .HasColumnName("question");
            entity.Property(e => e.QuizId).HasColumnName("quiz_id");

            entity.HasOne(d => d.Quiz).WithMany(p => p.Questions)
                .HasForeignKey(d => d.QuizId)
                .HasConstraintName("FK_Questions_Quizzes");
        });

        modelBuilder.Entity<Quiz>(entity =>
        {
            entity.Property(e => e.QuizId).HasColumnName("quiz_id");
            // entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.Instructor)
                .HasMaxLength(50)
                .HasColumnName("instructor");
            entity.Property(e => e.MaxDegree)
                .HasMaxLength(50)
                .HasColumnName("max_degree");
            entity.Property(e => e.MaxTime)
                .HasMaxLength(50)
                .HasColumnName("max_time");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            // entity.HasOne(d => d.Course).WithMany(p => p.Quizzes)
            //     .HasForeignKey(d => d.CourseId)
            //     .OnDelete(DeleteBehavior.Cascade)
            //     .HasConstraintName("FK_Quizzes_Courses");
        });

        modelBuilder.Entity<Reply>(entity =>
        {
            entity.Property(e => e.ReplyId).HasColumnName("reply_id");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.PostId).HasColumnName("post_id");

            entity.HasOne(d => d.Post).WithMany(p => p.Replies)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("FK_Replies_Posts");

        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.HasKey(e => e.SectionId);

            entity.Property(e => e.SectionId)
                .HasColumnName("sections_id");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");

            entity.HasOne(d => d.Course).WithMany(p => p.Sections)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_Sections_Courses");
            
            // entity.HasMany(d => d.File).WithOne(p => p.Section)
            //     .HasForeignKey(d => d.SectionId)
            //     .HasConstraintName("FK_Sections_Files");
        });

       

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<TempAttendance>(entity =>
        {
            entity.ToTable("Temp_Attendances");

            entity.Property(e => e.TempAttendanceId).HasColumnName("temp_attendance_id");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.LectureId).HasColumnName("lecture_id");
            entity.Property(e => e.RandomCode)
                .HasMaxLength(50)
                .HasColumnName("random_code");
            entity.Property(e => e.SectionId).HasColumnName("section_id");
            entity.Property(e => e.X)
                .HasMaxLength(50)
                .HasColumnName("x");
            entity.Property(e => e.Y)
                .HasMaxLength(50)
                .HasColumnName("y");

            entity.HasOne(d => d.Course).WithMany(p => p.TempAttendances)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_Temp_Attendances_Courses");

            entity.HasOne(d => d.Lecture).WithMany(p => p.TempAttendances)
                .HasForeignKey(d => d.LectureId)
                .HasConstraintName("FK_Temp_Attendances_Lectures_1");

            entity.HasOne(d => d.Section).WithMany(p => p.TempAttendances)
                .HasForeignKey(d => d.SectionId)
                .HasConstraintName("FK_Temp_Attendances_Sections_2");
        });

        // modelBuilder.Entity<AssignmentFile>(entity =>
        // {
        //     entity.HasKey(e => new { e.AssignmentId, e.FileId });
        // });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.Property(e => e.DeptId).HasColumnName("Dept_Id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.ArabicName)
                .HasMaxLength(100)
                .HasColumnName("arabic_name");
            entity.Property(e => e.ParentEmail)
                .HasMaxLength(100)
                .HasColumnName("parent_email");
            entity.Property(e => e.ParentPhone)
                .HasMaxLength(50)
                .HasColumnName("parent_phone");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.Ssn)
                .HasMaxLength(50)
                .HasColumnName("ssn");
            entity.Property(e => e.UniversityEmail)
                .HasMaxLength(100)
                .HasColumnName("university_email");
        
        entity.HasOne(d => d.Dept).WithMany(p => p.Users)
            .HasForeignKey(d => d.DeptId)
            .HasConstraintName("FK_Users_Departments");
        
         });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
