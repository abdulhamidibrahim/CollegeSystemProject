namespace CollegeSystem.DL;

public interface IActiveAllQuizManager
{
    public void Add(ActivAllQuizAddDto ActiveAllQuizAddDto);
    public void Update(ActivAllQuizUpdateDto ActiveAllQuizUpdateDto);
    public void Delete(ActiveAllQuizDeleteDto ActiveAllQuizDeleteDto);
    public ActivAllQuizReadDto? Get(long id);
    public List<ActivAllQuizReadDto> GetAll();
    // public UserReadDto Login(UserLoginDto userLoginDto);
}
