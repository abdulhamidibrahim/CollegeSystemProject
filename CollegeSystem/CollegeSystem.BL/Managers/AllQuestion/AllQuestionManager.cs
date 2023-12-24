using CollegeSystem.DAL.Models;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class AllQuestionManager :IAllQuestionManager
{
    private readonly IAllQuestionRepo _allQuestionRepo;

    public AllQuestionManager(IAllQuestionRepo allQuestionRepo)
    {
        _allQuestionRepo = allQuestionRepo;
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
    }

    public void Delete(AllQuestionDeleteDto allQuestionDeleteDto)
    {
        var allQuestion = _allQuestionRepo.GetById(allQuestionDeleteDto.Id);
        if (allQuestion == null) return;
        _allQuestionRepo.Delete(allQuestion);
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