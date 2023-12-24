using CollegeSystem.DAL.Models;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class AssignmentManager : IAssignmentManager
{
    private readonly IAssignmentRepo _assignmentRepo;

    public AssignmentManager(IAssignmentRepo assignmentRepo)
    {
        _assignmentRepo = assignmentRepo;
    }

    public void Add(AssignmentAddDto assignmentAddDto)
    {
        var assignment = new Assignment()
        {
            Title = assignmentAddDto.Title,
            Description = assignmentAddDto.Description,
            File = assignmentAddDto.File,
            CourseId = assignmentAddDto.CourseId,
            
        };
        _assignmentRepo.Add(assignment);
    }

    public void Update(AssignmentUpdateDto assignmentUpdateDto)
    {
        var assignment = _assignmentRepo.GetById(assignmentUpdateDto.AssignmentId);
        if (assignment == null) return;
        assignment.Title = assignmentUpdateDto.Title;
        assignment.Description = assignmentUpdateDto.Description;
        assignment.File = assignmentUpdateDto.File;
        assignment.CourseId = assignmentUpdateDto.CourseId;


        _assignmentRepo.Update(assignment);
    }

    public void Delete(AssignmentDeleteDto assignmentDeleteDto)
    {
        var assignment = _assignmentRepo.GetById(assignmentDeleteDto.Id);
        if (assignment == null) return;
        _assignmentRepo.Delete(assignment);
    }

    public AssignmentReadDto? Get(long id)
    {
        var assignment = _assignmentRepo.GetById(id);
        if (assignment == null) return null;
        return new AssignmentReadDto()
        {
            Title = assignment.Title,
            Description = assignment.Description,
            File = assignment.File,
            CourseId = assignment.CourseId,

        };
    }

    public List<AssignmentReadDto> GetAll()
    {
        var assignment = _assignmentRepo.GetAll();
        return assignment.Select(assignment => new AssignmentReadDto()
        {
            Title = assignment.Title,
            Description = assignment.Description,
            File = assignment.File,
            CourseId = assignment.CourseId,

        }).ToList();
    }
}