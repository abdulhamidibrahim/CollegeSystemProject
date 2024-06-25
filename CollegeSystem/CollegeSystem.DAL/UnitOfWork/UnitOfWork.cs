using CollegeSystem.DAL.Context;
using CollegeSystem.DAL.Models;
using FCISystem.DAL;
using File = CollegeSystem.DAL.Models.File;

namespace CollegeSystem.DAL.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly CollegeSystemDbContext _context;

    public UnitOfWork(CollegeSystemDbContext context)
    {
            _context = context;
            ActiveAllQuiz = new GenericRepo<ActiveAllQuiz>(context);
            AllQuiz = new GenericRepo<AllQuiz>(context);
            Answer = new GenericRepo<Answer>(context);
            Admin = new GenericRepo<Admin>(context);
            Question = new GenericRepo<Question>(context);
            Quiz = new GenericRepo<Quiz>(context);
            ActiveQuiz = new GenericRepo<ActiveQuiz>(context);
            Student = new GenericRepo<Student>(context);
            AnswerAllQuiz = new GenericRepo<AnswerAllQuiz>(context);

            AllQuestion = new GenericRepo<AllQuestion>(context);

            Assignment = new GenericRepo<Assignment>(context);

            Course = new GenericRepo<Course>(context);

            CourseStaff = new GenericRepo<CourseStaff>(context);

            CourseUser = new GenericRepo<CourseUser>(context);

            Department = new GenericRepo<Department>(context);

            File = new GenericRepo<File>(context);

            Lecture = new GenericRepo<Lecture>(context);

            Meeting = new GenericRepo<Meeting>(context);

            Parent = new GenericRepo<Parent>(context);

            PermAttendance = new GenericRepo<PermAttendance>(context);

            Post = new GenericRepo<Post>(context);

            PostUser = new GenericRepo<PostUser>(context);  

            Reply = new GenericRepo<Reply>(context);

            Section = new GenericRepo<Section>(context);

            Staff = new GenericRepo<Staff>(context);

            ActiveAllQuiz = new GenericRepo<ActiveAllQuiz>(context);

            AllQuiz = new GenericRepo<AllQuiz>(context);
                                                                                                                                                                                                        
                
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public Task<int> CompleteAsync()
    {
        return _context.SaveChangesAsync();
    }

    public IGenericRepo<ActiveAllQuiz> ActiveAllQuiz { get; }
    public IGenericRepo<AllQuiz> AllQuiz { get; }
    public IGenericRepo<Answer> Answer { get; }
    public IGenericRepo<Admin> Admin { get; }
    public IGenericRepo<Question> Question { get; }
    public IGenericRepo<Quiz> Quiz { get; }
    public IGenericRepo<ActiveQuiz> ActiveQuiz { get; }
    public IGenericRepo<Student> Student { get; }
    public IGenericRepo<AnswerAllQuiz> AnswerAllQuiz { get; }
    public IGenericRepo<AllQuestion> AllQuestion { get; }
    public IGenericRepo<Assignment> Assignment { get; }
    public IGenericRepo<Course> Course { get; }
    public IGenericRepo<CourseStaff> CourseStaff { get; }
    public IGenericRepo<CourseUser> CourseUser { get; }
    public IGenericRepo<Department> Department { get; }
    public IGenericRepo<File> File { get; }
    public IGenericRepo<Lecture> Lecture { get; }
    public IGenericRepo<Meeting> Meeting { get; }
    public IGenericRepo<Parent> Parent { get; }
    public IGenericRepo<PermAttendance> PermAttendance { get; }
    public IGenericRepo<Post> Post { get; }
    public IGenericRepo<PostUser> PostUser { get; }
    public IGenericRepo<Reply> Reply { get; }
    public IGenericRepo<Section> Section { get; }
    public IGenericRepo<Staff> Staff { get; }
}