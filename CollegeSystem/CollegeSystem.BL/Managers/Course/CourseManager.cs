using CollegeSystem.DAL.Models;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class CourseManager:ICourseManager
{
    private readonly ICourseRepo _courseRepo;

    public CourseManager(ICourseRepo courseRepo)
    {
        _courseRepo = courseRepo;
    }
    
    public void Add(CourseAddDto courseAddDto)
    {
        var course = new Course()
        {
            Name = courseAddDto.Name,
            Level = courseAddDto.Level,
            Term = courseAddDto.Term,   
            Hours = courseAddDto.Hours,
            Code = courseAddDto.Code,
            Link = courseAddDto.Link,
            Img = courseAddDto.Img,
        };
        _courseRepo.Add(course);
    }

    public void Update(CourseUpdateDto courseUpdateDto)
    {
        var course = _courseRepo.GetById(courseUpdateDto.CourseId);
        if (course == null) return;
        course.Name = courseUpdateDto.Name;
        course.Level = courseUpdateDto.Level;
        course.Term = courseUpdateDto.Term;
        course.Hours = courseUpdateDto.Hours;
        course.Code = courseUpdateDto.Code;
        course.Link = courseUpdateDto.Link;
        course.Img = courseUpdateDto.Img;
        
        _courseRepo.Update(course);
    }

    public void Delete(CourseDeleteDto courseDeleteDto)
    {
        var course = _courseRepo.GetById(courseDeleteDto.Id);
        if (course == null) return;
        _courseRepo.Delete(course);
    }

    public CourseReadDto? Get(long id)
    {
        var course = _courseRepo.GetById(id);
        if (course == null) return null;
        return new CourseReadDto()
        {
            Name = course.Name,
            Level = course.Level,
            Term = course.Term,
            Hours = course.Hours,
            Code = course.Code,
            Link = course.Link,
            Img = course.Img,
            
        };
    }

    public List<CourseReadDto> GetAll()
    {
        var courses = _courseRepo.GetAll();
        return courses.Select(course => new CourseReadDto()
        {
            Name = course.Name,
            Level = course.Level,
            Term = course.Term,
            Hours = course.Hours,
            Code = course.Code,
            Link = course.Link,
            Img = course.Img,
            
        }).ToList();
    }
}