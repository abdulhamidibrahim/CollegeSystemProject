namespace CollegeSystem.DL;

public interface IStaffManager
{
    public void Add(StaffAddDto staffAddDto);
    public void Update(StaffUpdateDto staffUpdateDto);
    public void Delete(StaffDeleteDto staffDeleteDto);
    public StaffReadDto? Get(long id);
    public List<StaffReadDto> GetAll();
    
}