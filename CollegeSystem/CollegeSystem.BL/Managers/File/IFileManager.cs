using CollegeSystem.DL;
using Microsoft.AspNetCore.Http;

namespace CollegeSystem.BL.Managers.File;

public interface IFileManager
{
    public Task UploadLectureFilesAsync(long lectureId,LectureFileAddDto fileAddDto, IEnumerable<IFormFile> files);
    
    public Task UploadSectionFilesAsync(long lectureId, SectionFileAddDto sectionFileAdd, IEnumerable<IFormFile> files);

    public Task<LectureFileDownloadDto> DownloadLectureFileAsync(long lectureFileId);

    public Task<SectionFileDownloadDto> DownloadSectionFileAsync(long sectionFileId);

    public Task<bool> DeleteLectureFileAsync(long lectureFileId);

    public Task<bool> DeleteSectionFileAsync(long sectionFileId);

    public Task<List<LectureFileReadDto>> ListLectureFilesAsync(long lectureId);

    public Task<List<SectionFileReadDto>> ListSectionFilesAsync(long sectionId);

    // Task<List<string>> UploadFilesAsync(IEnumerable<IFormFile> files);
    // Task DeleteFileAsync(string fileUrl);
}