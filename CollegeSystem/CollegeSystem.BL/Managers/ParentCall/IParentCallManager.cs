namespace CollegeSystem.DL;

public interface IParentCallManager
{
    public void Add(ParentCallAddDto parentCallAddDto);
    public void Update(ParentCallUpdateDto parentCallUpdateDto);
    public void Delete(ParentCallDeleteDto parentCallDeleteDto);
    public ParentCallReadDto? Get(long id);
    public List<ParentCallReadDto> GetAll();
    // public UserReadDto Login(UserLoginDto userLoginDto);
}