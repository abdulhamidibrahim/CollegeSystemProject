using CollegeSystem.DAL.Models;
using CollegeSystem.DAL.UnitOfWork;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class AnswerAllQuizManager : IAnswerAllQuizManager
{
    private readonly IAnswerAllQuizRepo _answerAllQuizRepo;
    private readonly IUnitOfWork _unitOfWork;

    public AnswerAllQuizManager(IAnswerAllQuizRepo answerAllQuizRepo, IUnitOfWork unitOfWork)
    {
        _answerAllQuizRepo = answerAllQuizRepo;
        _unitOfWork = unitOfWork;
    }

    public void Add(AnswerAllQuizAddDto answerAllQuizAddDto)
    {
        var answerAllQuiz = new AnswerAllQuiz()
        {
            StudentMark = answerAllQuizAddDto.StudentMark,
            AllQuizzesId = answerAllQuizAddDto.AllQuizzesId,
            CourseId = answerAllQuizAddDto.CourseId,
        };
        _answerAllQuizRepo.Add(answerAllQuiz);
        _unitOfWork.CompleteAsync();
    }

    public void Update(AnswerAllQuizUpdateDto answerAllQuizUpdateDto)
    {
        var answerAllQuiz = _answerAllQuizRepo.GetById(answerAllQuizUpdateDto.AnswerAllQuizzesId);
        if (answerAllQuiz == null) return;
        answerAllQuiz.StudentMark = answerAllQuizUpdateDto.StudentMark;
        answerAllQuiz.CourseId = answerAllQuizUpdateDto.CourseId;
        answerAllQuiz.AllQuizzesId = answerAllQuizUpdateDto.AllQuizzesId;
       

        _answerAllQuizRepo.Update(answerAllQuiz);
        _unitOfWork.CompleteAsync();
    }

    public void Delete(AnswerAllQuizDeleteDto answerDeleteAllQuizDto)
    {
        var answerAllQuiz = _answerAllQuizRepo.GetById(answerDeleteAllQuizDto.Id);
        if (answerAllQuiz == null) return;
        _answerAllQuizRepo.Delete(answerAllQuiz);
        _unitOfWork.CompleteAsync();
    }

    public AnswerAllQuizReadDto? Get(long id)
    {
        var answerAllQuiz = _answerAllQuizRepo.GetById(id);
        if (answerAllQuiz == null) return null;
        return new AnswerAllQuizReadDto()
        {
            StudentMark = answerAllQuiz.StudentMark,
            CourseId = answerAllQuiz.CourseId,
            AllQuizzesId = answerAllQuiz.AllQuizzesId,
        };
    }

    public List<AnswerAllQuizReadDto> GetAll()
    {
        var answers = _answerAllQuizRepo.GetAll();
        return answers.Select(answerAllQuiz => new AnswerAllQuizReadDto()
        {
            StudentMark = answerAllQuiz.StudentMark,
            CourseId = answerAllQuiz.CourseId,
            AllQuizzesId = answerAllQuiz.AllQuizzesId,
        }).ToList();
    }
}

