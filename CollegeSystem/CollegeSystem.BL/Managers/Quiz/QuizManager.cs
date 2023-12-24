using CollegeSystem.DAL.Models;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class QuizManager:IQuizManager
{
    private readonly IQuizRepo _quizRepo;

    public QuizManager(IQuizRepo quizRepo)
    {
        _quizRepo = quizRepo;
    }
    
    public void Add(QuizAddDto quizAddDto)
    {
        var quiz = new Quiz()
        {
            Name = quizAddDto.Name,
            Instructor = quizAddDto.Instructor,
            MaxDegree = quizAddDto.MaxDegree,
            MaxTime = quizAddDto.MaxTime,
            CourseId = quizAddDto.CourseId,
        };
        _quizRepo.Add(quiz);
    }

    public void Update(QuizUpdateDto quizUpdateDto)
    {
        var quiz = _quizRepo.GetById(quizUpdateDto.QuizId);
        if (quiz == null) return;
        quiz.Name = quizUpdateDto.Name;
        quiz.Instructor = quizUpdateDto.Instructor;
        quiz.MaxDegree = quizUpdateDto.MaxDegree;
        quiz.MaxTime = quizUpdateDto.MaxTime;
        quiz.CourseId = quizUpdateDto.CourseId;
        quiz.QuizId = quizUpdateDto.QuizId;        

        _quizRepo.Update(quiz);
    }

    public void Delete(QuizDeleteDto quizDeleteDto)
    {
        var quiz = _quizRepo.GetById(quizDeleteDto.Id);
        if (quiz == null) return;
        _quizRepo.Delete(quiz);
    }

    public QuizReadDto? Get(long id)
    {
        var quiz = _quizRepo.GetById(id);
        if (quiz == null) return null;
        return new QuizReadDto()
        {
            Name = quiz.Name,
            Instructor = quiz.Instructor,
            MaxDegree = quiz.MaxDegree,
            MaxTime = quiz.MaxTime,
            CourseId = quiz.CourseId,
        };
    }

    public List<QuizReadDto> GetAll()
    {
        var quizs = _quizRepo.GetAll();
        return quizs.Select(quiz => new QuizReadDto()
        {
            Name = quiz.Name,
            Instructor = quiz.Instructor,
            MaxDegree = quiz.MaxDegree,
            MaxTime = quiz.MaxTime,
            CourseId = quiz.CourseId,
        }).ToList();
    }
}