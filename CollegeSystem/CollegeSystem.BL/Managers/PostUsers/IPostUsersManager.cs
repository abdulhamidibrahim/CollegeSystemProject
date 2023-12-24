namespace CollegeSystem.DL;

public interface IPostUsersManager
{
    public void Add(PostUsersAddDto postUsersAddDto);
    public void Update(PostUsersUpdateDto postUsersUpdateDto);
    public void Delete(PostUsersDeleteDto postUsersDeleteDto);
    public PostUsersReadDto? Get(long id);
    public List<PostUsersReadDto> GetAll();
    // public UserReadDto Login(UserLoginDto userLoginDto);
}