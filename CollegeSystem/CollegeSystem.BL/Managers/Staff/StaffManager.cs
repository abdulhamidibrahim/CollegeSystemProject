using CollegeSystem.DAL.Models;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class StaffManager:IStaffManager
{
    private readonly IStaffRepo _staffRepo;

    public StaffManager(IStaffRepo staffRepo)
    {
        _staffRepo = staffRepo;
    }
    
    public void Add(StaffAddDto staffAddDto)
    {
        var staff = new Staff()
        {
            Name = staffAddDto.Name,
            Email = staffAddDto.Email,
            Password = staffAddDto.Password,
            Phone = staffAddDto.Phone,
        };
        _staffRepo.Add(staff);
    }

    public void Update(StaffUpdateDto staffUpdateDto)
    {
        var staff = _staffRepo.GetById(staffUpdateDto.StaffId);
        if (staff == null) return;
        staff.Name = staffUpdateDto.Name;
        staff.Email = staffUpdateDto.Email;
        staff.Password = staffUpdateDto.Password;
        staff.Phone = staffUpdateDto.Phone;
        
        _staffRepo.Update(staff);
    }

    public void Delete(StaffDeleteDto staffDeleteDto)
    {
        var staff = _staffRepo.GetById(staffDeleteDto.Id);
        if (staff == null) return;
        _staffRepo.Delete(staff);
    }

    public StaffReadDto? Get(long id)
    {
        var staff = _staffRepo.GetById(id);
        if (staff == null) return null;
        return new StaffReadDto()
        {
            Name = staff.Name,
            Email = staff.Email,
            Password = staff.Password,
            Phone = staff.Phone,
            
        };
    }

    public List<StaffReadDto> GetAll()
    {
        var staffs = _staffRepo.GetAll();
        return staffs.Select(staff => new StaffReadDto()
        {
            Name = staff.Name,
            Email = staff.Email,
            Password = staff.Password,
            Phone = staff.Phone,
        }).ToList();
    }
}