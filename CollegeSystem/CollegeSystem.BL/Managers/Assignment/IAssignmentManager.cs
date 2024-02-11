using Microsoft.AspNetCore.Http;

namespace CollegeSystem.DL;

public interface IAssignmentManager
{
    public void UpdateAssignmentAsync(int id, IFormFile file, DateTime deadline);
    public void DeleteAssignment(int id);
    public AssignmentReadDto? GetAssignment(int id);
    public List<AssignmentReadDto>? GetAllCourseAssignments(long courseId);
    public List<AssignmentReadDto>? GetAllSectionAssignments();
    public List<AssignmentReadDto>? GetAllLectureAssignments();
    public void AddSectionAssignmentFileAsync(IFormFile file, long assignmentId);
    public void AddSectionAssignmentAsync(SectionAssignmentAddDto assignmentAddDto);
    void AddLectureAssignmentFileAsync(IFormFile file, long assignmentId);
    void AddLectureAssignmentAsync(LectureAssignmentAddDto assignmentAddDto);
    
}