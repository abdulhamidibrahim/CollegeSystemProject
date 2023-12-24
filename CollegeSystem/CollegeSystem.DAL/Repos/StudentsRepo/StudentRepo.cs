using CollegeSystem.DAL.Context;
using CollegeSystem.DAL.Models;

namespace FCISystem.DAL;

public class StudentRepo :GenericRepo<Student>,IStudentRepo
{
    private readonly CollegeSystemDbContext _context;

    public StudentRepo(CollegeSystemDbContext context) : base(context)
    {
        _context = context;
    }
    
}