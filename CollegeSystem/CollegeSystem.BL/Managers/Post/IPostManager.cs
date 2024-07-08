namespace CollegeSystem.DL;

public interface IPostManager
{
    public Task<int> Add(PostAddDto postAddDto);
    public Task<int> Update(PostUpdateDto postUpdateDto);
    public Task<int> Delete(long id);
    public PostReadDto? Get(long id);
    public List<PostReadDto> GetAll(long courseId);
    // public UserReadDto Login(UserLoginDto userLoginDto);
}