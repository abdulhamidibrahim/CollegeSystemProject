using CollegeSystem.DAL.Models;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class LectureAssignmentManager : ILectureAssignmentManager
{
    private readonly ILectureAssignmentRepo _lectureAssignmentRepo;

    public LectureAssignmentManager(ILectureAssignmentRepo lectureAssignmentRepo)
    {
        _lectureAssignmentRepo = lectureAssignmentRepo;
    }

    public void Add(LectureAssignmentAddDto lectureAssignmentAddDto)
    {
        var lectureAssignment = new LectureAssignment()
        {
            Title = lectureAssignmentAddDto.Title,
            File = lectureAssignmentAddDto.File,
            LectureId = lectureAssignmentAddDto.LectureId,
            Description = lectureAssignmentAddDto.Description,
        };
        _lectureAssignmentRepo.Add(lectureAssignment);
    }

    public void Update(LectureAssignmentUpdateDto lectureAssignmentUpdateDto)
    {
        var lectureAssignment = _lectureAssignmentRepo.GetById(lectureAssignmentUpdateDto.LectureAssignmentId);
        if (lectureAssignment == null) return;
        lectureAssignment.Title = lectureAssignmentUpdateDto.Title;
        lectureAssignment.File = lectureAssignmentUpdateDto.File;
        lectureAssignment.LectureId = lectureAssignmentUpdateDto.LectureId;
        lectureAssignment.Description = lectureAssignmentUpdateDto.Description;

        _lectureAssignmentRepo.Update(lectureAssignment);
    }

    public void Delete(LectureAssignmentDeleteDto lectureAssignmentDeleteDto)
    {
        var lectureAssignment = _lectureAssignmentRepo.GetById(lectureAssignmentDeleteDto.Id);
        if (lectureAssignment == null) return;
        _lectureAssignmentRepo.Delete(lectureAssignment);
    }

    public LectureAssignmentReadDto? Get(long id)
    {
        var lectureAssignment = _lectureAssignmentRepo.GetById(id);
        if (lectureAssignment == null) return null;
        return new LectureAssignmentReadDto()
        {
            Title = lectureAssignment.Title,
            File = lectureAssignment.File,
            LectureId = lectureAssignment.LectureId,
            Description = lectureAssignment.Description,
        };
    }

    public List<LectureAssignmentReadDto> GetAll()
    {
        var lectureAssignment = _lectureAssignmentRepo.GetAll();
        return lectureAssignment.Select(lectureAssignment => new LectureAssignmentReadDto()
        {
            Title = lectureAssignment.Title,
            File = lectureAssignment.File,
            LectureId = lectureAssignment.LectureId,
            Description = lectureAssignment.Description,

        }).ToList();
    }
}