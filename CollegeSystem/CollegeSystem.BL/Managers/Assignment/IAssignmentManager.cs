using Microsoft.AspNetCore.Http;

namespace CollegeSystem.DL;

public interface IAssignmentManager
{
    public void UpdateAssignmentAsync(int id, IFormFile file);
    public void DeleteAssignment(int id);
    public UploadAssignmentFileDto? GetAssignment(int id);
    public List<UploadAssignmentFileDto>? GetAllSectionAssignments();
    public List<UploadAssignmentFileDto>? GetAllLectureAssignments();
    public void AddSectionAssignmentAsync(IFormFile file,long id);
    void AddLectureAssignmentAsync(IFormFile file, long id);
    // public UserReadDto Login(UserLoginDto userLoginDto);
}