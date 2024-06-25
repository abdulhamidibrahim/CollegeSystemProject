using CollegeSystem.DAL.Models;
using CollegeSystem.DAL.UnitOfWork;
using FCISystem.DAL;
using Microsoft.AspNetCore.Http;
using File = CollegeSystem.DAL.Models.File;

namespace CollegeSystem.DL;

public class SectionManager:ISectionManager
{
    private readonly ISectionRepo _sectionRepo;
    private readonly IFileRepo _fileRepo;
    private readonly IUnitOfWork _unitOfWork;

    public SectionManager(ISectionRepo sectionRepo, IFileRepo fileRepo, IUnitOfWork unitOfWork)
    {
        _sectionRepo = sectionRepo;
        _fileRepo = fileRepo;
        _unitOfWork = unitOfWork;
    }
    
    public void Add(SectionAddDto sectionAddDto)
    {
        var section = new Section()
        {
            Title = sectionAddDto.Title,
            CourseId = sectionAddDto.CourseId
        };
        _sectionRepo.Add(section);
        _unitOfWork.CompleteAsync();
    }

    public void Update(SectionUpdateDto sectionUpdateDto)
    {
        var section = _sectionRepo.GetById(sectionUpdateDto.SectionsId);
        if (section == null) return;
        
        section.Title = sectionUpdateDto.Title;
        section.CourseId = sectionUpdateDto.CourseId;
        
        _sectionRepo.Update(section);
        _unitOfWork.CompleteAsync();
    }

    public void Delete(SectionDeleteDto sectionDeleteDto)
    {
        var section = _sectionRepo.GetById(sectionDeleteDto.Id);
        if (section == null) return;
        _sectionRepo.Delete(section);
        _unitOfWork.CompleteAsync();
        _unitOfWork.CompleteAsync();
    }

    public SectionReadDto? Get(long id)
    {
        var section = _sectionRepo.GetById(id);
        if (section == null) return null;
        return new SectionReadDto()
        {
            Id = section.SectionId,
            Title = section.Title,
            CourseId = section.CourseId
        };
    }

    public List<SectionReadDto> GetAll(long courseId)
    {
        var sections = _sectionRepo.GetAllSections(courseId);
        return sections.Result.Select(section => new SectionReadDto()
        {
            Id = section.SectionId,
            Title = section.Title,
            UploadedBy = section.UploadedBy,
        }).ToList();
    }

    public void UpdateFileAsync(int id, IFormFile file)
    {
        var fileModel = _fileRepo.GetById(id);
        if (fileModel == null)
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
        var section = _sectionRepo.GetById(id);
        if (fileModel == null || section==null)
            throw new InvalidDataException("File Not Found");
        _fileRepo.Delete(fileModel);
        _unitOfWork.CompleteAsync();
    }

    public UploadSectionFileDto? GetFile(int id)
    {
        var fileModel = _fileRepo.GetById(id);
        if (fileModel == null)
            return null;
        return new UploadSectionFileDto()
        {
            Name = fileModel.Name,
            Content = fileModel.Content,
            Extension = fileModel.Extension
        };
    }

    public void AddFileAsync(IFormFile file, long id)
    {
        var fileModel = new File()
        {
            Name = file.FileName,
            Extension = file.ContentType,
            SectionId = id,
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
    public List<UploadSectionFileDto> GetAllFiles()
    {
        var fileModel = _fileRepo.GetAll().Where(x => x.SectionId != null);
        
        return fileModel.Select(x => new UploadSectionFileDto()
        {
            Id = x.Id,
            Name = x.Name,
            // Content = x.Content,
            Extension = x.Extension,
            CreatedAt = x.CreatedAt
        }).ToList();
    }
}