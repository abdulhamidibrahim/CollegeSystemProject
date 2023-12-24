using CollegeSystem.DAL.Models;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class LectureManager:ILectureManager
{
    private readonly ILectureRepo _lectureRepo;

    public LectureManager(ILectureRepo lectureRepo)
    {
        _lectureRepo = lectureRepo;
    }
    
    public void Add(LectureAddDto lectureAddDto)
    {
        var lecture = new Lecture()
        {
            Title = lectureAddDto.Title,
            File = lectureAddDto.File,
            CourseId = lectureAddDto.CourseId,
        };
        _lectureRepo.Add(lecture);
    }

    public void Update(LectureUpdateDto lectureUpdateDto)
    {
        var lecture = _lectureRepo.GetById(lectureUpdateDto.LectureId);
        if (lecture == null) return;
        lecture.Title = lectureUpdateDto.Title;
        lecture.File = lectureUpdateDto.File;
        lecture.CourseId = lectureUpdateDto.CourseId;

        _lectureRepo.Update(lecture);
    }

    public void Delete(LectureDeleteDto lectureDeleteDto)
    {
        var lecture = _lectureRepo.GetById(lectureDeleteDto.Id);
        if (lecture == null) return;
        _lectureRepo.Delete(lecture);
    }

    public LectureReadDto? Get(long id)
    {
        var lecture = _lectureRepo.GetById(id);
        if (lecture == null) return null;
        return new LectureReadDto()
        {
            Title = lecture.Title,
            File = lecture.File,
            CourseId = lecture.CourseId,
        };
    }

    public List<LectureReadDto> GetAll()
    {
        var lectures = _lectureRepo.GetAll();
        return lectures.Select(lecture => new LectureReadDto()
        {
            Title = lecture.Title,
            File = lecture.File,
            CourseId = lecture.CourseId,
            
        }).ToList();
    }
}