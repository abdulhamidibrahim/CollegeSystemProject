using CollegeSystem.DAL.Models;
using CollegeSystem.DAL.UnitOfWork;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class DepartmentManager:IDepartmentManager
{
    private readonly IDepartmentRepo _departmentRepo;
    private readonly IUnitOfWork _unitOfWork;

    public DepartmentManager(IDepartmentRepo departmentRepo, IUnitOfWork unitOfWork)
    {
        _departmentRepo = departmentRepo;
        _unitOfWork = unitOfWork;
    }
    
    public void Add(DepartmentAddDto departmentAddDto)
    {
        var department = new Department()
        {
            Name = departmentAddDto.Name,
            HeadOfDepartment = departmentAddDto.HeadOfDepartment,
            Code = departmentAddDto.Code,
        };
        _departmentRepo.Add(department);
        _unitOfWork.CompleteAsync();

    }

    public void Update(DepartmentUpdateDto departmentUpdateDto)
    {
        var department = _departmentRepo.GetById(departmentUpdateDto.DeptId);
        if (department == null) return;
        department.Name = departmentUpdateDto.Name;
        department.HeadOfDepartment = departmentUpdateDto.HeadOfDepartment;
        department.Code = departmentUpdateDto.Code;
        
        _departmentRepo.Update(department);
        _unitOfWork.CompleteAsync();
    }

    public void Delete(DepartmentDeleteDto departmentDeleteDto)
    {
        var department = _departmentRepo.GetById(departmentDeleteDto.DeptId);
        if (department == null) return;
        _departmentRepo.Delete(department);
        _unitOfWork.CompleteAsync();
    }

    public DepartmentReadDto? Get(long id)
    {
        var department = _departmentRepo.GetById(id);
        if (department == null) return null;
        return new DepartmentReadDto()
        {
            Id = department.DeptId,
            Name = department.Name,
            HeadOfDepartment = department.HeadOfDepartment,
            Code = department.Code,
        };
    }

    public List<DepartmentReadDto> GetAll()
    {
        var departments = _departmentRepo.GetAll();
        return departments.Select(department => new DepartmentReadDto()
        {
            Id = department.DeptId,
            Name = department.Name,
            HeadOfDepartment = department.HeadOfDepartment,
            Code = department.Code,
        }).ToList();
    }
}
