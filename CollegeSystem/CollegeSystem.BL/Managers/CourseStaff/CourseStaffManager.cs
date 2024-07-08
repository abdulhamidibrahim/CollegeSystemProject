using CollegeSystem.DAL.Models;
using CollegeSystem.DAL.UnitOfWork;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class CourseStaffManager : ICourseStaffManager
{
    private readonly IUnitOfWork _unitOfWork;

    public CourseStaffManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Add(CourseStaffAddDto courseStaffAddDto)
    {
        var courseStaff = new CourseStaff()
        {
            CourseId = courseStaffAddDto.CourseId,
            
        };
        _unitOfWork.CourseStaff.Add(courseStaff);
        _unitOfWork.CompleteAsync();
    }

    public void Update(CourseStaffUpdateDto courseStaffUpdateDto)
    {
        var courseStaff = _unitOfWork.CourseStaff.GetById(courseStaffUpdateDto.CourseStaffId);
        if (courseStaff == null) return;
        courseStaff.CourseId = courseStaffUpdateDto.CourseId;


        _unitOfWork.CourseStaff.Update(courseStaff);
        _unitOfWork.CompleteAsync();
    }

    public void Delete(CourseStaffDeleteDto courseStaffDeleteDto)
    {
        var courseStaff = _unitOfWork.CourseStaff.GetById(courseStaffDeleteDto.Id);
        if (courseStaff == null) return;
        _unitOfWork.CourseStaff.Delete(courseStaff);
        _unitOfWork.CompleteAsync();
    }

    public CourseStaffReadDto? Get(long id)
    {
        var courseStaff = _unitOfWork.CourseStaff.GetById(id);
        if (courseStaff == null) return null;
        return new CourseStaffReadDto()
        {
            CourseId = courseStaff.CourseId,
           
        };
    }

    public List<CourseStaffReadDto> GetAll()
    {
        var coursesStaff = _unitOfWork.CourseStaff.GetAll();
        return coursesStaff.Select(courseStaff => new CourseStaffReadDto()
        {
            CourseId = courseStaff.CourseId,
         
        }).ToList();
    }
}
