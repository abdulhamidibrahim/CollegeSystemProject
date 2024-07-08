using CollegeSystem.DAL.Models;

namespace FCISystem.DAL;

public interface IPostRepo :IGenericRepo<Post>
{
    // add post specific functions here
    IEnumerable<Post>? GetCourseGroupPosts(long groupId);
}