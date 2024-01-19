
using CollegeSystem.DAL.Models;

namespace FCISystem.DAL;

public interface IAssignmentAnswerRepo :IGenericRepo<AssignmentAnswer>
{
    // add assignment answer specific functions here
    AssignmentAnswer? GetByAssignmentAndStudentId(long assignmentId, long studentId);

}