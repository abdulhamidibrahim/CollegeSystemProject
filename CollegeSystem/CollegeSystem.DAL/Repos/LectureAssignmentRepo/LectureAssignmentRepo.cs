
using CollegeSystem.DAL.Context;
using CollegeSystem.DAL.Models;

namespace FCISystem.DAL;

public class LectureAssignmentRepo :GenericRepo<LectureAssignment>,ILectureAssignmentRepo
{
    private readonly CollegeSystemDbContext _context;

    public LectureAssignmentRepo(CollegeSystemDbContext context) : base(context)
    {
        _context = context;
    }
    
}