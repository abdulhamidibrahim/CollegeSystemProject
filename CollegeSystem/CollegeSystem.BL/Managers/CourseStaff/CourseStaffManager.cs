using CollegeSystem.DAL.Models;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class CourseStaffManager : ICourseStaffManager
{
    private readonly ICourseStaffRepo _courseStaffRepo;

    public CourseStaffManager(ICourseStaffRepo courseStaffRepo)
    {
        _courseStaffRepo = courseStaffRepo;
    }

    public void Add(CourseStaffAddDto courseStaffAddDto)
    {
        var courseStaff = new CourseStaff()
        {
            CourseId = courseStaffAddDto.CourseId,
            
        };
        _courseStaffRepo.Add(courseStaff);
    }

    public void Update(CourseStaffUpdateDto courseStaffUpdateDto)
    {
        var courseStaff = _courseStaffRepo.GetById(courseStaffUpdateDto.CourseStaffId);
        if (courseStaff == null) return;
        courseStaff.CourseId = courseStaffUpdateDto.CourseId;


        _courseStaffRepo.Update(courseStaff);
    }

    public void Delete(CourseStaffDeleteDto courseStaffDeleteDto)
    {
        var courseStaff = _courseStaffRepo.GetById(courseStaffDeleteDto.Id);
        if (courseStaff == null) return;
        _courseStaffRepo.Delete(courseStaff);
    }

    public CourseStaffReadDto? Get(long id)
    {
        var courseStaff = _courseStaffRepo.GetById(id);
        if (courseStaff == null) return null;
        return new CourseStaffReadDto()
        {
            CourseId = courseStaff.CourseId,
           
        };
    }

    public List<CourseStaffReadDto> GetAll()
    {
        var coursesStaff = _courseStaffRepo.GetAll();
        return coursesStaff.Select(courseStaff => new CourseStaffReadDto()
        {
            CourseId = courseStaff.CourseId,
         
        }).ToList();
    }
}
