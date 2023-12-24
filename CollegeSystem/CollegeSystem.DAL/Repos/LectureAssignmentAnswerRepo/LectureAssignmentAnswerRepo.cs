
using CollegeSystem.DAL.Context;
using CollegeSystem.DAL.Models;

namespace FCISystem.DAL;

public class LectureAssignmentAnswerRepo :GenericRepo<LectureAssignmentAnswer>,ILectureAssignmentAnswerRepo
{
    private readonly CollegeSystemDbContext _context;

    public LectureAssignmentAnswerRepo(CollegeSystemDbContext context) : base(context)
    {
        _context = context;
    }
    
}