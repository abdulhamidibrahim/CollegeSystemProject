using CollegeSystem.DAL.Context;

namespace FCISystem.DAL;

public class Testmonail :GenericRepo<Testmonail>,ITestmonailRepo
{
    private readonly CollegeSystemDbContext _context;

    public Testmonail(CollegeSystemDbContext context) : base(context)
    {
        _context = context;
    }
    
}