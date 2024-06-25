using CollegeSystem.DAL.Models;
using CollegeSystem.DAL.UnitOfWork;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class CourseStaffManager : ICourseStaffManager
{
    private readonly ICourseStaffRepo _courseStaffRepo;
    private readonly IUnitOfWork _unitOfWork;

    public CourseStaffManager(ICourseStaffRepo courseStaffRepo, IUnitOfWork unitOfWork)
    {
        _courseStaffRepo = courseStaffRepo;
        _unitOfWork = unitOfWork;
    }

    public void Add(CourseStaffAddDto courseStaffAddDto)
    {
        var courseStaff = new CourseStaff()
        {
            CourseId = courseStaffAddDto.CourseId,
            
        };
        _courseStaffRepo.Add(courseStaff);
        _unitOfWork.CompleteAsync();
    }

    public void Update(CourseStaffUpdateDto courseStaffUpdateDto)
    {
        var courseStaff = _courseStaffRepo.GetById(courseStaffUpdateDto.CourseStaffId);
        if (courseStaff == null) return;
        courseStaff.CourseId = courseStaffUpdateDto.CourseId;


        _courseStaffRepo.Update(courseStaff);
        _unitOfWork.CompleteAsync();
    }

    public void Delete(CourseStaffDeleteDto courseStaffDeleteDto)
    {
        var courseStaff = _courseStaffRepo.GetById(courseStaffDeleteDto.Id);
        if (courseStaff == null) return;
        _courseStaffRepo.Delete(courseStaff);
        _unitOfWork.CompleteAsync();
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
