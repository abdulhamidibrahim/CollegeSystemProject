using Microsoft.AspNetCore.Http;

namespace CollegeSystem.DL;

public interface IStudentManager
{
    public void Add(StudentAddDto studentAddDto);
    public void Update(StudentUpdateDto studentUpdateDto);
    public void Delete(StudentDeleteDto studentDeleteDto);
    public StudentReadDto? Get(long id);
    public List<StudentReadDto> GetAll();
    public void UpdateImageAsync(int id, IFormFile file);
    public void DeleteImage(int id);
    public UploadStudentImageDto? GetImage(int id);
    public void AddImageAsync(IFormFile file,long id);
    // public UserReadDto Login(UserLoginDto userLoginDto);
}