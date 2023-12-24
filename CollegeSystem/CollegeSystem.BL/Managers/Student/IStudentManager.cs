namespace CollegeSystem.DL;

public interface IStudentManager
{
    public void Add(StudentAddDto studentAddDto);
    public void Update(StudentUpdateDto studentUpdateDto);
    public void Delete(StudentDeleteDto studentDeleteDto);
    public StudentReadDto? Get(long id);
    public List<StudentReadDto> GetAll();
    // public UserReadDto Login(UserLoginDto userLoginDto);
}