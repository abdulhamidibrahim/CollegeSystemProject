using CollegeSystem.DAL.Models;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class SectionAssignmentAnswerManager:ISectionAssignmentAnswerManager
{
    private readonly ISectionAssignmentAnswerRepo _sectionAssignmentRepo;

    public SectionAssignmentAnswerManager(ISectionAssignmentAnswerRepo sectionAssignmentRepo)
    {
        _sectionAssignmentRepo = sectionAssignmentRepo;
    }
    
    public void Add(SectionAssignmentAnswerAddDto sectionAssignmentAddDto)
    {
        var sectionAssignment = new SectionAssignmentAnswer()
        {
           
        };
        _sectionAssignmentRepo.Add(sectionAssignment);
    }

    public void Update(SectionAssignmentAnswerUpdateDto sectionAssignmentUpdateDto)
    {
        var sectionAssignment = _sectionAssignmentRepo.GetById(sectionAssignmentUpdateDto.SectionAssignmentAnswerId);
        if (sectionAssignment == null) return;
        
        sectionAssignment.SectionAssignmentAnswerId = sectionAssignmentUpdateDto.SectionAssignmentAnswerId;
        sectionAssignment.File = sectionAssignmentUpdateDto.File;
        sectionAssignment.SectionAssignmentId = sectionAssignmentUpdateDto.SectionAssignmentId;
        
        _sectionAssignmentRepo.Update(sectionAssignment);
    }

    public void Delete(SectionAssignmentAnswerDeleteDto sectionAssignmentDeleteDto)
    {
        var sectionAssignment = _sectionAssignmentRepo.GetById(sectionAssignmentDeleteDto.Id);
        if (sectionAssignment == null) return;
        _sectionAssignmentRepo.Delete(sectionAssignment);
    }

    public SectionAssignmentAnswerReadDto? Get(long id)
    {
        var sectionAssignment = _sectionAssignmentRepo.GetById(id);
        if (sectionAssignment == null) return null;
        return new SectionAssignmentAnswerReadDto()
        {
            File = sectionAssignment.File,
            SectionAssignmentId = sectionAssignment.SectionAssignmentId,
        };
    }

    public List<SectionAssignmentAnswerReadDto> GetAll()
    {
        var sectionAssignments = _sectionAssignmentRepo.GetAll();
        return sectionAssignments.Select(sectionAssignment => new SectionAssignmentAnswerReadDto()
        {
            File = sectionAssignment.File,
            SectionAssignmentId = sectionAssignment.SectionAssignmentId,
            
        }).ToList();
    }
}