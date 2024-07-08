using CollegeSystem.DAL.Models;
using CollegeSystem.DAL.UnitOfWork;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class ActiveAllQuizManager : IActiveAllQuizManager
{
    private readonly IActiveAllQuizRepo _activeAllQuizRepo;
    private readonly IUnitOfWork _unitOfWork;
    public ActiveAllQuizManager(IActiveAllQuizRepo activeAllQuizRepo, IUnitOfWork unitOfWork)
    {
        _activeAllQuizRepo = activeAllQuizRepo;
        _unitOfWork = unitOfWork;
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
        _unitOfWork.CompleteAsync();
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
        _unitOfWork.CompleteAsync();

    }

    public void Delete(ActiveAllQuizDeleteDto activeAllQuizDeleteDto)
    {
        var activeAllQuiz = _activeAllQuizRepo.GetById(activeAllQuizDeleteDto.Id);
        if (activeAllQuiz == null) return;
        _activeAllQuizRepo.Delete(activeAllQuiz);
        _unitOfWork.CompleteAsync();

    }

    public ActivAllQuizReadDto? Get(long id)
    {
        var activeAllQuiz = _activeAllQuizRepo.GetById(id);
        if (activeAllQuiz == null) return null;
        return new ActivAllQuizReadDto()
        {
            ActiveAllQuizId = activeAllQuiz.ActiveAllQuizzesId,
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
            
            ActiveAllQuizId = allQuiz.ActiveAllQuizzesId,
            AllQuizzesId = allQuiz.AllQuizzesId,
            StartDate = allQuiz.StartDate,
            AllQuizzes = allQuiz.AllQuizzes,

        }).ToList();
    }
}
