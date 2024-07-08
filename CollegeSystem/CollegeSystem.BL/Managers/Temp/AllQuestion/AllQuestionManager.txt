using CollegeSystem.DAL.Models;
using CollegeSystem.DAL.UnitOfWork;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class AllQuestionManager :IAllQuestionManager
{
    private readonly IAllQuestionRepo _allQuestionRepo;
    private readonly IUnitOfWork _unitOfWork;

    public AllQuestionManager(IAllQuestionRepo allQuestionRepo, IUnitOfWork unitOfWork)
    {
        _allQuestionRepo = allQuestionRepo;
        _unitOfWork = unitOfWork;
    }
    
    public void Add(AllQuestionAddDto allQuestionAddDto)
    {
        var allQuestion = new AllQuestion()
        {
            Question = allQuestionAddDto.Question,
            Answer = allQuestionAddDto.Answer,
            Choice1 = allQuestionAddDto.Choice1,
            Choice2 = allQuestionAddDto.Choice2,
            Choice3 = allQuestionAddDto.Choice3,
            Choice4 = allQuestionAddDto.Choice4,
            Choice5 = allQuestionAddDto.Choice5,
            AllQuizzesId = allQuestionAddDto.AllQuizzesId
        };
        _allQuestionRepo.Add(allQuestion);
        _unitOfWork.CompleteAsync();
    }

    public void Update(AllQuestionUpdateDto allQuestionUpdateDto)
    {
        var allQuestion = _allQuestionRepo.GetById(allQuestionUpdateDto.AllQuestionsId);
        if (allQuestion == null) return;
        allQuestion.Question = allQuestionUpdateDto.Question;
        allQuestion.Answer = allQuestionUpdateDto.Answer;
        allQuestion.Choice1 = allQuestionUpdateDto.Choice1;
        allQuestion.Choice2 = allQuestionUpdateDto.Choice2;
        allQuestion.Choice3 = allQuestionUpdateDto.Choice3;
        allQuestion.Choice4 = allQuestionUpdateDto.Choice4;
        allQuestion.Choice5 = allQuestionUpdateDto.Choice5;
        allQuestion.AllQuizzesId = allQuestionUpdateDto.AllQuizzesId;        

        _allQuestionRepo.Update(allQuestion);
        _unitOfWork.CompleteAsync();
    }

    public void Delete(AllQuestionDeleteDto allQuestionDeleteDto)
    {
        var allQuestion = _allQuestionRepo.GetById(allQuestionDeleteDto.Id);
        if (allQuestion == null) return;
        _allQuestionRepo.Delete(allQuestion);
        _unitOfWork.CompleteAsync();
    }

    public AllQuestionReadDto? Get(long id)
    {
        var allQuestion = _allQuestionRepo.GetById(id);
        if (allQuestion == null) return null;
        return new AllQuestionReadDto()
        {
           Question = allQuestion.Question,
           Answer = allQuestion.Answer,
           Choice1 = allQuestion.Choice1,
           Choice2 = allQuestion.Choice2,
           Choice3 = allQuestion.Choice3,
           Choice4 = allQuestion.Choice4,
           Choice5 = allQuestion.Choice5,
           AllQuizzesId = allQuestion.AllQuizzesId,

        };
    }

    public List<AllQuestionReadDto> GetAll()
    {
        var allQuestions = _allQuestionRepo.GetAll();
        return allQuestions.Select(allQuestion => new AllQuestionReadDto()
        {
            Id = allQuestion.AllQuestionsId,
            Question = allQuestion.Question,
            Answer = allQuestion.Answer,
            Choice1 = allQuestion.Choice1,
            Choice2 = allQuestion.Choice2,
            Choice3 = allQuestion.Choice3,
            Choice4 = allQuestion.Choice4,
            Choice5 = allQuestion.Choice5,
            AllQuizzesId = allQuestion.AllQuizzesId,
            
        }).ToList();
    }
}