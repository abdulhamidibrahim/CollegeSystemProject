using CollegeSystem.DAL.Models;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class QuestionManager:IQuestionManager
{
    private readonly IQuestionRepo _questionRepo;

    public QuestionManager(IQuestionRepo questionRepo)
    {
        _questionRepo = questionRepo;
    }
    
    public void Add(QuestionAddDto questionAddDto)
    {
        var question = new Question()
        {
            Question1 = questionAddDto.Question1,
            Answer = questionAddDto.Answer,
            Choice1 = questionAddDto.Choice1,
            Choice2 = questionAddDto.Choice2,
            Choice3 = questionAddDto.Choice3,
            Choice4 = questionAddDto.Choice4,
            Choice5 = questionAddDto.Choice5,
            QuizId = questionAddDto.QuizId
        };
        _questionRepo.Add(question);
    }

    public void Update(QuestionUpdateDto questionUpdateDto)
    {
        var question = _questionRepo.GetById(questionUpdateDto.QuestionId);
        if (question == null) return;
        question.Question1 = questionUpdateDto.Question1;
        question.Answer = questionUpdateDto.Answer;
        question.Choice1 = questionUpdateDto.Choice1;
        question.Choice2 = questionUpdateDto.Choice2;
        question.Choice3 = questionUpdateDto.Choice3;
        question.Choice4 = questionUpdateDto.Choice4;
        question.Choice5 = questionUpdateDto.Choice5;
        question.QuizId = questionUpdateDto.QuizId;        

        _questionRepo.Update(question);
    }

    public void Delete(QuestionDeleteDto questionDeleteDto)
    {
        var question = _questionRepo.GetById(questionDeleteDto.Id);
        if (question == null) return;
        _questionRepo.Delete(question);
    }

    public QuestionReadDto? Get(long id)
    {
        var question = _questionRepo.GetById(id);
        if (question == null) return null;
        return new QuestionReadDto()
        {
           Question1 = question.Question1,
           Answer = question.Answer,
           Choice1 = question.Choice1,
           Choice2 = question.Choice2,
           Choice3 = question.Choice3,
           Choice4 = question.Choice4,
           Choice5 = question.Choice5,
           QuizId = question.QuizId,

        };
    }

    public List<QuestionReadDto> GetAll()
    {
        var questions = _questionRepo.GetAll();
        return questions.Select(question => new QuestionReadDto()
        {
            Question1 = question.Question1,
            Answer = question.Answer,
            Choice1 = question.Choice1,
            Choice2 = question.Choice2,
            Choice3 = question.Choice3,
            Choice4 = question.Choice4,
            Choice5 = question.Choice5,
            QuizId = question.QuizId,
            
        }).ToList();
    }
}