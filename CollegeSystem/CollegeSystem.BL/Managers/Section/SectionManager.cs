using CollegeSystem.DAL.Models;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class SectionManager:ISectionManager
{
    private readonly ISectionRepo _sectionRepo;

    public SectionManager(ISectionRepo sectionRepo)
    {
        _sectionRepo = sectionRepo;
    }
    
    public void Add(SectionAddDto sectionAddDto)
    {
        var section = new Section()
        {
            Title = sectionAddDto.Title,
            File = sectionAddDto.File,
            CourseId = sectionAddDto.CourseId
        };
        _sectionRepo.Add(section);
    }

    public void Update(SectionUpdateDto sectionUpdateDto)
    {
        var section = _sectionRepo.GetById(sectionUpdateDto.SectionsId);
        if (section == null) return;
        
        section.Title = sectionUpdateDto.Title;
        section.File = sectionUpdateDto.File;
        section.CourseId = sectionUpdateDto.CourseId;
        
        _sectionRepo.Update(section);
    }

    public void Delete(SectionDeleteDto sectionDeleteDto)
    {
        var section = _sectionRepo.GetById(sectionDeleteDto.Id);
        if (section == null) return;
        _sectionRepo.Delete(section);
    }

    public SectionReadDto? Get(long id)
    {
        var section = _sectionRepo.GetById(id);
        if (section == null) return null;
        return new SectionReadDto()
        {
            Title = section.Title,
            File = section.File,
            CourseId = section.CourseId
        };
    }

    public List<SectionReadDto> GetAll()
    {
        var sections = _sectionRepo.GetAll();
        return sections.Select(section => new SectionReadDto()
        {
            Title = section.Title,
            File = section.File,
            CourseId = section.CourseId
            
        }).ToList();
    }
}