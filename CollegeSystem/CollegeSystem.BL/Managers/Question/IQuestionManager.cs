namespace CollegeSystem.DL;

public interface IQuestionManager
{
    public void Add(QuestionAddDto questionAddDto);
    public void Update(QuestionUpdateDto questionUpdateDto);
    public void Delete(QuestionDeleteDto questionDeleteDto);
    public QuestionReadDto? Get(long id);
    public List<QuestionReadDto> GetAllByQuizId(long quizId);
    // public UserReadDto Login(UserLoginDto userLoginDto);
}