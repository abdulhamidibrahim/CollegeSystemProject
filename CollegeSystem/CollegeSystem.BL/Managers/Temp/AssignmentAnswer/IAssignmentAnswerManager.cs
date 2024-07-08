using Microsoft.AspNetCore.Http;

namespace CollegeSystem.DL;

public interface IAssignmentAnswerManager
{
    
    public void UpdateFileAsync(long assignmentId,long studentId, IFormFile file);
    public void DeleteFile(long assignmentId, long studentId);
    public UploadAssignmentFileDto? GetFile(long assignmentId, long studentId);
    public List<UploadAssignmentFileDto>? GetAllFiles();
    public void AddFileAsync(IFormFile file, long assignmentId, long studentId);
    
}