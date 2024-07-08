using CollegeSystem.DAL.Models;
using CollegeSystem.DAL.UnitOfWork;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class DepartmentManager:IDepartmentManager
{
    private readonly IUnitOfWork _unitOfWork;

    public DepartmentManager(IUnitOfWork unitOfWork)
    {
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
        _unitOfWork.Department.Add(department);
        _unitOfWork.CompleteAsync();

    }

    public void Update(DepartmentUpdateDto departmentUpdateDto)
    {
        var department = _unitOfWork.Department.GetById(departmentUpdateDto.DeptId);
        if (department == null) return;
        department.Name = departmentUpdateDto.Name;
        department.HeadOfDepartment = departmentUpdateDto.HeadOfDepartment;
        department.Code = departmentUpdateDto.Code;
        
        _unitOfWork.Department.Update(department);
        _unitOfWork.CompleteAsync();
    }

    public void Delete(long id)
    {
        var department = _unitOfWork.Department.GetById(id);
        if (department == null) return;
        _unitOfWork.Department.Delete(department);
        _unitOfWork.CompleteAsync();
    }

    public DepartmentReadDto? Get(long id)
    {
        var department = _unitOfWork.Department.GetById(id);
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
        var departments = _unitOfWork.Department.GetAll();
        return departments.Select(department => new DepartmentReadDto()
        {
            Id = department.DeptId,
            Name = department.Name,
            HeadOfDepartment = department.HeadOfDepartment,
            Code = department.Code,
        }).ToList();
    }
}
