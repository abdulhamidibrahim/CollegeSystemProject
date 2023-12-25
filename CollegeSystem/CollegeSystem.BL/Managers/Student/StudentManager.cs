using CollegeSystem.DAL.Models;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class StudentManager:IStudentManager
{
    private readonly IStudentRepo _studentRepo;

    public StudentManager(IStudentRepo studentRepo)
    {
        _studentRepo = studentRepo;
    }
    
    public void Add(StudentAddDto studentAddDto)
    {
        var user = new Student()
        {
             Id = studentAddDto.StudentCode,
             ArabicName = studentAddDto.Name,
             Email = studentAddDto.Email,
             UniversityEmail = studentAddDto.UniversityEmail,
             Phone = studentAddDto.Phone,
             Password = studentAddDto.Password,
             Ssn = studentAddDto.Ssn,
             Img = studentAddDto.Img,
             ParentEmail = studentAddDto.ParentEmail,
             ParentPhone = studentAddDto.ParentPhone,
        };
        _studentRepo.Add(user);
    }

    public void Update(StudentUpdateDto studentUpdateDto)
    {
        var user = _studentRepo.GetById(studentUpdateDto.Id);
        if (user == null) return;
        user.ArabicName = studentUpdateDto.Name;
        user.Email = studentUpdateDto.Email;
        user.UniversityEmail = studentUpdateDto.UniversityEmail;
        user.Password = studentUpdateDto.Password;
        user.Ssn = studentUpdateDto.Ssn;
        user.Img = studentUpdateDto.Img;
        user.Phone = studentUpdateDto.Phone;
        user.ParentEmail = studentUpdateDto.ParentEmail;
        user.ParentPhone = studentUpdateDto.ParentPhone;
        
        _studentRepo.Update(user);
    }

    public void Delete(StudentDeleteDto studentDeleteDto)
    {
        var user = _studentRepo.GetById(studentDeleteDto.Id);
        if (user == null) return;
        _studentRepo.Delete(user);
    }

    public StudentReadDto? Get(long id)
    {
        var user = _studentRepo.GetById(id);
        if (user == null) return null;
        return new StudentReadDto()
        {
            Name = user.ArabicName,
            Email = user.Email,
            UniversityEmail = user.UniversityEmail,
            Phone = user.Phone,
            Ssn = user.Ssn,
            Img = user.Img,
            ParentEmail = user.ParentEmail,
            ParentPhone = user.ParentPhone,
        };
    }

    public List<StudentReadDto> GetAll()
    {
        var users = _studentRepo.GetAll();
        return users.Select(user => new StudentReadDto()
        {
            Name = user.ArabicName,
            Email = user.Email,
            UniversityEmail = user.UniversityEmail,
            Phone = user.Phone,
            Ssn = user.Ssn,
            Img = user.Img,
            ParentEmail = user.ParentEmail,
            ParentPhone = user.ParentPhone,
        }).ToList();
    }
}