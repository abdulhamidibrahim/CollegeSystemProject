namespace CollegeSystem.DL;

public interface IAllQuestionManager
{
    public void Add(AllQuestionAddDto allQuestionAddDto);
    public void Update(AllQuestionUpdateDto allQuestionUpdateDto);
    public void Delete(AllQuestionDeleteDto allQuestionDeleteDto);
    public AllQuestionReadDto? Get(long id);
    public List<AllQuestionReadDto> GetAll();
    // public UserReadDto Login(UserLoginDto userLoginDto);
}