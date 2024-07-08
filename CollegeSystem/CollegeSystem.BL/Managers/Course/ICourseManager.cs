using CollegeSystem.BL.Enums;
using Microsoft.AspNetCore.Http;

namespace CollegeSystem.DL;

public interface ICourseManager
{
    public void Add(CourseAddDto courseAddDto);
    public Task<int> Update(CourseUpdateDto courseUpdateDto);
    public void Delete(long id);
    public CourseReadDto? Get(long id);
    public List<CourseReadDto> GetAll();
    public void UpdateImageAsync(int id, IFormFile file);
    public void DeleteImage(long id);
    public UploadCourseImageDto? GetImage(int id);
    public void AddImageAsync(IFormFile file,long id);
    public List<CourseReadDto> GetCoursesByDeptId(int deptId);
    public List<CourseReadDto> GetCoursesByLevelAndTerm(long studentId, Level level, Term term);
    // register courses for student 
    public Task<int> RegisterCourses(long studentId, long[] courseId);
}