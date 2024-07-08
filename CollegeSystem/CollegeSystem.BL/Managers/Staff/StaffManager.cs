using CollegeSystem.DAL.Models;
using CollegeSystem.DAL.UnitOfWork;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class StaffManager:IStaffManager
{
    private readonly IUnitOfWork _unitOfWork;

    public StaffManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
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
        _unitOfWork.Staff.Add(staff);
        _unitOfWork.CompleteAsync();
    }

    public void Update(StaffUpdateDto staffUpdateDto)
    {
        var staff = _unitOfWork.Staff.GetById(staffUpdateDto.StaffId);
        if (staff == null) return;
        staff.Name = staffUpdateDto.Name;
        staff.Email = staffUpdateDto.Email;
        staff.Password = staffUpdateDto.Password;
        staff.Phone = staffUpdateDto.Phone;
        
        _unitOfWork.Staff.Update(staff);
        _unitOfWork.CompleteAsync();
    }

    public void Delete(long id)
    {
        var staff = _unitOfWork.Staff.GetById(id);
        if (staff == null) return;
        _unitOfWork.Staff.Delete(staff);
        _unitOfWork.CompleteAsync();
    }

    public StaffReadDto? Get(long id)
    {
        var staff = _unitOfWork.Staff.GetById(id);
        if (staff == null) return null;
        return new StaffReadDto()
        {
            Id = staff.Id,
            Name = staff.Name,
            Email = staff.Email,
            Password = staff.Password,
            Phone = staff.Phone,
            
        };
    }

    public List<StaffReadDto> GetAll()
    {
        var staffs = _unitOfWork.Staff.GetAll();
        return staffs.Select(staff => new StaffReadDto()
        {          
            Id = staff.Id,
            Name = staff.Name,
            Email = staff.Email,
            Password = staff.Password,
            Phone = staff.Phone,
        }).ToList();
    }
}