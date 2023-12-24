using CollegeSystem.DAL.Models;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class AssignmentAnswerManager : IAssignmentAnswerManager
{
    private readonly IAssignmentAnswerRepo _assignmentAnswerRepo;

    public AssignmentAnswerManager(IAssignmentAnswerRepo assignmentAnswerRepo)
    {
        _assignmentAnswerRepo = assignmentAnswerRepo;
    }

    public void Add(AssignmentAnswerAddDto assignmentAnswerAddDto)
    {
        var assignmentAnswer = new AssignmentAnswer()
        {
            
            AssignmentId = assignmentAnswerAddDto.AssignmentId,
            File = assignmentAnswerAddDto.File,
            

        };
        _assignmentAnswerRepo.Add(assignmentAnswer);
    }

    public void Update(AssignmentAnswerUpdateDto assignmentAnswerUpdateDto)
    {
        var assignmentAnswer = _assignmentAnswerRepo.GetById(assignmentAnswerUpdateDto.AssignmentAnswerId);
        if (assignmentAnswer == null) return;
        assignmentAnswer.AssignmentId = assignmentAnswerUpdateDto.AssignmentId;
        assignmentAnswer.File = assignmentAnswerUpdateDto.File;



        _assignmentAnswerRepo.Update(assignmentAnswer);
    }

    public void Delete(AssignmentAnswerDeleteDto assignmentAnswerDeleteDto)
    {
        var assignmentAnswer = _assignmentAnswerRepo.GetById(assignmentAnswerDeleteDto.Id);
        if (assignmentAnswer == null) return;
        _assignmentAnswerRepo.Delete(assignmentAnswer);
    }

    public AssignmentAnswerReadDto? Get(long id)
    {
        var assignmentAnswer = _assignmentAnswerRepo.GetById(id);
        if (assignmentAnswer == null) return null;
        return new AssignmentAnswerReadDto()
        {
            AssignmentId = assignmentAnswer.AssignmentId,
            File = assignmentAnswer.File,
            

        };
    }

    public List<AssignmentAnswerReadDto> GetAll()
    {
        var assignmentAnswer = _assignmentAnswerRepo.GetAll();
        return assignmentAnswer.Select(assignmentAnswer => new AssignmentAnswerReadDto()
        {
           
            File = assignmentAnswer.File,
            AssignmentId= assignmentAnswer.AssignmentId,

        }).ToList();
    }
}