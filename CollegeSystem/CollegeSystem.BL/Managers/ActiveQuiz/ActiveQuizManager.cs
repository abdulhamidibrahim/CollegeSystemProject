using CollegeSystem.DAL.Models;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class ActiveQuizManager : IActiveQuizManager
{
    private readonly IActiveQuizRepo _activeQuizRepo;

    public ActiveQuizManager(IActiveQuizRepo activeQuizRepo)
    {
        _activeQuizRepo = activeQuizRepo;
    }

    public void Add(ActiveQuizAddDto activeQuizAddDto)
    {
        var ActiveQuiz = new ActiveQuiz()
        {
            ActiveQuizzesId = activeQuizAddDto.ActiveQuizzesId,
            StartDate = activeQuizAddDto.StartDate,
            Quiz = activeQuizAddDto.Quiz,
            QuizId = activeQuizAddDto.QuizId,

        };
        _activeQuizRepo.Add(ActiveQuiz);
    }

    public void Update(ActiveQuizUpdateDto activeQuizUpdateDto)
    {
        var ActiveQuiz = _activeQuizRepo.GetById(activeQuizUpdateDto.ActiveQuizzesId);
        if (ActiveQuiz == null) return;
        ActiveQuiz.ActiveQuizzesId = activeQuizUpdateDto.ActiveQuizzesId;
        ActiveQuiz.StartDate = activeQuizUpdateDto.StartDate;
        ActiveQuiz.Quiz = activeQuizUpdateDto.Quiz;
        ActiveQuiz.QuizId = activeQuizUpdateDto.QuizId;


        _activeQuizRepo.Update(ActiveQuiz);
    }

    public void Delete(ActiveQuizDeleteDto activeQuizDeleteDto)
    {
        var ActiveQuiz = _activeQuizRepo.GetById(activeQuizDeleteDto.Id);
        if (ActiveQuiz == null) return;
        _activeQuizRepo.Delete(ActiveQuiz);
    }

    public ActiveQuizReadDto? Get(long id)
    {
        var ActiveQuiz = _activeQuizRepo.GetById(id);
        if (ActiveQuiz == null) return null;
        return new ActiveQuizReadDto()
        {
            ActiveQuizzesId = ActiveQuiz.ActiveQuizzesId,
            StartDate = ActiveQuiz.StartDate,
            Quiz = ActiveQuiz.Quiz,
            QuizId = ActiveQuiz.QuizId,

        };
    }

    public List<ActiveQuizReadDto> GetAll()
    {
        var ActiveQuiz = _activeQuizRepo.GetAll();
        return ActiveQuiz.Select(ActiveQuiz => new ActiveQuizReadDto()
        {
            ActiveQuizzesId = ActiveQuiz.ActiveQuizzesId,
            StartDate = ActiveQuiz.StartDate,
            Quiz = ActiveQuiz.Quiz,
            QuizId = ActiveQuiz.QuizId,

        }).ToList();
    }

  
}
