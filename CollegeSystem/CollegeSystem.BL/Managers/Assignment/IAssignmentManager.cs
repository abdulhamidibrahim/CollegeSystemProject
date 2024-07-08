using Microsoft.AspNetCore.Http;

namespace CollegeSystem.DL;

public interface IAssignmentManager
{
    // public void UpdateAssignmentAsync(int courseId, IFormFile file, DateTime deadline);
    // public void DeleteAssignment(int courseId);
    // public AssignmentReadDto? GetAssignment(int courseId);
    // // public List<AssignmentReadDto>? GetAllCourseAssignments(long courseId);
    public List<AssignmentReadAllDto>? GetAllSectionAssignments(long courseId);
    public List<AssignmentReadAllDto>? GetAllLectureAssignments(long courseId);
    // public void AddSectionAssignmentFileAsync(IFormFile file, long assignmentId);
    // public void AddSectionAssignmentAsync(SectionAssignmentAddDto assignmentAddDto);
    // void AddLectureAssignmentFileAsync(IFormFile file, long assignmentId);
    // void AddLectureAssignmentAsync(LectureAssignmentAddDto assignmentAddDto);
    //
    Task<IEnumerable<AssignmentReadDto>?> GetAssignmentsByCourseAsync(long courseId);
    Task<AssignmentReadDto> GetAssignmentByIdAsync(long assignmentId);
    Task AddAssignmentAsync(AssignmentAddDto assignment);
    Task UpdateAssignmentAsync(AssignmentUpdateDto assignment);
    Task DeleteAssignmentAsync(long assignmentId);
    Task SubmitAssignmentAnswerAsync(IFormFile answer, long assignmentId, long studentId);
    // list files in the assignment 
    Task<IEnumerable<AssignmentFileReadDto>?> GetAssignmentFilesAsync(long assignmentId);
}