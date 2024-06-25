using CollegeSystem.DAL.Models;
using CollegeSystem.DAL.UnitOfWork;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class PermAttendanceManager:IPermAttendanceManager
{
    private readonly IPermAttendanceRepo _permAttendanceRepo;
    private readonly IUnitOfWork _unitOfWork;

    public PermAttendanceManager(IPermAttendanceRepo permAttendanceRepo, IUnitOfWork unitOfWork)
    {
        _permAttendanceRepo = permAttendanceRepo;
        _unitOfWork = unitOfWork;
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
        _unitOfWork.CompleteAsync();
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
        _unitOfWork.CompleteAsync();
    }

    public void Delete(PermAttendanceDeleteDto permAttendanceDeleteDto)
    {
        var permAttendance = _permAttendanceRepo.GetById(permAttendanceDeleteDto.Id);
        if (permAttendance == null) return;
        _permAttendanceRepo.Delete(permAttendance);
        _unitOfWork.CompleteAsync();
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