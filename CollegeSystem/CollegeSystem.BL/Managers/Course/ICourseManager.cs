namespace CollegeSystem.DL;

public interface ICourseManager
{
    public void Add(CourseAddDto courseAddDto);
    public void Update(CourseUpdateDto courseUpdateDto);
    public void Delete(CourseDeleteDto courseDeleteDto);
    public CourseReadDto? Get(long id);
    public List<CourseReadDto> GetAll();
    // public UserReadDto Login(UserLoginDto userLoginDto);
}