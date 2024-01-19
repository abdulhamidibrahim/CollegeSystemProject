using CollegeSystem.DAL.Models;
using FCISystem.DAL;
using Microsoft.AspNetCore.Http;
using File = CollegeSystem.DAL.Models.File;

namespace CollegeSystem.DL;

public class StudentManager:IStudentManager
{
    private readonly IStudentRepo _studentRepo;
    private readonly IFileRepo _fileRepo;

    public StudentManager(IStudentRepo studentRepo,IFileRepo fileRepo)
    {
        _studentRepo = studentRepo;
        _fileRepo = fileRepo;
    }
    
    public void Add(StudentAddDto studentAddDto)
    {
        var user = new Student()
        {
             Id = studentAddDto.StudentCode,
             ArabicName = studentAddDto.Name,
             Email = studentAddDto.Email,
             UniversityEmail = studentAddDto.UniversityEmail,
             Phone = studentAddDto.Phone,
             Password = studentAddDto.Password,
             Ssn = studentAddDto.Ssn,
             ParentEmail = studentAddDto.ParentEmail,
             ParentPhone = studentAddDto.ParentPhone,
        };
        _studentRepo.Add(user);
    }

    public void Update(StudentUpdateDto studentUpdateDto)
    {
        var user = _studentRepo.GetById(studentUpdateDto.Id);
        if (user == null) return;
        user.ArabicName = studentUpdateDto.Name;
        user.Email = studentUpdateDto.Email;
        user.UniversityEmail = studentUpdateDto.UniversityEmail;
        user.Password = studentUpdateDto.Password;
        user.Ssn = studentUpdateDto.Ssn;
        user.Phone = studentUpdateDto.Phone;
        user.ParentEmail = studentUpdateDto.ParentEmail;
        user.ParentPhone = studentUpdateDto.ParentPhone;
        
        _studentRepo.Update(user);
    }

    public void Delete(StudentDeleteDto studentDeleteDto)
    {
        var user = _studentRepo.GetById(studentDeleteDto.Id);
        if (user == null) return;
        _studentRepo.Delete(user);
    }

    public StudentReadDto? Get(long id)
    {
        var user = _studentRepo.GetById(id);
        if (user == null) return null;
        return new StudentReadDto()
        {
            Name = user.ArabicName,
            Email = user.Email,
            UniversityEmail = user.UniversityEmail,
            Phone = user.Phone,
            Ssn = user.Ssn,
            ParentEmail = user.ParentEmail,
            ParentPhone = user.ParentPhone,
        };
    }

    public List<StudentReadDto> GetAll()
    {
        var users = _studentRepo.GetAll();
        return users.Select(user => new StudentReadDto()
        {
            Name = user.ArabicName,
            Email = user.Email,
            UniversityEmail = user.UniversityEmail,
            Phone = user.Phone,
            Ssn = user.Ssn,
            ParentEmail = user.ParentEmail,
            ParentPhone = user.ParentPhone,
        }).ToList();
    }

    public void UpdateImageAsync(int id, IFormFile file)
    {
        var fileModel = _fileRepo.GetById(id);
        var student = _studentRepo.GetById(id);
        if (fileModel == null || student==null)
            throw new InvalidDataException("File Not Found");
        fileModel.Name = file.FileName;
        using (var ms = new MemoryStream()) 
        {
            file.CopyToAsync(ms);
            fileModel.Content = ms.ToArray();
        }
        
        _fileRepo.Update(fileModel);
    }

    public void DeleteImage(int id)
    {
        var fileModel = _fileRepo.GetById(id);
        if (fileModel == null)
            throw new InvalidDataException("File Not Found");
        _fileRepo.Delete(fileModel);
    }

    public UploadStudentImageDto? GetImage(int id)
    {
        var fileModel = _fileRepo.GetById(id);
        var student = _studentRepo.GetById(id);
        if (fileModel == null || student==null)
            return null;
        return new UploadStudentImageDto()
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
            StudentId = id
        };

        using (var ms = new MemoryStream())
        {
            file.CopyToAsync(ms);
            fileModel.Content = ms.ToArray();
        }

        _fileRepo.Add(fileModel);
    }
}