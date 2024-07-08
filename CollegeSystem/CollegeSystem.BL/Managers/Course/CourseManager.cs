using CollegeSystem.BL.Enums;
using CollegeSystem.DAL.Models;
using CollegeSystem.DAL.UnitOfWork;
using FCISystem.DAL;
using Microsoft.AspNetCore.Http;
using File = CollegeSystem.DAL.Models.File;

namespace CollegeSystem.DL;

public class CourseManager:ICourseManager
{
    private readonly IUnitOfWork _unitOfWork;

    public CourseManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
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
            DeptId = courseAddDto.DeptId,
            Link = courseAddDto.Link,
        };
        _unitOfWork.Course.Add(course);
        _unitOfWork.CompleteAsync();
    }

    public Task<int> Update(CourseUpdateDto courseUpdateDto)
    {
        var course = _unitOfWork.Course.GetById(courseUpdateDto.CourseId);
        if (course == null) return Task.FromResult(0);
        
        course.Name = courseUpdateDto.Name;
        course.Level = courseUpdateDto.Level;
        course.Term = courseUpdateDto.Term;
        course.Hours = courseUpdateDto.Hours;
        course.Code = courseUpdateDto.Code;
        course.DeptId = courseUpdateDto.DeptId;
        course.Link = courseUpdateDto.Link;
        
        _unitOfWork.Course.Update(course);
        return _unitOfWork.CompleteAsync();
    }

    public void Delete(long id)
    {
        var course = _unitOfWork.Course.GetById(id);
        if (course == null) return;
        _unitOfWork.Course.Delete(course);
        _unitOfWork.CompleteAsync();
    }

    public CourseReadDto? Get(long id)
    {
        var course = _unitOfWork.Course.GetById(id);
        if (course == null) return null;
        return new CourseReadDto()
        {
            CourseId = course.CourseId,
            Name = course.Name,
            Level = course.Level,
            Term = course.Term,
            Hours = course.Hours,
            Code = course.Code,
            DeptId = course.DeptId,
            Link = course.Link,
        };
    }

    public List<CourseReadDto> GetAll()
    {
        var courses = _unitOfWork.Course.GetAll();
        return courses.Select(course => new CourseReadDto()
        {
            CourseId = course.CourseId,
            Name = course.Name,
            Level = course.Level,
            Term = course.Term,
            Hours = course.Hours,
            Code = course.Code,
            DeptId = course.DeptId,
            Link = course.Link,
        }).ToList();
    }
    
    
    public void UpdateImageAsync(int id, IFormFile file)
    {
        var fileModel = _unitOfWork.File.GetById(id);
        var course = _unitOfWork.Course.GetById(id);
        if (fileModel == null || course==null)
            throw new InvalidDataException("File Not Found");
        fileModel.Name = file.FileName;
        using (var ms = new MemoryStream()) 
        {
            file.CopyToAsync(ms);
            fileModel.Content = ms.ToArray();
        }
        
        _unitOfWork.File.Update(fileModel);
        _unitOfWork.CompleteAsync();
    }

    public void DeleteImage(long id)
    {
        var fileModel = _unitOfWork.File.GetById(id);
        if (fileModel == null)
            throw new InvalidDataException("File Not Found");
        _unitOfWork.File.Delete(fileModel);
        _unitOfWork.CompleteAsync();
    }

    public UploadCourseImageDto? GetImage(int id)
    {
        var fileModel = _unitOfWork.File.GetById(id);
        var course = _unitOfWork.Course.GetById(id);
        if (fileModel == null || course==null)
            return null;
        return new UploadCourseImageDto()
        {
            Name = fileModel.Name,
            Content = fileModel.Content,
            Extension = fileModel.Extension
        };
    }




    public void AddImageAsync(IFormFile file, long id)
    {
        var fileModel = new File()
        {
            Name = file.FileName,
            Extension = file.ContentType,
            CourseId = id
        };

        using (var ms = new MemoryStream())
        {
            file.CopyToAsync(ms);
            fileModel.Content = ms.ToArray();
        }

        _unitOfWork.File.Add(fileModel);
        _unitOfWork.CompleteAsync();
    }

    public List<CourseReadDto> GetCoursesByDeptId(int deptId)
    {
        var courses = _unitOfWork.Course.GetCoursesByDeptId(deptId);
        return courses.Select(course => new CourseReadDto()
        {
            CourseId = course.CourseId,
            Name = course.Name,
            Level = course.Level,
            Term = course.Term,
            Hours = course.Hours,
            Code = course.Code,
            DeptId = course.DeptId,
            Link = course.Link,
        }).ToList();
    }

    // public List<CourseReadDto> GetCoursesByLevelAndTerm(Level level, Term term)
    // {
    //     throw new NotImplementedException();
    // }

    public List<CourseReadDto> GetCoursesByLevelAndTerm(long studentId,Level level, Term term)
    {
        var courses = _unitOfWork.Course.GetCoursesByLevelAndTerm(studentId,level, term);
       List<CourseReadDto> coursesDto = new();
        foreach (var course in courses)
        {
            coursesDto.Add(new CourseReadDto()
            {
                CourseId = course.Course.CourseId,
                Name = course.Course.Name,
                Level = course.Course.Level,
                Term = course.Course.Term,
                Hours = course.Course.Hours,
                Code = course.Course.Code,
                DeptId = course.Course.DeptId,
                Link = course.Course.Link,
            });
        }
        return coursesDto;
    }

    public Task<int> RegisterCourses(long studentId, long[] courseId)
    {
        // check if student already register this course
        
        
        
        var student = _unitOfWork.Student.GetById(studentId);
        if (student == null)
            throw new InvalidDataException("Student Not Found");
        var courses = _unitOfWork.Course.GetCoursesByIds(courseId).ToList();
        if (courses.Count != courseId.Length)
            throw new InvalidDataException("Some Courses Not Found");
        foreach (var course in courses)
        {
            
            if (student.CourseUsers.Any(c => c.CourseId == course.CourseId))
                continue;
            
            var c = new CourseUser()
            {
                StudentId = studentId,
                CourseId = course.CourseId
            };
            student.CourseUsers.Add(c);
        }
        return _unitOfWork.CompleteAsync() ;
    }
}