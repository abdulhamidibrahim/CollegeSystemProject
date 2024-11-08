using CollegeSystem.DAL.Models;

namespace FCISystem.DAL;

public interface IMeetingRepo :IGenericRepo<Meeting>
{
    List<Meeting> GetMeetingsByGroupId(long groupId);
   
}