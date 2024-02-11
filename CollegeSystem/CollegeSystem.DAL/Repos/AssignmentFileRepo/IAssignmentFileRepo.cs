using CollegeSystem.DAL.Models;
using File = CollegeSystem.DAL.Models.File;

namespace FCISystem.DAL;

public interface IAssignmentFileRepo :IGenericRepo<AssignmentFile>
{
    // add Department specific functions here
    // public List<AssignmentFile>? GetAllCourseAssignments(long courseId);
    // public List<AssignmentFile>? GetAllSectionAssignments();
    // public List<AssignmentFile>? GetAllLectureAssignments();
    // public void AddSectionAssignment(AssignmentFile file);
    // void AddLectureAssignment(AssignmentFile file);
}