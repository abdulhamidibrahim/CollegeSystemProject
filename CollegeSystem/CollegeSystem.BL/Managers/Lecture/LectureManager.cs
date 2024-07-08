using System.Net;
using CollegeSystem.DAL.Models;
using CollegeSystem.DAL.UnitOfWork;
using FCISystem.DAL;
using Microsoft.AspNetCore.Http;
using File = CollegeSystem.DAL.Models.File;

namespace CollegeSystem.DL;

public class LectureManager:ILectureManager
{
    private readonly IUnitOfWork _unitOfWork;

    public LectureManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public void Add(LectureAddDto lectureAddDto)
    {
        var lecture = new Lecture()
        {
            Title = lectureAddDto.Title,
            GroupId = lectureAddDto.GroupId,
        };
        _unitOfWork.Lecture.Add(lecture);
        _unitOfWork.CompleteAsync();
    }

    public void Update(LectureUpdateDto lectureUpdateDto)
    {
        var lecture = _unitOfWork.Lecture.GetById(lectureUpdateDto.LectureId);
        if (lecture == null) return;
        lecture.Title = lectureUpdateDto.Title;
        lecture.GroupId = lectureUpdateDto.GroupId;

        _unitOfWork.Lecture.Update(lecture);
        _unitOfWork.CompleteAsync();
    }

    public void Delete(long id)
    {
        var lecture = _unitOfWork.Lecture.GetById(id);
        if (lecture == null) return;
        _unitOfWork.Lecture.Delete(lecture);
        _unitOfWork.CompleteAsync();
    }

    public LectureReadDto? Get(long id)
    {
        var lecture = _unitOfWork.Lecture.GetById(id);
        if (lecture == null) return null;
        return new LectureReadDto()
        {
            Id = lecture.LectureId,
            Title = lecture.Title,
            UploadedBy = lecture.UploadedBy,
            // Files = lecture.Files,
        };
    }

    public List<LectureReadDto> GetAll(long courseId)
    {
        var lectures = _unitOfWork.Lecture.GetAllLectures(courseId);
        return lectures.Result.Select(lecture => new LectureReadDto()
        {
            Id = lecture.LectureId,
            Title = lecture.Title,
            UploadedBy = lecture.UploadedBy,
        }).ToList();
    }
    
    
     public void UpdateFileAsync(int id, IFormFile file)
    {
        var fileModel = _unitOfWork.File.GetById(id);
        var assignment = _unitOfWork.Lecture.GetById(id);
        if (fileModel == null || assignment==null)
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

    public void DeleteFile(int id)
    {
        var fileModel = _unitOfWork.File.GetById(id);
        var assignment = _unitOfWork.Lecture.GetById(id);
        if (fileModel == null || assignment==null)
            throw new InvalidDataException("File Not Found");
        _unitOfWork.File.Delete(fileModel);
        _unitOfWork.CompleteAsync();
    }

    public UploadLectureFileDto GetFile(int id)
    {
        var fileModel = _unitOfWork.File.GetById(id);
        var assignment = _unitOfWork.Lecture.GetById(id);
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
        var fileModel = _unitOfWork.File.GetAll().Where(x => x.LectureId != null);
        
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

        _unitOfWork.File.Add(fileModel);
        _unitOfWork.CompleteAsync();
    }
}