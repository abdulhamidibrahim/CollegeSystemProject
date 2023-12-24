using CollegeSystem.DAL.Models;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class LectureAssignmentAnswerManager : ILectureAssignmentAnswerManager
{
    private readonly ILectureAssignmentAnswerRepo _lectureAssignmentAnswerRepo;

    public LectureAssignmentAnswerManager(ILectureAssignmentAnswerRepo lectureAssignmentAnswerRepo)
    {
        _lectureAssignmentAnswerRepo = lectureAssignmentAnswerRepo;
    }

    public void Add(LectureAssignmentAnswerAddDto lectureAssignmentAnswerAddDto)
    {
        var lectureAssignmentAnswer = new LectureAssignmentAnswer()
        {
            File = lectureAssignmentAnswerAddDto.File,
           LectureAssignmentId = lectureAssignmentAnswerAddDto.LectureAssignmentId,
        };
        _lectureAssignmentAnswerRepo.Add(lectureAssignmentAnswer);
    }

    public void Update(LectureAssignmentAnswerUpdateDto lectureAssignmentAnswerUpdateDto)
    {
        var lectureAssignmentAnswer = _lectureAssignmentAnswerRepo.GetById(lectureAssignmentAnswerUpdateDto.LectureAssignmentAnswerId);
        if (lectureAssignmentAnswer == null) return;
        lectureAssignmentAnswer.File = lectureAssignmentAnswerUpdateDto.File;
        lectureAssignmentAnswer.LectureAssignmentId = lectureAssignmentAnswerUpdateDto.LectureAssignmentId;

        _lectureAssignmentAnswerRepo.Update(lectureAssignmentAnswer);
    }

    public void Delete(LectureAssignmentAnswerDeleteDto lectureAssignmentAnswerDeleteDto)
    {
        var lectureAssignmentAnswer = _lectureAssignmentAnswerRepo.GetById(lectureAssignmentAnswerDeleteDto.Id);
        if (lectureAssignmentAnswer == null) return;
        _lectureAssignmentAnswerRepo.Delete(lectureAssignmentAnswer);
    }

    public LectureAssignmentAnswerReadDto? Get(long id)
    {
        var lectureAssignmentAnswer = _lectureAssignmentAnswerRepo.GetById(id);
        if (lectureAssignmentAnswer == null) return null;
        return new LectureAssignmentAnswerReadDto()
        {
            File = lectureAssignmentAnswer.File,
            LectureAssignmentId = lectureAssignmentAnswer.LectureAssignmentId,
        };
    }

    public List<LectureAssignmentAnswerReadDto> GetAll()
    {
        var lecturesAssignmentAnswer = _lectureAssignmentAnswerRepo.GetAll();
        return lecturesAssignmentAnswer.Select(lectureAssignmentAnswer => new LectureAssignmentAnswerReadDto()
        {
            File = lectureAssignmentAnswer.File,
            LectureAssignmentId = lectureAssignmentAnswer.LectureAssignmentId,

        }).ToList();
    }
}