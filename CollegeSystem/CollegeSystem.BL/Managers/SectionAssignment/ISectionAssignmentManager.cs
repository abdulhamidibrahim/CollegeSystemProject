namespace CollegeSystem.DL;

public interface ISectionAssignmentManager
{
    public void Add(SectionAssignmentAddDto sectionAssignmentAddDto);
    public void Update(SectionAssignmentUpdateDto sectionAssignmentUpdateDto);
    public void Delete(SectionAssignmentDeleteDto sectionAssignmentDeleteDto);
    public SectionAssignmentReadDto? Get(long id);
    public List<SectionAssignmentReadDto> GetAll();
    // public UserReadDto Login(UserLoginDto userLoginDto);
}