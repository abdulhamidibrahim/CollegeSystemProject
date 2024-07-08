
using CollegeSystem.DAL.Context;
using CollegeSystem.DAL.Models;
using File = CollegeSystem.DAL.Models.File;

namespace FCISystem.DAL;

public class AssignmentFileRepo :GenericRepo<AssignmentFile>,IAssignmentFileRepo
{
    private readonly CollegeSystemDbContext _context;

    public AssignmentFileRepo(CollegeSystemDbContext context) : base(context)
    {
        _context = context;
    }


    // public List<AssignmentFile>? GetAllCourseAssignments(long courseId)
    // {
    //     return _context.AssignmentFile?
    //         .Where(x => x.AssignmentId != null && x.Assignment!.GroupId == courseId)
    //         .ToList();
    // }
    //
    // public List<AssignmentFile>? GetAllSectionAssignments()
    // {
    //     return _context.AssignmentFile?
    //         .Where(x => x.AssignmentId != null && x.Assignment!.SectionId != null)
    //         .ToList();
    // }
    //
    // public List<AssignmentFile>? GetAllLectureAssignments()
    // {
    //     return _context.AssignmentFile?
    //         .Where(x => x.AssignmentId != null && x.Assignment!.LectureId != null)
    //         .ToList();
    // }

    // public void AddSectionAssignment(AssignmentFile file)
    // {
    //     _context.AssignmentFile?.Add(file);
    // }
    //
    // public void AddLectureAssignment(AssignmentFile file)
    // {
    //     _context.AssignmentFile?.Add(file);
    // }
}