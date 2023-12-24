using CollegeSystem.DL;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AllQuestionsController: ControllerBase
{
    private readonly IAllQuestionManager _allQuestionManager;

    public AllQuestionsController(IAllQuestionManager allQuestionManager)
    {
        _allQuestionManager = allQuestionManager;
    }
    
    [HttpGet]
    public ActionResult<List<AllQuestionReadDto>> GetAll()
    {
        return _allQuestionManager.GetAll();
    }
    
    [HttpGet("{id}")]
    public ActionResult<AllQuestionReadDto?> Get(long id)
    {
        var user = _allQuestionManager.Get(id);
        if (user == null) return NotFound();
        return user;
    }
    
    [HttpPost]
    public ActionResult Add(AllQuestionAddDto allQuestionAddDto)
    {
        _allQuestionManager.Add(allQuestionAddDto);
        return Ok();
    }
    
    [HttpPut]
    public ActionResult Update(AllQuestionUpdateDto allQuestionUpdateDto)
    {
        _allQuestionManager.Update(allQuestionUpdateDto);
        return Ok();
    }
    
    [HttpDelete]
    public ActionResult Delete(AllQuestionDeleteDto allQuestionDeleteDto)
    {
        _allQuestionManager.Delete(allQuestionDeleteDto);
        return Ok();
    }
    
}