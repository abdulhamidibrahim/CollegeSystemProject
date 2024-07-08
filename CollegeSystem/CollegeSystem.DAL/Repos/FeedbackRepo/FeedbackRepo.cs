using CollegeSystem.DAL.Context;
using CollegeSystem.DAL.Models;

namespace FCISystem.DAL;

public class FeedbackRepo :GenericRepo<Feedback>,IFeedbackRepo
{
    private readonly CollegeSystemDbContext _context;

    public FeedbackRepo(CollegeSystemDbContext context) : base(context)
    {
        _context = context;
    }

}