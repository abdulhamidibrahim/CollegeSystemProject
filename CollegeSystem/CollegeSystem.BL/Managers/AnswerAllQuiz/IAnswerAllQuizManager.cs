namespace CollegeSystem.DL;

public interface IAnswerAllQuizManager
{
    public void Add(AnswerAllQuizAddDto answerAllQuizAddDto);
    public void Update(AnswerAllQuizUpdateDto answerAllQuizUpdateDto);
    public void Delete(AnswerAllQuizDeleteDto answerAllQuizDeleteDto);
    public AnswerAllQuizReadDto? Get(long id);
    public List<AnswerAllQuizReadDto> GetAll();
    // public UserReadDto Login(UserLoginDto userLoginDto);
}

