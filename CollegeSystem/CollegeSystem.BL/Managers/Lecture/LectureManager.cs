using System.Net;
using CollegeSystem.DAL.Models;
using CollegeSystem.DAL.UnitOfWork;
using FCISystem.DAL;
using Microsoft.AspNetCore.Http;
using File = CollegeSystem.DAL.Models.File;

namespace CollegeSystem.DL;

public class LectureManager:ILectureManager
{
    private readonly ILectureRepo _lectureRepo;
    private readonly IFileRepo _fileRepo;
    private readonly IUnitOfWork _unitOfWork;

    public LectureManager(ILectureRepo lectureRepo, IFileRepo fileRepo, IUnitOfWork unitOfWork)
    {
        _lectureRepo = lectureRepo;
        _fileRepo = fileRepo;
        _unitOfWork = unitOfWork;
    }
    
    public void Add(LectureAddDto lectureAddDto)
    {
        var lecture = new Lecture()
        {
            Title = lectureAddDto.Title,
            CourseId = lectureAddDto.CourseId,
        };
        _lectureRepo.Add(lecture);
        _unitOfWork.CompleteAsync();
    }

    public void Update(LectureUpdateDto lectureUpdateDto)
    {
        var lecture = _lectureRepo.GetById(lectureUpdateDto.LectureId);
        if (lecture == null) return;
        lecture.Title = lectureUpdateDto.Title;
        lecture.CourseId = lectureUpdateDto.CourseId;

        _lectureRepo.Update(lecture);
        _unitOfWork.CompleteAsync();
    }

    public void Delete(LectureDeleteDto lectureDeleteDto)
    {
        var lecture = _lectureRepo.GetById(lectureDeleteDto.Id);
        if (lecture == null) return;
        _lectureRepo.Delete(lecture);
        _unitOfWork.CompleteAsync();
    }

    public LectureReadDto? Get(long id)
    {
        var lecture = _lectureRepo.GetById(id);
        if (lecture == null) return null;
        return new LectureReadDto()
        {
            Id = lecture.LectureId,
            Title = lecture.Title,
            Files = lecture.Files,
        };
    }

    public List<LectureReadDto> GetAll(long courseId)
    {
        var lectures = _lectureRepo.GetAllLectures(courseId);
        return lectures.Result.Select(lecture => new LectureReadDto()
        {
            Id = lecture.LectureId,
            Title = lecture.Title,
            UploadedBy = lecture.UploadedBy,
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
        _unitOfWork.CompleteAsync();
    }

    public void DeleteFile(int id)
    {
        var fileModel = _fileRepo.GetById(id);
        var assignment = _lectureRepo.GetById(id);
        if (fileModel == null || assignment==null)
            throw new InvalidDataException("File Not Found");
        _fileRepo.Delete(fileModel);
        _unitOfWork.CompleteAsync();
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
        _unitOfWork.CompleteAsync();
    }
}