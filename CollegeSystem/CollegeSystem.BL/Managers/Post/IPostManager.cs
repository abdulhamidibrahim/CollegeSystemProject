namespace CollegeSystem.DL;

public interface IPostManager
{
    public void Add(PostAddDto postAddDto);
    public void Update(PostUpdateDto postUpdateDto);
    public void Delete(PostDeleteDto postDeleteDto);
    public PostReadDto? Get(long id);
    public List<PostReadDto> GetAll();
    // public UserReadDto Login(UserLoginDto userLoginDto);
}