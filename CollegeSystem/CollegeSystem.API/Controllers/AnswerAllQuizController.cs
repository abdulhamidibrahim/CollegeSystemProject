using CollegeSystem.DL;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnswerAllQuizController : ControllerBase
{
    private readonly IAnswerAllQuizManager _answerAllQuizManager;

    public AnswerAllQuizController(IAnswerAllQuizManager answerAllQuizManager)
    {
        _answerAllQuizManager = answerAllQuizManager;
    }
    [HttpGet]
    public ActionResult<List<AnswerAllQuizReadDto>> GetAll()
    {
        return _answerAllQuizManager.GetAll();
    }
    [HttpGet("{id}")]
    public ActionResult<AnswerAllQuizReadDto?> Get(long id)
    {
        var user = _answerAllQuizManager.Get(id);
        if (user == null) return NotFound();
        return user;
    }
    [HttpPost]
    public ActionResult Add(AnswerAllQuizAddDto answerAllQuizAddDto)
    {
        _answerAllQuizManager.Add(answerAllQuizAddDto);
        return Ok();
    }
    [HttpPut]
    public ActionResult Update(AnswerAllQuizUpdateDto answerAllQuizUpdateDto)
    {
        _answerAllQuizManager.Update(answerAllQuizUpdateDto);
        return Ok();
    }
    [HttpDelete]
    public ActionResult Delete(AnswerAllQuizDeleteDto answerAllQuizDeleteDto)
    {
        _answerAllQuizManager.Delete(answerAllQuizDeleteDto);
        return Ok();
    }

}
