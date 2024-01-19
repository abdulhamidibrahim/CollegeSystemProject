using CollegeSystem.DAL.Models;
using FCISystem.DAL;
using Microsoft.AspNetCore.Http;
using File = CollegeSystem.DAL.Models.File;

namespace CollegeSystem.DL;

public class SectionManager:ISectionManager
{
    private readonly ISectionRepo _sectionRepo;
    private readonly IFileRepo _fileRepo;

    public SectionManager(ISectionRepo sectionRepo, IFileRepo fileRepo)
    {
        _sectionRepo = sectionRepo;
        _fileRepo = fileRepo;
    }
    
    public void Add(SectionAddDto sectionAddDto)
    {
        var section = new Section()
        {
            Title = sectionAddDto.Title,
            CourseId = sectionAddDto.CourseId
        };
        _sectionRepo.Add(section);
    }

    public void Update(SectionUpdateDto sectionUpdateDto)
    {
        var section = _sectionRepo.GetById(sectionUpdateDto.SectionsId);
        if (section == null) return;
        
        section.Title = sectionUpdateDto.Title;
        section.CourseId = sectionUpdateDto.CourseId;
        
        _sectionRepo.Update(section);
    }

    public void Delete(SectionDeleteDto sectionDeleteDto)
    {
        var section = _sectionRepo.GetById(sectionDeleteDto.Id);
        if (section == null) return;
        _sectionRepo.Delete(section);
    }

    public SectionReadDto? Get(long id)
    {
        var section = _sectionRepo.GetById(id);
        if (section == null) return null;
        return new SectionReadDto()
        {
            Title = section.Title,
            CourseId = section.CourseId
        };
    }

    public List<SectionReadDto> GetAll()
    {
        var sections = _sectionRepo.GetAll();
        return sections.Select(section => new SectionReadDto()
        {
            Title = section.Title,
            CourseId = section.CourseId
            
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
    }

    public void DeleteFile(int id)
    {
        var fileModel = _fileRepo.GetById(id);
        var section = _sectionRepo.GetById(id);
        if (fileModel == null || section==null)
            throw new InvalidDataException("File Not Found");
        _fileRepo.Delete(fileModel);
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
            SectionId = id
        };

        using (var ms = new MemoryStream())
        {
            file.CopyToAsync(ms);
            fileModel.Content = ms.ToArray();
        }

        _fileRepo.Add(fileModel);
    }
}