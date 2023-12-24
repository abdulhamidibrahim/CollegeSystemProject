namespace CollegeSystem.DL;

public interface IActiveQuizManager
{
    public void Add(ActiveQuizAddDto activeQuizAddDto);
    public void Update(ActiveQuizUpdateDto activeQuizUpdateDto);
    public void Delete(ActiveQuizDeleteDto activeQuizDeleteDto);
    public ActiveQuizReadDto? Get(long id);
    public List<ActiveQuizReadDto> GetAll();
    // public UserReadDto Login(UserLoginDto userLoginDto);
}
