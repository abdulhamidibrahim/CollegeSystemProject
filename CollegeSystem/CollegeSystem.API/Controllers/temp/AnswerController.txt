using CollegeSystem.DL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnswerController : ControllerBase
{
    private readonly IAnswerManager _answerManager;

    public AnswerController(IAnswerManager answerManager)
    {
        _answerManager = answerManager;
    }
    [HttpGet]
    public ActionResult<List<AnswerReadDto>> GetAll()
    {
        return _answerManager.GetAll();
    }
    [HttpGet("{id}")]
    public ActionResult<AnswerReadDto?> Get(long id)
    {
        var user = _answerManager.Get(id);
        if (user == null) return NotFound();
        return user;
    }
    [HttpPost]
    public ActionResult Add(AnswerAddDto answerAddDto)
    {
        _answerManager.Add(answerAddDto);
        return Ok();
    }
    [HttpPut]
    public ActionResult Update(AnswerUpdateDto answerUpdateDto)
    {
        _answerManager.Update(answerUpdateDto);
        return Ok();
    }
    
    [HttpDelete]
    public ActionResult Delete(AnswerDeleteDto answerDeleteDto)
    {
        _answerManager.Delete(answerDeleteDto);
        return Ok();
    }
    
    [Authorize(Roles = "Student")]
    [HttpGet("GetAllStudentAnswers/{id}")]
    public ActionResult<List<AnswerReadDto>> GetByStudentId(long id)
    {
        return _answerManager.GetAllStudentAnswers(id);
    }
    
    [Authorize(Roles = "Staff")]
    [HttpGet("GetAllQuizAnswers/{id}")]
    public ActionResult<List<AnswerReadDto>> GetByQuizId(long id)
    {
        return _answerManager.GetAllQuizAnswers(id);
    }

}
