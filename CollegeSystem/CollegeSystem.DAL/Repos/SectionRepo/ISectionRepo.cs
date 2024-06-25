using CollegeSystem.DAL.Models;

namespace FCISystem.DAL;

public interface ISectionRepo :IGenericRepo<Section>
{
    // add section specific functions here
    Task<List<Section>> GetAllSections(long courseId);

}