namespace CollegeSystem.DL;

public interface IAssignmentAnswerManager
{
    public void Add(AssignmentAnswerAddDto assignmentAnswerAddDto);
    public void Update(AssignmentAnswerUpdateDto assignmentAnswerUpdateDto);
    public void Delete(AssignmentAnswerDeleteDto assignmentAnswerDeleteDto);
    public AssignmentAnswerReadDto? Get(long id);
    public List<AssignmentAnswerReadDto> GetAll();
    // public UserReadDto Login(UserLoginDto userLoginDto);
}