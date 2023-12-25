
using CollegeSystem.DAL.Context;
using CollegeSystem.DAL.Models;

namespace FCISystem.DAL;

public class LectureRepo :GenericRepo<Lecture>,ILectureRepo
{
    private readonly CollegeSystemDbContext _context;

    public LectureRepo(CollegeSystemDbContext context) : base(context)
    {
        _context = context;
    }
    
}