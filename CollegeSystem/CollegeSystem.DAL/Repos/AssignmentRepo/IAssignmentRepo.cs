using CollegeSystem.DAL.Models;

namespace FCISystem.DAL;

public interface IAssignmentRepo :IGenericRepo<Assignment>
{
    // add Assignment specific functions here
    Task<IEnumerable<Assignment>> GetAssignmentsByCourseAsync(long courseId);
    Task<Assignment> GetAssignmentByIdAsync(long assignmentId);
    Task AddAssignmentAsync(Assignment assignment);
    Task UpdateAssignmentAsync(Assignment assignment);
    Task DeleteAssignmentAsync(long assignmentId);
    Task SubmitAssignmentAnswerAsync(AssignmentAnswer answer);
    Task<List<AssignmentFile>> GetAssignmentFilesAsync(long assignmentId);
}