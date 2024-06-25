using Microsoft.AspNetCore.Http;

namespace CollegeSystem.DL;

public interface ISectionManager
{
    public void Add(SectionAddDto sectionAddDto);
    public void Update(SectionUpdateDto sectionUpdateDto);
    public void Delete(SectionDeleteDto sectionDeleteDto);
    public SectionReadDto? Get(long id);
    public List<SectionReadDto> GetAll(long courseId);
    public void UpdateFileAsync(int id, IFormFile file);
    public void DeleteFile(int id);
    public UploadSectionFileDto? GetFile(int id);
    public void AddFileAsync(IFormFile file,long id);
    public List<UploadSectionFileDto> GetAllFiles();
}