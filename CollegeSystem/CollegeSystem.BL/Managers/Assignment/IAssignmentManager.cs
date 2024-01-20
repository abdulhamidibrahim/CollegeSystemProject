using Microsoft.AspNetCore.Http;

namespace CollegeSystem.DL;

public interface IAssignmentManager
{
    public void UpdateAssignmentAsync(int id, IFormFile file);
    public void DeleteAssignment(int id);
    public AssignmentReadDto? GetAssignment(int id);
    public List<AssignmentReadDto>? GetAllCourseAssignments(long courseId);
    public List<AssignmentReadDto>? GetAllSectionAssignments();
    public List<AssignmentReadDto>? GetAllLectureAssignments();
    public void AddSectionAssignmentAsync(IFormFile file,long id);
    void AddLectureAssignmentAsync(IFormFile file, long id);
    
}