using CollegeSystem.DAL.Models;
using CollegeSystem.DAL.UnitOfWork;
using FCISystem.DAL;
using Microsoft.AspNetCore.Http;
using File = CollegeSystem.DAL.Models.File;

namespace CollegeSystem.DL;

public class CourseManager:ICourseManager
{
    private readonly ICourseRepo _courseRepo;
    private readonly IFileRepo _fileRepo;
    private readonly IUnitOfWork _unitOfWork;

    public CourseManager(ICourseRepo courseRepo, IFileRepo fileRepo, IUnitOfWork unitOfWork)
    {
        _courseRepo = courseRepo;
        _fileRepo = fileRepo;
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
            Link = courseAddDto.Link,
        };
        _courseRepo.Add(course);
        _unitOfWork.CompleteAsync();
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
        
        _courseRepo.Update(course);
        _unitOfWork.CompleteAsync();
    }

    public void Delete(CourseDeleteDto courseDeleteDto)
    {
        var course = _courseRepo.GetById(courseDeleteDto.Id);
        if (course == null) return;
        _courseRepo.Delete(course);
        _unitOfWork.CompleteAsync();
    }

    public CourseReadDto? Get(long id)
    {
        var course = _courseRepo.GetById(id);
        if (course == null) return null;
        return new CourseReadDto()
        {
            Id = course.CourseId,
            Name = course.Name,
            Level = course.Level,
            Term = course.Term,
            Hours = course.Hours,
            Code = course.Code,
            Link = course.Link,
        };
    }

    public List<CourseReadDto> GetAll()
    {
        var courses = _courseRepo.GetAll();
        return courses.Select(course => new CourseReadDto()
        {
            Id = course.CourseId,
            Name = course.Name,
            Level = course.Level,
            Term = course.Term,
            Hours = course.Hours,
            Code = course.Code,
            Link = course.Link,
        }).ToList();
    }
    
    
    public void UpdateImageAsync(int id, IFormFile file)
    {
        var fileModel = _fileRepo.GetById(id);
        var course = _courseRepo.GetById(id);
        if (fileModel == null || course==null)
            throw new InvalidDataException("File Not Found");
        fileModel.Name = file.FileName;
        using (var ms = new MemoryStream()) 
        {
            file.CopyToAsync(ms);
            fileModel.Content = ms.ToArray();
        }
        
        _fileRepo.Update(fileModel);
        _unitOfWork.CompleteAsync();
    }

    public void DeleteImage(int id)
    {
        var fileModel = _fileRepo.GetById(id);
        if (fileModel == null)
            throw new InvalidDataException("File Not Found");
        _fileRepo.Delete(fileModel);
        _unitOfWork.CompleteAsync();
    }

    public UploadCourseImageDto? GetImage(int id)
    {
        var fileModel = _fileRepo.GetById(id);
        var course = _courseRepo.GetById(id);
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

        _fileRepo.Add(fileModel);
        _unitOfWork.CompleteAsync();
    }

    public List<CourseReadDto> GetCoursesByDeptId(int deptId)
    {
        var courses = _courseRepo.GetCoursesByDeptId(deptId);
        return courses.Select(course => new CourseReadDto()
        {
            Id = course.CourseId,
            Name = course.Name,
            Level = course.Level,
            Term = course.Term,
            Hours = course.Hours,
            Code = course.Code,
            Link = course.Link,
        }).ToList();
    }

    public List<CourseReadDto> GetCoursesByLevelAndTerm(string level, string term)
    {
        var courses = _courseRepo.GetCoursesByLevelAndTerm(level, term);
        return courses.Select(course => new CourseReadDto()
        {
            Name = course.Name,
            Level = course.Level,
            Term = course.Term,
            Hours = course.Hours,
            Code = course.Code,
            Link = course.Link,
        }).ToList();
    }
}