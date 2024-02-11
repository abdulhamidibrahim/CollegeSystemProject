using System.Net;
using CollegeSystem.DAL.Models;
using FCISystem.DAL;
using Microsoft.AspNetCore.Http;
using File = CollegeSystem.DAL.Models.File;

namespace CollegeSystem.DL;

public class LectureManager:ILectureManager
{
    private readonly ILectureRepo _lectureRepo;
    private readonly IFileRepo _fileRepo;

    public LectureManager(ILectureRepo lectureRepo, IFileRepo fileRepo)
    {
        _lectureRepo = lectureRepo;
        _fileRepo = fileRepo;
    }
    
    public void Add(LectureAddDto lectureAddDto)
    {
        var lecture = new Lecture()
        {
            Title = lectureAddDto.Title,
            CourseId = lectureAddDto.CourseId,
        };
        _lectureRepo.Add(lecture);
    }

    public void Update(LectureUpdateDto lectureUpdateDto)
    {
        var lecture = _lectureRepo.GetById(lectureUpdateDto.LectureId);
        if (lecture == null) return;
        lecture.Title = lectureUpdateDto.Title;
        lecture.CourseId = lectureUpdateDto.CourseId;

        _lectureRepo.Update(lecture);
    }

    public void Delete(LectureDeleteDto lectureDeleteDto)
    {
        var lecture = _lectureRepo.GetById(lectureDeleteDto.Id);
        if (lecture == null) return;
        _lectureRepo.Delete(lecture);
    }

    public LectureReadDto? Get(long id)
    {
        var lecture = _lectureRepo.GetById(id);
        if (lecture == null) return null;
        return new LectureReadDto()
        {
            Title = lecture.Title,
            CourseId = lecture.CourseId,
        };
    }

    public List<LectureReadDto> GetAll()
    {
        var lectures = _lectureRepo.GetAll();
        return lectures.Select(lecture => new LectureReadDto()
        {
            Title = lecture.Title,
            CourseId = lecture.CourseId,
            
        }).ToList();
    }
    
    
     public void UpdateFileAsync(int id, IFormFile file)
    {
        var fileModel = _fileRepo.GetById(id);
        var assignment = _lectureRepo.GetById(id);
        if (fileModel == null || assignment==null)
            throw new InvalidDataException("File Not Found");
        fileModel.Name = file.FileName;
        using (var ms = new MemoryStream()) 
        {
            file.CopyToAsync(ms);
            fileModel.Content = ms.ToArray();
        }
        
        _fileRepo.Update(fileModel);
    }

    public void DeleteFile(int id)
    {
        var fileModel = _fileRepo.GetById(id);
        var assignment = _lectureRepo.GetById(id);
        if (fileModel == null || assignment==null)
            throw new InvalidDataException("File Not Found");
        _fileRepo.Delete(fileModel);
    }

    public UploadLectureFileDto GetFile(int id)
    {
        var fileModel = _fileRepo.GetById(id);
        var assignment = _lectureRepo.GetById(id);
        if (fileModel == null || assignment==null)
            throw new InvalidDataException("File Not Found");
        return new UploadLectureFileDto()
        {
            Name = fileModel.Name,
            Content = fileModel.Content,
            Extension = fileModel.Extension,
            CreatedAt = fileModel.CreatedAt,
        };
    }
    
    public List<UploadLectureFileDto> GetAllFiles()
    {
        var fileModel = _fileRepo.GetAll().Where(x => x.LectureId != null);
        
        return fileModel.Select(x => new UploadLectureFileDto()
        {
            Id = x.Id,
            Name = x.Name,
            // Content = x.Content,
            Extension = x.Extension,
            CreatedAt = x.CreatedAt,
        }).ToList();
    }

    public void AddFileAsync(IFormFile file, long id)
    {
        var fileModel = new File()
        {
            Name = file.FileName,
            Extension = file.ContentType,
            LectureId = id,
            CreatedAt = DateTime.Now
        };

        using (var ms = new MemoryStream())
        {
            file.CopyToAsync(ms);
            fileModel.Content = ms.ToArray();
        }

        _fileRepo.Add(fileModel);
    }
}