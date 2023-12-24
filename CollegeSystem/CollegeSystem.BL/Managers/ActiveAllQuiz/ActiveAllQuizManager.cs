using CollegeSystem.DAL.Models;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class ActiveAllQuizManager : IActiveAllQuizManager
{
    private readonly IActiveAllQuizRepo _activeAllQuizRepo;

    public ActiveAllQuizManager(IActiveAllQuizRepo activeAllQuizRepo)
    {
        _activeAllQuizRepo = activeAllQuizRepo;
    }

    public void Add(ActivAllQuizAddDto activeAllQuizAddDto)
    {
        var activeAllQuiz = new ActiveAllQuiz()
        {
            AllQuizzesId = activeAllQuizAddDto.AllQuizzesId,
            StartDate =   activeAllQuizAddDto.StartDate,
            AllQuizzes =  activeAllQuizAddDto.AllQuizzes,
            
        };
        _activeAllQuizRepo.Add(activeAllQuiz);
    }

    public void Update(ActivAllQuizUpdateDto activeAllQuizUpdateDto)
    {
        var activeAllQuiz = _activeAllQuizRepo.GetById(activeAllQuizUpdateDto.ActiveAllQuizzesId);
        if (activeAllQuiz == null) return;
        activeAllQuiz.AllQuizzesId = activeAllQuizUpdateDto.AllQuizzesId;
        activeAllQuiz.StartDate = activeAllQuizUpdateDto.StartDate;
        activeAllQuiz.AllQuizzes = activeAllQuizUpdateDto.AllQuizzes;
        activeAllQuiz.ActiveAllQuizzesId = activeAllQuizUpdateDto.ActiveAllQuizzesId;


        _activeAllQuizRepo.Update(activeAllQuiz);
    }

    public void Delete(ActiveAllQuizDeleteDto activeAllQuizDeleteDto)
    {
        var activeAllQuiz = _activeAllQuizRepo.GetById(activeAllQuizDeleteDto.Id);
        if (activeAllQuiz == null) return;
        _activeAllQuizRepo.Delete(activeAllQuiz);
    }

    public ActivAllQuizReadDto? Get(long id)
    {
        var activeAllQuiz = _activeAllQuizRepo.GetById(id);
        if (activeAllQuiz == null) return null;
        return new ActivAllQuizReadDto()
        {
            AllQuizzesId = activeAllQuiz.AllQuizzesId,
            StartDate = activeAllQuiz.StartDate,
            AllQuizzes = activeAllQuiz.AllQuizzes,

        };
    }

    public List<ActivAllQuizReadDto> GetAll()
    {
        var activeAllQuiz = _activeAllQuizRepo.GetAll();
        return activeAllQuiz.Select(allQuiz => new ActivAllQuizReadDto()
        {
            AllQuizzesId = allQuiz.AllQuizzesId,
            StartDate = allQuiz.StartDate,
            AllQuizzes = allQuiz.AllQuizzes,

        }).ToList();
    }
}
