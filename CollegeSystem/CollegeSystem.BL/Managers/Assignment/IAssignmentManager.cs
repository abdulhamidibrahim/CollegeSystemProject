namespace CollegeSystem.DL;

public interface IAssignmentManager
{
    public void Add(AssignmentAddDto assignmentAddDto);
    public void Update(AssignmentUpdateDto assignmentUpdateDto);
    public void Delete(AssignmentDeleteDto assignmentDeleteDto);
    public AssignmentReadDto? Get(long id);
    public List<AssignmentReadDto> GetAll();
    // public UserReadDto Login(UserLoginDto userLoginDto);
}