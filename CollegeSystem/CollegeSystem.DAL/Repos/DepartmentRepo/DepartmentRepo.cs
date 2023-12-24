
using CollegeSystem.DAL.Context;
using CollegeSystem.DAL.Models;

namespace FCISystem.DAL;

public class DepartmentRepo :GenericRepo<Department>,IDepartmentRepo
{
    private readonly CollegeSystemDbContext _context;

    public DepartmentRepo(CollegeSystemDbContext context) : base(context)
    {
        _context = context;
    }
    
}