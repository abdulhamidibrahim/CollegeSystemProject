namespace CollegeSystem.DL;

public interface IDepartmentManager
{
    public void Add(DepartmentAddDto departmentAddDto);
    public void Update(DepartmentUpdateDto departmentUpdateDto);
    public void Delete(long id);
    public DepartmentReadDto? Get(long id);
    public List<DepartmentReadDto> GetAll();
    // public UserReadDto Login(UserLoginDto userLoginDto);
}