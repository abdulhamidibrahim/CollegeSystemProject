using Microsoft.AspNetCore.Http;

namespace CollegeSystem.DL;

public interface ILectureManager
{
    public void Add(LectureAddDto lectureAddDto);
    public void Update(LectureUpdateDto lectureUpdateDto);
    public void Delete(long id);
    public LectureReadDto? Get(long id);
    public List<LectureReadDto> GetAll(long courseId);
    
    public void UpdateFileAsync(int id, IFormFile file);
    public void DeleteFile(int id);
    public UploadLectureFileDto? GetFile(int id);
    public List<UploadLectureFileDto>? GetAllFiles();
    public void AddFileAsync(IFormFile file,long id);
}