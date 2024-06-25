using System.Net;
using CollegeSystem.DAL.Models;
using CollegeSystem.DAL.UnitOfWork;
using FCISystem.DAL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using File = CollegeSystem.DAL.Models.File;

namespace CollegeSystem.DL;

public class StudentManager:IStudentManager
{
    private readonly IStudentRepo _studentRepo;
    private readonly IFileRepo _fileRepo;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IUnitOfWork _unitOfWork;

    public StudentManager(IStudentRepo studentRepo,IFileRepo fileRepo, IWebHostEnvironment webHostEnvironment, IUnitOfWork unitOfWork)
    {
        _studentRepo = studentRepo;
        _fileRepo = fileRepo;
        _webHostEnvironment = webHostEnvironment;
        _unitOfWork = unitOfWork;
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
             Term = studentAddDto.Term,
             Level = studentAddDto.Level,
             Gender = studentAddDto.Gender,
             ParentEmail = studentAddDto.ParentEmail,
             ParentPhone = studentAddDto.ParentPhone,
        };
        _studentRepo.Add(user);
        _unitOfWork.CompleteAsync();
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
        user.Level = studentUpdateDto.Level;
        user.Term = studentUpdateDto.Term;
        user.Gender = studentUpdateDto.Gender;
        _studentRepo.Update(user);
        _unitOfWork.CompleteAsync();
    }

    public void Delete(StudentDeleteDto studentDeleteDto)
    {
        var user = _studentRepo.GetById(studentDeleteDto.Id);
        if (user == null) return;
        _studentRepo.Delete(user);
        _unitOfWork.CompleteAsync();
    }

    public StudentReadDto? Get(long id)
    {
        var user = _studentRepo.GetById(id);
        if (user == null) return null;
        return new StudentReadDto()
        {
            Id = user.Id,
            Name = user.ArabicName,
            Email = user.Email,
            UniversityEmail = user.UniversityEmail,
            Phone = user.Phone,
            Ssn = user.Ssn,
            Term = user.Term,
            Level = user.Level,
            Gender = user.Gender,
            ParentEmail = user.ParentEmail,
            ParentPhone = user.ParentPhone,
        };
    }

    public List<StudentReadDto> GetAll()
    {
        var users = _studentRepo.GetAll();
        return users.Select(user => new StudentReadDto()
        {
            Id = user.Id,
            Name = user.ArabicName,
            Email = user.Email,
            UniversityEmail = user.UniversityEmail,
            Phone = user.Phone,
            Ssn = user.Ssn,
            Term = user.Term,
            Level = user.Level,
            Gender = user.Gender,
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
        _unitOfWork.CompleteAsync();
    }
    public void UploadImage(IFormFile file, long id)
    {

        var fileModel = new File()
        {
            Name = file.FileName,
            Extension = file.ContentType,
        };
        
        var path = Path.Combine(_webHostEnvironment.WebRootPath, "images", file.FileName);

        using FileStream fileStream = new(path, FileMode.Create);
        file.CopyTo(fileStream);
            

        _fileRepo.Add(fileModel);
        _unitOfWork.CompleteAsync();
    }

    // public IFormFile DownloadImage(int id)
    // {
    //     var uploadedFile = _fileRepo.GetById(id);
    //
    //     if (uploadedFile is null) return null;
    //
    //     var path = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", uploadedFile.Name);
    //
    //     MemoryStream memoryStream = new();
    //     using FileStream fileStream = new(path, FileMode.Open);
    //     fileStream.CopyTo(memoryStream);
    //
    //     memoryStream.Position = 0;
    //
    //     return (memoryStream, uploadedFile.Extension, uploadedFile.Name);
    //
    // }
}