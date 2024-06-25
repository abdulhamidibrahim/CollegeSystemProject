using CollegeSystem.DAL.Models;
using FCISystem.DAL;
using File = CollegeSystem.DAL.Models.File;

namespace CollegeSystem.DAL.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    // Add methods to commit changes, save changes, etc.
    Task<int> CompleteAsync();
    IGenericRepo<ActiveAllQuiz> ActiveAllQuiz { get; } 
    IGenericRepo<AllQuiz> AllQuiz { get; }
    IGenericRepo<Answer> Answer { get; }
    IGenericRepo<Admin> Admin { get; }
    IGenericRepo<Question> Question { get; }
    IGenericRepo<Quiz> Quiz { get; }
    IGenericRepo<ActiveQuiz> ActiveQuiz { get; }
    IGenericRepo<Student> Student { get; }
    IGenericRepo<AnswerAllQuiz> AnswerAllQuiz { get; }
    IGenericRepo<AllQuestion> AllQuestion { get; }
    IGenericRepo<Assignment> Assignment { get; }
    IGenericRepo<Course> Course { get; }
    IGenericRepo<CourseStaff> CourseStaff { get; }
    IGenericRepo<CourseUser> CourseUser { get; }
    IGenericRepo<Department> Department { get; }
    IGenericRepo<File> File { get; }
    IGenericRepo<Lecture> Lecture { get; }
    IGenericRepo<Meeting> Meeting { get; }
    IGenericRepo<Parent> Parent { get; }
    IGenericRepo<PermAttendance> PermAttendance { get; }
    IGenericRepo<Post> Post { get; }
    IGenericRepo<PostUser> PostUser { get; }
    IGenericRepo<Reply> Reply { get; }
    IGenericRepo<Section> Section { get; }
    IGenericRepo<Staff> Staff { get; }
}