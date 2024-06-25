using CollegeSystem.DAL.Models;
using CollegeSystem.DAL.UnitOfWork;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class CourseUserManager : ICourseUserManager
{
    private readonly ICourseUserRepo _courseUserRepo;
    private readonly IUnitOfWork _unitOfWork;

    public CourseUserManager(ICourseUserRepo courseUserRepo, IUnitOfWork unitOfWork)
    {
        _courseUserRepo = courseUserRepo;
        _unitOfWork = unitOfWork;
    }

    public void Add(CourseUserAddDto courseUserAddDto)
    {
        var courseUser = new CourseUser()
        {
            // Degree = courseUserAddDto.Degree,
            CourseId = courseUserAddDto.CourseId,
            StudentId = courseUserAddDto.StudentId,
        };
        _courseUserRepo.Add(courseUser);
        _unitOfWork.CompleteAsync();
    }

    public void Update(CourseUserUpdateDto courseUserUpdateDto)
    {
        var courseUser = _courseUserRepo.GetById(courseUserUpdateDto.CourseUserId);
        if (courseUser == null) return;
        courseUser.Degree = courseUserUpdateDto.Degree;
        courseUser.CourseId = courseUserUpdateDto.CourseId;

        _courseUserRepo.Update(courseUser);
        _unitOfWork.CompleteAsync();
    }

    public void Delete(CourseUserDeleteDto courseUserDeleteDto)
    {
        var courseUser = _courseUserRepo.GetById(courseUserDeleteDto.Id);
        if (courseUser == null) return;
        _courseUserRepo.Delete(courseUser);
        _unitOfWork.CompleteAsync();
    }

    public CourseUserReadDto? Get(long id)
    {
        var courseUser = _courseUserRepo.GetById(id);
        if (courseUser == null) return null;
        return new CourseUserReadDto()
        {
            Degree = courseUser.Degree,
            CourseId = courseUser.CourseId,

        };
    }

    public List<CourseUserReadDto> GetAll()
    {
        var coursesUser = _courseUserRepo.GetAll();
        return coursesUser.Select(courseUser => new CourseUserReadDto()
        {
            Degree = courseUser.Degree,
            CourseId = courseUser.CourseId,
          

        }).ToList();
    }

    public void RegisterCoursesForStudent(long[] coursesId, long studentId)
    {
            foreach (var courseId in coursesId)
            {
                var courseUser = new CourseUser()
                {
                    CourseId = courseId,
                    StudentId = studentId,
                };
                _courseUserRepo.Add(courseUser);
            }
            _unitOfWork.CompleteAsync();
    }

    public void UnRegisterCoursesForStudent(long[] coursesId, long studentId)
    {
        foreach (var courseId in coursesId)
        {
            var courseUser = _courseUserRepo.GetByCourseIdAndStudentId(courseId, studentId);
            if (courseUser == null) continue;
            _courseUserRepo.Delete(courseUser);
        }
        _unitOfWork.CompleteAsync();
    }
}