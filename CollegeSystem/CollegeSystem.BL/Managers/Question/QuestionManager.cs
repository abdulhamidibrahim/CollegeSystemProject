using CollegeSystem.DAL.Models;
using CollegeSystem.DAL.UnitOfWork;
using FCISystem.DAL;
using Microsoft.Extensions.Options;

namespace CollegeSystem.DL;

public class QuestionManager:IQuestionManager
{
    private readonly IUnitOfWork _unitOfWork;

    public QuestionManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Add(QuestionAddDto questionAddDto)
    {
        var options = questionAddDto.Options.Select(o => new Option()
        {
            Text = o.OptionText,
            QuestionID = o.QuestionId,
            IsCorrect = o.IsCorrect,
        }).ToList();

    var question = new Question()
        {
            QuestionText = questionAddDto.QuestionText,
            // QuizId = questionAddDto.QuizId,
            Options = options,
        };
        _unitOfWork.Question.Add(question);
        _unitOfWork.CompleteAsync();
    }

    public void Update(QuestionUpdateDto questionUpdateDto)
    {
        var question = _unitOfWork.Question.GetById(questionUpdateDto.QuestionId);
        if (question == null) return;
        
        question.QuestionText = questionUpdateDto.QuestionText;
        question.QuizId = questionUpdateDto.QuizId;

        question.Options = questionUpdateDto.Options.Select(o => new Option()
        {
            Text = o.OptionText,
            QuestionID = o.QuestionId,
            IsCorrect = o.IsCorrect
        }).ToList();
        
        
        _unitOfWork.Question.Update(question);
        _unitOfWork.CompleteAsync();
    }

    public void Delete(QuestionDeleteDto questionDeleteDto)
    {
        var question = _unitOfWork.Question.GetById(questionDeleteDto.Id);
        if (question == null) return;
        _unitOfWork.Question.Delete(question);
        _unitOfWork.CompleteAsync();
    }

    public QuestionReadDto? Get(long id)
    {
        var question = _unitOfWork.Question.GetById(id);
        if (question == null) return null;
        return new QuestionReadDto()
        {
            Id = question.Id,
            QuestionText = question.QuestionText,
           QuizId = question.QuizId,
           
           Options = question.Options.Select(o=> new OptionDto()
           {
               IsCorrect = o.IsCorrect,
               OptionText = o.Text,
               QuestionId = o.QuestionID,
           }).ToList()
           
        };
    }

    public List<QuestionReadDto> GetAll(long quizId)
    {
        var questions = _unitOfWork.Question.GetByQuizId(quizId);
        return questions.Select(question => new QuestionReadDto()
        {
            Id = question.Id,
            QuestionText = question.QuestionText,
            QuizId = question.QuizId,
            Options = question.Options.Select(o=> new OptionDto()
            {
                OptionText = o.Text,
                QuestionId = o.QuestionID,
                IsCorrect = o.IsCorrect
            }).ToList()
            
        }).ToList();
    }
}