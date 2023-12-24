using CollegeSystem.DL;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuizController: ControllerBase
{
    private readonly IQuizManager _quizManager;

    public QuizController(IQuizManager quizManager)
    {
        _quizManager = quizManager;
    }
    
    [HttpGet]
    public ActionResult<List<QuizReadDto>> GetAll()
    {
        return _quizManager.GetAll();
    }
    
    [HttpGet("{id}")]
    public ActionResult<QuizReadDto?> Get(long id)
    {
        var user = _quizManager.Get(id);
        if (user == null) return NotFound();
        return user;
    }
    
    [HttpPost]
    public ActionResult Add(QuizAddDto quizAddDto)
    {
        _quizManager.Add(quizAddDto);
        return Ok();
    }
    
    [HttpPut]
    public ActionResult Update(QuizUpdateDto quizUpdateDto)
    {
        _quizManager.Update(quizUpdateDto);
        return Ok();
    }
    
    [HttpDelete]
    public ActionResult Delete(QuizDeleteDto quizDeleteDto)
    {
        _quizManager.Delete(quizDeleteDto);
        return Ok();
    }
    
}