
using CollegeSystem.DAL.Context;
using CollegeSystem.DAL.Models;

namespace FCISystem.DAL;

public class AssignmentAnswerRepo :GenericRepo<AssignmentAnswer>,IAssignmentAnswerRepo
{
    private readonly CollegeSystemDbContext _context;

    public AssignmentAnswerRepo(CollegeSystemDbContext context) : base(context)
    {
        _context = context;
    }
    
    public AssignmentAnswer? GetByAssignmentAndStudentId(long assignmentId, long studentId)
    {
        return _context.AssignmentAnswers?
            .FirstOrDefault
                (a => a.AssignmentId == assignmentId 
                      && a.StudentId==studentId);
    }
    
    public AssignmentAnswer? GetByAssignmentId(long assignmentId)
    {
        return _context.AssignmentAnswers?
            .FirstOrDefault
                (a => a.AssignmentId == assignmentId);
    }
    
    public List<AssignmentAnswer>? GetAllStudentAnswers(long studentId)
    {
        return _context.AssignmentAnswers?
            .Where(s=>s.StudentId == studentId)
            .ToList();
    }
}