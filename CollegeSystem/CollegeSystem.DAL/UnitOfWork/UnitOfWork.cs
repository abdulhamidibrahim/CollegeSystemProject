using CollegeSystem.DAL.Context;
using CollegeSystem.DAL.Models;
using FCISystem.DAL;
using File = CollegeSystem.DAL.Models.File;

namespace CollegeSystem.DAL.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly CollegeSystemDbContext _context;
    private AssignmentRepo _assignmentRepo;
    private AssignmentFileRepo _assignmentFileRepo;
    private AnswerRepo _answerRepo;
    private CourseRepo _courseRepo;
    private CourseStaffRepo _courseStaffRepo;
    private CourseUserRepo _courseUserRepo;
    private DepartmentRepo _departmentRepo;
    private FileRepo _fileRepo;
    private LectureRepo _lectureRepo;
    private SectionRepo _sectionRepo;
    private MeetingRepo _meetingRepo;
    private ParentRepo _parentRepo;
    private ParentCallRepo _parentCallRepo;
    private AttendanceRepo _attendanceRepo;
    private QuestionsRepo _questionsRepo;
    private QuizRepo _quizRepo;
    private StudentRepo _studentRepo;
    private PostRepo _postRepo;
    private PostUsersRepo _postUsersRepo;
    private ReplyRepo _replyRepo;
    private StaffRepo _staffRepo;
    private FeedbackRepo _feedbackRepo;
    private GroupRepo _groupRepo;
     
                
            
    public UnitOfWork(CollegeSystemDbContext context)
    {
            _context = context;
                                                                                                                                    
                
    }
    // public IActiveAllQuizRepo ActiveAllQuiz => _activeAllQuizRepo ??= new ActiveAllQuizRepo(_context);
    
    // public IActiveQuizRepo ActiveQuiz => _activeQuizRepo ??= new ActiveQuizRepo(_context);

    // public IAllQuestionRepo AllQuestion => _allQuestionRepo ??= new AllQuestionRepo(_context);
   
    
    // public IAllQuizRepo AllQuiz => _allQuizRepo ??= new AllQuizRepo(_context);
    
    public IAssignmentRepo Assignment => _assignmentRepo ??= new AssignmentRepo(_context);
    public IAssignmentFileRepo AssignmentFile => _assignmentFileRepo ??= new AssignmentFileRepo(_context);
    public IAnswerRepo Answer => _answerRepo ??= new AnswerRepo(_context);
    public IQuestionRepo Question => _questionsRepo ??= new QuestionsRepo(_context);

    public ICourseRepo Course => _courseRepo ??= new CourseRepo(_context);
    
    public ICourseStaffRepo CourseStaff => _courseStaffRepo ??= new CourseStaffRepo(_context);
    
    public ICourseUserRepo CourseUser => _courseUserRepo ??= new CourseUserRepo(_context);
    
    public IDepartmentRepo Department => _departmentRepo ??= new DepartmentRepo(_context);
    
    public IFileRepo File => _fileRepo ??= new FileRepo(_context);
    
    public ILectureRepo Lecture => _lectureRepo ??= new LectureRepo(_context);
    
    public IMeetingRepo Meeting => _meetingRepo ??= new MeetingRepo(_context);
    
    public IParentRepo Parent => _parentRepo ??= new ParentRepo(_context);
    public IParentCallRepo ParentCall => _parentCallRepo ??= new ParentCallRepo(_context);
    
    public IAttendanceRepo Attendance => _attendanceRepo ??= new AttendanceRepo(_context);
    
    public IPostRepo Post => _postRepo ??= new PostRepo(_context);
    
    public IQuizRepo Quiz => _quizRepo ??= new QuizRepo(_context);
    
    public ISectionRepo Section => _sectionRepo ??= new SectionRepo(_context);
        
        
    public IStudentRepo Student => _studentRepo ??= new StudentRepo(_context);

    public IReplyRepo Reply => _replyRepo ??= new ReplyRepo(_context);
        
    public IPostUsersRepo PostUser => _postUsersRepo ??= new PostUsersRepo(_context);
    public IStaffRepo Staff => _staffRepo ??= new StaffRepo(_context);
    public IFeedbackRepo Feedback => _feedbackRepo ??= new FeedbackRepo(_context);
    public IGroupRepo Group => _groupRepo ??= new GroupRepo(_context);
            

   
    public async Task<int> CompleteAsync()
    {
        return  await _context.SaveChangesAsync() ;
    }
    public void Dispose()
    {
        _context.Dispose();
    }

   
}