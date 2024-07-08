using CollegeSystem.DAL.Models;

namespace FCISystem.DAL;

public interface IGroupRepo :IGenericRepo<Group>
{
    // add post specific functions here
    IEnumerable<Group> GetAllGroups(long courseId);
}