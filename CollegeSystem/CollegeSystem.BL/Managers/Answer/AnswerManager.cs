using CollegeSystem.DAL.Models;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class AnswerManager : IAnswerManager
{
    private readonly IAnswerRepo _answerRepo;

    public AnswerManager(IAnswerRepo answerRepo)
    {
        _answerRepo = answerRepo;
    }

    public void Add(AnswerAddDto answerAddDto)
    {
        var answer = new Answer()
        {
            StudentMark = answerAddDto.StudentMark,
            QuizId = answerAddDto.QuizId,
            CourseId = answerAddDto.CourseId,
        };
        _answerRepo.Add(answer);
    }

    public void Update(AnswerUpdateDto answerUpdateDto)
    {
        var answer = _answerRepo.GetById(answerUpdateDto.AnswerId);
        if (answer == null) return;
        answer.StudentMark = answerUpdateDto.StudentMark;
        answer.CourseId = answerUpdateDto.CourseId;
        answer.QuizId = answerUpdateDto.QuizId;

        _answerRepo.Update(answer);
    }

    public void Delete(AnswerDeleteDto answerDeleteDto)
    {
        var answer = _answerRepo.GetById(answerDeleteDto.Id);
        if (answer == null) return;
        _answerRepo.Delete(answer);
    }

    public AnswerReadDto? Get(long id)
    {
        var answer = _answerRepo.GetById(id);
        if (answer == null) return null;
        return new AnswerReadDto()
        {
            StudentMark = answer.StudentMark,
            CourseId = answer.CourseId,
            QuizId = answer.QuizId,
        };
    }

    public List<AnswerReadDto> GetAll()
    {
        var answers = _answerRepo.GetAll();
        return answers.Select(answer => new AnswerReadDto()
        {
            StudentMark = answer.StudentMark,
            CourseId = answer.CourseId,
            QuizId = answer.QuizId,
        }).ToList();
    }
}
 