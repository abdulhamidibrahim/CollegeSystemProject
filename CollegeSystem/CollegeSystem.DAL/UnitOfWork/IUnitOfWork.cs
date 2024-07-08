using CollegeSystem.DAL.Models;
using FCISystem.DAL;
using File = CollegeSystem.DAL.Models.File;

namespace CollegeSystem.DAL.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    // Add methods to commit changes, save changes, etc.
    Task<int> CompleteAsync();
    IAnswerRepo Answer { get; }
    // IAdminrep Admin { get; }
    IQuizRepo Quiz { get; }
    IQuestionRepo Question { get; }
    IStudentRepo Student { get; }
    IAssignmentRepo Assignment { get; }
    IAssignmentFileRepo AssignmentFile { get; }
    ICourseRepo Course { get; }
    ICourseStaffRepo CourseStaff { get; }
    ICourseUserRepo CourseUser { get; }
    IDepartmentRepo Department { get; }
    IFileRepo File { get; }
    ILectureRepo Lecture { get; }
    IMeetingRepo Meeting { get; }
    IParentRepo Parent { get; }
    IParentCallRepo ParentCall { get; }
    IAttendanceRepo Attendance { get; }
    IPostRepo Post { get; }
    IPostUsersRepo PostUser { get; }
    IReplyRepo Reply { get; }
    ISectionRepo Section { get; }
    IStaffRepo Staff { get; }
    IFeedbackRepo Feedback { get; }
    IGroupRepo Group { get; }
}