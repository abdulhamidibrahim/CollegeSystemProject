using CollegeSystem.DAL.Models;
using CollegeSystem.DAL.UnitOfWork;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class ActiveQuizManager : IActiveQuizManager
{
    private readonly IActiveQuizRepo _activeQuizRepo;
    private readonly IUnitOfWork _unitOfWork;

    public ActiveQuizManager(IActiveQuizRepo activeQuizRepo, IUnitOfWork unitOfWork)
    {
        _activeQuizRepo = activeQuizRepo;
        _unitOfWork = unitOfWork;
    }

    public void Add(ActiveQuizAddDto activeQuizAddDto)
    {
        var activeQuiz = new ActiveQuiz()
        {
            ActiveQuizzesId = activeQuizAddDto.ActiveQuizzesId,
            StartDate = activeQuizAddDto.StartDate,
            QuizId = activeQuizAddDto.QuizId,
            Duration = activeQuizAddDto.Duration
        };
        _activeQuizRepo.Add(activeQuiz);
        _unitOfWork.CompleteAsync();

    }

    public void Update(ActiveQuizUpdateDto activeQuizUpdateDto)
    {
        var activeQuiz = _activeQuizRepo.GetById(activeQuizUpdateDto.ActiveQuizzesId);
        if (activeQuiz == null) return;
        activeQuiz.ActiveQuizzesId = activeQuizUpdateDto.ActiveQuizzesId;
        activeQuiz.StartDate = activeQuizUpdateDto.StartDate;
        activeQuiz.QuizId = activeQuizUpdateDto.QuizId;
        activeQuiz.Duration = activeQuizUpdateDto.Duration;

        _activeQuizRepo.Update(activeQuiz);
        _unitOfWork.CompleteAsync();
    }

    public void Delete(ActiveQuizDeleteDto activeQuizDeleteDto)
    {
        var activeQuiz = _activeQuizRepo.GetById(activeQuizDeleteDto.Id);
        if (activeQuiz == null) return;
        _activeQuizRepo.Delete(activeQuiz);
        _unitOfWork.CompleteAsync();
    }

    public ActiveQuizReadDto? Get(long quizId)
    {
        var activeQuiz = _activeQuizRepo.GetByQuizId(quizId);
        if (activeQuiz == null) return null;
        return new ActiveQuizReadDto()
        {
            ActiveQuizzesId = activeQuiz.ActiveQuizzesId,
            StartDate = activeQuiz.StartDate,
            QuizId = activeQuiz.QuizId,
            Duration = activeQuiz.Duration
        };
    }

    public List<ActiveQuizReadDto> GetAll()
    {
        var activeQuizzes = _activeQuizRepo.GetAll();
        return activeQuizzes.Select(activeQuiz => new ActiveQuizReadDto()
        {
            ActiveQuizzesId = activeQuiz.ActiveQuizzesId,
            StartDate = activeQuiz.StartDate,
            QuizId = activeQuiz.QuizId,
            Duration = activeQuiz.Duration
        }).ToList();
    }

    public List<ActiveQuizReadDto> GetAllSectionQuizzes()
    {
        var activeQuizzes = _activeQuizRepo.GetSectionsActiveQuiz();
        return activeQuizzes!.Select(activeQuiz => new ActiveQuizReadDto()
        {
            ActiveQuizzesId = activeQuiz.ActiveQuizzesId,
            StartDate = activeQuiz.StartDate,
            QuizId = activeQuiz.QuizId,
            Duration = activeQuiz.Duration

        }).ToList();
    }
    
    public List<ActiveQuizReadDto> GetAllLectureQuizzes()
    {
        var activeQuizzes = _activeQuizRepo.GetLecturesActiveQuiz();
        return activeQuizzes!.Select(activeQuiz => new ActiveQuizReadDto()
        {
            ActiveQuizzesId = activeQuiz.ActiveQuizzesId,
            StartDate = activeQuiz.StartDate,
            QuizId = activeQuiz.QuizId,
            Duration = activeQuiz.Duration

        }).ToList();
    }
  
}
