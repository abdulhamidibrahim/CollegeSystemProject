namespace CollegeSystem.DL;

public interface IQuizManager
{
    public void Add(QuizAddDto quizAddDto);
    public void Update(QuizUpdateDto quizUpdateDto);
    public void Delete(QuizDeleteDto quizDeleteDto);
    public QuizReadDto? Get(long id);
    public List<QuizReadDto> GetAll();
    // public UserReadDto Login(UserLoginDto userLoginDto);
}