using CollegeSystem.DL;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuestionsController: ControllerBase
{
    private readonly IQuestionManager _questionManager;

    public QuestionsController(IQuestionManager questionManager)
    {
        _questionManager = questionManager;
    }
    
    [HttpGet("getAllQuizQuestions/{quizId}")]
    public ActionResult<List<QuestionReadDto>> GetAll(long quizId)
    {
        return _questionManager.GetAllByQuizId(quizId);
    }
    
    [HttpGet("{id}")]
    public ActionResult<QuestionReadDto?> Get(long id)
    {
        var user = _questionManager.Get(id);
        if (user == null) return NotFound();
        return user;
    }
    
    [HttpPost]
    public ActionResult Add(QuestionAddDto questionAddDto)
    {
        _questionManager.Add(questionAddDto);
        return Ok();
    }
    
    [HttpPut]
    public ActionResult Update(QuestionUpdateDto questionUpdateDto)
    {
        _questionManager.Update(questionUpdateDto);
        return Ok();
    }
    
    [HttpDelete]
    public ActionResult Delete(QuestionDeleteDto questionDeleteDto)
    {
        _questionManager.Delete(questionDeleteDto);
        return Ok();
    }
    
}