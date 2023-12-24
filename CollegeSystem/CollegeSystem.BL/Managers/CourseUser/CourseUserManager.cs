using CollegeSystem.DAL.Models;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class CourseUserManager : ICourseUserManager
{
    private readonly ICourseUserRepo _courseUserRepo;

    public CourseUserManager(ICourseUserRepo courseUserRepo)
    {
        _courseUserRepo = courseUserRepo;
    }

    public void Add(CourseUserAddDto courseUserAddDto)
    {
        var courseUser = new CourseUser()
        {
            Degree = courseUserAddDto.Degree,
            CourseId = courseUserAddDto.CourseId,
          
        };
        _courseUserRepo.Add(courseUser);
    }

    public void Update(CourseUserUpdateDto courseUserUpdateDto)
    {
        var courseUser = _courseUserRepo.GetById(courseUserUpdateDto.CourseUserId);
        if (courseUser == null) return;
        courseUser.Degree = courseUserUpdateDto.Degree;
        courseUser.CourseId = courseUserUpdateDto.CourseId;

        _courseUserRepo.Update(courseUser);
    }

    public void Delete(CourseUserDeleteDto courseUserDeleteDto)
    {
        var courseUser = _courseUserRepo.GetById(courseUserDeleteDto.Id);
        if (courseUser == null) return;
        _courseUserRepo.Delete(courseUser);
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
}