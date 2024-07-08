namespace CollegeSystem.DL;

public interface IAllQuizManager
{
    public void Add(AllQuizAddDto allQuizAddDto);
    public void Update(AllQuizUpdateDto allQuizUpdateDto);
    public void Delete(AllQuizDeleteDto allQuizDeleteDto);
    public AllQuizReadDto? Get(long id);
    public List<AllQuizReadDto> GetAll();
    // public UserReadDto Login(UserLoginDto userLoginDto);
}
