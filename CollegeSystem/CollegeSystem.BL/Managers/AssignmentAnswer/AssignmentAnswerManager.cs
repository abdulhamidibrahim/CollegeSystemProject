using CollegeSystem.DAL.Models;
using FCISystem.DAL;
using Microsoft.AspNetCore.Http;
using File = CollegeSystem.DAL.Models.File;

namespace CollegeSystem.DL;

public class AssignmentAnswerManager : IAssignmentAnswerManager
{
    private readonly IAssignmentAnswerRepo _assignmentAnswerRepo;

    public AssignmentAnswerManager(IAssignmentAnswerRepo assignmentAnswerRepo)
    {
        _assignmentAnswerRepo = assignmentAnswerRepo;
    }
    
    
    public void UpdateFileAsync(long assignmentId,long studentId, IFormFile file)
    {
        var fileModel = _assignmentAnswerRepo
            .GetByAssignmentAndStudentId(assignmentId,studentId);
        if (fileModel == null)
            throw new InvalidDataException("File Not Found");
        fileModel.FileName = file.FileName;
        using (var ms = new MemoryStream()) 
        {
            file.CopyToAsync(ms);
            fileModel.FileContent = ms.ToArray();
        }
        
        _assignmentAnswerRepo.Update(fileModel);
    }

    public void DeleteFile(long assignmentId, long studentId)
    {
        var fileModel = _assignmentAnswerRepo
            .GetByAssignmentAndStudentId(assignmentId,studentId);
        
        if (fileModel == null)
            throw new InvalidDataException("File Not Found");
        _assignmentAnswerRepo.Delete(fileModel);
    }

    public UploadAssignmentFileDto? GetFile(long assignmentId, long studentId)
    {
        var fileModel = _assignmentAnswerRepo
            .GetByAssignmentAndStudentId(assignmentId, studentId);
        
        if (fileModel == null)
            return null;
        return new UploadAssignmentFileDto()
        {
            Name = fileModel.FileName,
            Content = fileModel.FileContent,
            Extension = fileModel.FileExtension
        };
    }

    public List<UploadAssignmentFileDto>? GetAllFiles()
    {
        var fileModels = _assignmentAnswerRepo.GetAll();
        
        return fileModels.Select(fileModel => new UploadAssignmentFileDto()
        {
            Name = fileModel.FileName,
            Content = fileModel.FileContent,
            Extension = fileModel.FileExtension
        }).ToList();    
    }

    public void AddFileAsync(IFormFile file, long studentId, long assignmentId)
    {
        var fileModel = new AssignmentAnswer()
        {
            FileName = file.FileName,
            FileExtension = file.ContentType,
            StudentId = studentId,
            AssignmentId = assignmentId
        };

        using (var ms = new MemoryStream())
        {
            file.CopyToAsync(ms);
            fileModel.FileContent = ms.ToArray();
        }

        _assignmentAnswerRepo.Add(fileModel);
    }
}