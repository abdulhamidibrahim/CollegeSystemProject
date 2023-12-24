using CollegeSystem.DAL.Models;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class PermAttendanceManager:IPermAttendanceManager
{
    private readonly IPermAttendanceRepo _permAttendanceRepo;

    public PermAttendanceManager(IPermAttendanceRepo permAttendanceRepo)
    {
        _permAttendanceRepo = permAttendanceRepo;
    }
    
    public void Add(PermAttendanceAddDto permAttendanceAddDto)
    {
        var permAttendance = new PermAttendance()
        {
            CourseId = permAttendanceAddDto.CourseId,
            SectionId = permAttendanceAddDto.SectionId,
            LectureId = permAttendanceAddDto.LectureId,
            Code = permAttendanceAddDto.Code,
        };
        _permAttendanceRepo.Add(permAttendance);
    }

    public void Update(PermAttendanceUpdateDto permAttendanceUpdateDto)
    {
        var permAttendance = _permAttendanceRepo.GetById(permAttendanceUpdateDto.PermAttendanceId);
        if (permAttendance == null) return;
        permAttendance.PermAttendanceId = permAttendanceUpdateDto.PermAttendanceId;
        permAttendance.CourseId = permAttendanceUpdateDto.CourseId;
        permAttendance.LectureId = permAttendanceUpdateDto.LectureId;
        permAttendance.SectionId = permAttendanceUpdateDto.SectionId;
        permAttendance.Code = permAttendanceUpdateDto.Code;
        
        _permAttendanceRepo.Update(permAttendance);
    }

    public void Delete(PermAttendanceDeleteDto permAttendanceDeleteDto)
    {
        var permAttendance = _permAttendanceRepo.GetById(permAttendanceDeleteDto.Id);
        if (permAttendance == null) return;
        _permAttendanceRepo.Delete(permAttendance);
    }

    public PermAttendanceReadDto? Get(long id)
    {
        var permAttendance = _permAttendanceRepo.GetById(id);
        if (permAttendance == null) return null;
        return new PermAttendanceReadDto()
        {
            LectureId = permAttendance.LectureId,
            SectionId = permAttendance.SectionId,
            CourseId = permAttendance.CourseId,
            Code = permAttendance.Code,
            
        };
    }

    public List<PermAttendanceReadDto> GetAll()
    {
        var permAttendances = _permAttendanceRepo.GetAll();
        return permAttendances.Select(permAttendance => new PermAttendanceReadDto()
        {
            LectureId = permAttendance.LectureId,
            SectionId = permAttendance.SectionId,
            CourseId = permAttendance.CourseId,
            Code = permAttendance.Code,
            
        }).ToList();
    }
}