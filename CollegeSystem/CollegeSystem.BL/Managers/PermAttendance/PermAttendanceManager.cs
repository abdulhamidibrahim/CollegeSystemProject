using CollegeSystem.DAL.Models;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class TempAttendanceManager:ITempAttendanceManager
{
    private readonly ITempAttendanceRepo _tempAttendanceRepo;

    public TempAttendanceManager(ITempAttendanceRepo tempAttendanceRepo)
    {
        _tempAttendanceRepo = tempAttendanceRepo;
    }
    
    public void Add(TempAttendanceAddDto tempAttendanceAddDto)
    {
        var tempAttendance = new TempAttendance()
        {
            CourseId = tempAttendanceAddDto.CourseId,
            SectionId = tempAttendanceAddDto.SectionId,
            LectureId = tempAttendanceAddDto.LectureId,
            X = tempAttendanceAddDto.X,
            Y = tempAttendanceAddDto.Y,
        };
        _tempAttendanceRepo.Add(tempAttendance);
    }

    public void Update(TempAttendanceUpdateDto tempAttendanceUpdateDto)
    {
        var tempAttendance = _tempAttendanceRepo.GetById(tempAttendanceUpdateDto.TempAttendanceId);
        if (tempAttendance == null) return;
        tempAttendance.TempAttendanceId = tempAttendanceUpdateDto.TempAttendanceId;
        tempAttendance.CourseId = tempAttendanceUpdateDto.CourseId;
        tempAttendance.LectureId = tempAttendanceUpdateDto.LectureId;
        tempAttendance.SectionId = tempAttendanceUpdateDto.SectionId;
        tempAttendance.X = tempAttendanceUpdateDto.Y;
        tempAttendance.X = tempAttendanceUpdateDto.Y;
        
        _tempAttendanceRepo.Update(tempAttendance);
    }

    public void Delete(TempAttendanceDeleteDto tempAttendanceDeleteDto)
    {
        var tempAttendance = _tempAttendanceRepo.GetById(tempAttendanceDeleteDto.Id);
        if (tempAttendance == null) return;
        _tempAttendanceRepo.Delete(tempAttendance);
    }

    public TempAttendanceReadDto? Get(long id)
    {
        var tempAttendance = _tempAttendanceRepo.GetById(id);
        if (tempAttendance == null) return null;
        return new TempAttendanceReadDto()
        {
            LectureId = tempAttendance.LectureId,
            SectionId = tempAttendance.SectionId,
            X = tempAttendance.X,
            CourseId = tempAttendance.CourseId,
            Y= tempAttendance.Y,
            
        };
    }

    public List<TempAttendanceReadDto> GetAll()
    {
        var tempAttendances = _tempAttendanceRepo.GetAll();
        return tempAttendances.Select(tempAttendance => new TempAttendanceReadDto()
        {
            LectureId = tempAttendance.LectureId,
            SectionId = tempAttendance.SectionId,
            X = tempAttendance.X,
            CourseId = tempAttendance.CourseId,
            Y = tempAttendance.Y,
            
        }).ToList();
    }
}