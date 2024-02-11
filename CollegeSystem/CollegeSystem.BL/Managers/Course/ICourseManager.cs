using Microsoft.AspNetCore.Http;

namespace CollegeSystem.DL;

public interface ICourseManager
{
    public void Add(CourseAddDto courseAddDto);
    public void Update(CourseUpdateDto courseUpdateDto);
    public void Delete(CourseDeleteDto courseDeleteDto);
    public CourseReadDto? Get(long id);
    public List<CourseReadDto> GetAll();
    public void UpdateImageAsync(int id, IFormFile file);
    public void DeleteImage(int id);
    public UploadCourseImageDto? GetImage(int id);
    public void AddImageAsync(IFormFile file,long id);
}