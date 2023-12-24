using CollegeSystem.DAL.Models;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class SectionAssignmentManager:ISectionAssignmentManager
{
    private readonly ISectionAssignmentRepo _sectionAssignmentRepo;

    public SectionAssignmentManager(ISectionAssignmentRepo sectionAssignmentRepo)
    {
        _sectionAssignmentRepo = sectionAssignmentRepo;
    }
    
    public void Add(SectionAssignmentAddDto sectionAssignmentAddDto)
    {
        var sectionAssignment = new SectionAssignment()
        {
            Title = sectionAssignmentAddDto.Title,
            File = sectionAssignmentAddDto.File,
        };
        _sectionAssignmentRepo.Add(sectionAssignment);
    }

    public void Update(SectionAssignmentUpdateDto sectionAssignmentUpdateDto)
    {
        var sectionAssignment = _sectionAssignmentRepo.GetById(sectionAssignmentUpdateDto.SectionAssignmentId);
        if (sectionAssignment == null) return;
        
        sectionAssignment.Title = sectionAssignmentUpdateDto.Title;
        sectionAssignment.File = sectionAssignmentUpdateDto.File;
        
        _sectionAssignmentRepo.Update(sectionAssignment);
    }

    public void Delete(SectionAssignmentDeleteDto sectionAssignmentDeleteDto)
    {
        var sectionAssignment = _sectionAssignmentRepo.GetById(sectionAssignmentDeleteDto.Id);
        if (sectionAssignment == null) return;
        _sectionAssignmentRepo.Delete(sectionAssignment);
    }

    public SectionAssignmentReadDto? Get(long id)
    {
        var sectionAssignment = _sectionAssignmentRepo.GetById(id);
        if (sectionAssignment == null) return null;
        return new SectionAssignmentReadDto()
        {
            Title = sectionAssignment.Title,
            File = sectionAssignment.File,
        };
    }

    public List<SectionAssignmentReadDto> GetAll()
    {
        var sectionAssignments = _sectionAssignmentRepo.GetAll();
        return sectionAssignments.Select(sectionAssignment => new SectionAssignmentReadDto()
        {
            Title = sectionAssignment.Title,
            File = sectionAssignment.File,
            
        }).ToList();
    }
}