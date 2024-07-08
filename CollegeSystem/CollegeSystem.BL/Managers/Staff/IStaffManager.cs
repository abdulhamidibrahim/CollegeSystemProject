namespace CollegeSystem.DL;

public interface IStaffManager
{
    public void Add(StaffAddDto staffAddDto);
    public void Update(StaffUpdateDto staffUpdateDto);
    public void Delete(long id);
    public StaffReadDto? Get(long id);
    public List<StaffReadDto> GetAll();
    
}