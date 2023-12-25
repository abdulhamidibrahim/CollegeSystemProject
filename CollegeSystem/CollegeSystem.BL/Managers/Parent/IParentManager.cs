namespace CollegeSystem.DL;

public interface IParentManager
{
    public void Add(ParentAddDto parentAddDto);
    public void Update(ParentUpdateDto parentUpdateDto);
    public void Delete(ParentDeleteDto parentDeleteDto);
    public ParentReadDto? Get(long id);
    public List<ParentReadDto> GetAll();
    // public UserReadDto Login(UserLoginDto userLoginDto);
}