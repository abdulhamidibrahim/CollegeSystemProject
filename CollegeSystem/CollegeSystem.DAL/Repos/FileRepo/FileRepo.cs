
using CollegeSystem.DAL.Context;
using CollegeSystem.DAL.Models;
using File = CollegeSystem.DAL.Models.File;

namespace FCISystem.DAL;

public class FileRepo :GenericRepo<File>,IFileRepo
{
    private readonly CollegeSystemDbContext _context;

    public FileRepo(CollegeSystemDbContext context) : base(context)
    {
        _context = context;
    }
    
}