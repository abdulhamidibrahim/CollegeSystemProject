using CollegeSystem.DAL.Models;
using FCISystem.DAL;
using Microsoft.AspNetCore.Http;

namespace CollegeSystem.DL;

public class AssignmentManager : IAssignmentManager
{
    private readonly IAssignmentRepo _assignmentRepo;

    public AssignmentManager(IAssignmentRepo assignmentRepo)
    {
        _assignmentRepo = assignmentRepo;
    }
    
    public void UpdateAssignmentAsync(int id, IFormFile file)
    {
        var fileModel = _assignmentRepo.GetById(id);
        if (fileModel == null )
            throw new InvalidDataException("File Not Found");
        fileModel.FileName  = file.FileName;
        using (var ms = new MemoryStream()) 
        {
            file.CopyToAsync(ms);
            fileModel.FileContent = ms.ToArray();
        }
        
        _assignmentRepo.Update(fileModel);
    }

    public void DeleteAssignment(int id)
    {
        var fileModel = _assignmentRepo.GetById(id);
        if (fileModel == null)
            throw new InvalidDataException("File Not Found");
        _assignmentRepo.Delete(fileModel);
    }

    public UploadAssignmentFileDto GetAssignment(int id)
    {
        var fileModel = _assignmentRepo.GetById(id);
        if (fileModel == null)
            throw new InvalidDataException("File Not Found");
        return new UploadAssignmentFileDto()
        {
            Name = fileModel.FileName,
            Content = fileModel.FileContent,
            Extension = fileModel.FileExtension
        };
    }
    
    public List<UploadAssignmentFileDto>? GetAllSectionAssignments()
    {
        var fileModel = _assignmentRepo.GetAll().Where(x => x.AssignmentId != null);
        
        return fileModel.Where(s=>s.SectionId != null).Select(x => new UploadAssignmentFileDto()
        {
            Name = x.FileName ,
            Content = x.FileContent ,
            Extension = x.FileExtension 
        }).ToList();

        return null;
    }
    
    public List<UploadAssignmentFileDto>? GetAllLectureAssignments()
    {
        var fileModel = _assignmentRepo.GetAll().Where(x => x.AssignmentId != null);
        
        return fileModel.Where(s=>s.LectureId != null).Select(x => new UploadAssignmentFileDto()
        {
            Name = x.FileName ,
            Content = x.FileContent ,
            Extension = x.FileExtension 
        }).ToList();

        return null;
    }

    public void AddSectionAssignmentAsync(IFormFile file, long id)
    {
    var fileModel = new Assignment()
    {
        FileName = file.FileName,
        FileExtension = file.ContentType,
        SectionId = id
    };

    using (var ms = new MemoryStream())
    {
        file.CopyToAsync(ms);
        fileModel.FileContent = ms.ToArray();
    }
    
    _assignmentRepo.Add(fileModel);
    }
    
    public void AddLectureAssignmentAsync(IFormFile file, long id)
    {
    var fileModel = new Assignment()
    {
        FileName = file.FileName,
        FileExtension = file.ContentType,
        SectionId = id
    };

    using (var ms = new MemoryStream())
    {
        file.CopyToAsync(ms);
        fileModel.FileContent = ms.ToArray();
    }
    
    _assignmentRepo.Add(fileModel);
    }
}