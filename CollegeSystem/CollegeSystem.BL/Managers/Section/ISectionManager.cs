namespace CollegeSystem.DL;

public interface ISectionManager
{
    public void Add(SectionAddDto sectionAddDto);
    public void Update(SectionUpdateDto sectionUpdateDto);
    public void Delete(SectionDeleteDto sectionDeleteDto);
    public SectionReadDto? Get(long id);
    public List<SectionReadDto> GetAll();
    // public UserReadDto Login(UserLoginDto userLoginDto);
}