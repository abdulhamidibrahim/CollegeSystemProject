using CollegeSystem.BL.Managers.File;
using CollegeSystem.DL;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class FilesController : ControllerBase
{
    private readonly IFileManager _fileService;

    public FilesController(IFileManager fileService)
    {
        _fileService = fileService;
    }

    [Consumes("multipart/form-data")]
    [HttpPost("upload/lecture/{lectureId}")]
    public async Task<IActionResult> UploadLectureFiles(long lectureId, [FromForm] LectureFileAddDto lectureFile,
        [FromForm] List<IFormFile> files)
    {
        if (files == null || files.Count == 0)
        {
            return BadRequest(new { message = "No files provided." });
        }

        await _fileService.UploadLectureFilesAsync(lectureId, lectureFile, files);
        return Ok(new
        {
            message = "Files uploaded successfully."
        });
}

    [HttpPost("upload/section/{sectionId}")]
    public async Task<IActionResult> UploadSectionFiles(long sectionId,[FromForm] SectionFileAddDto sectionFileAdd, [FromForm] List<IFormFile> files)
    {
        if (files == null || files.Count == 0)
        {
            return BadRequest(new { message = "No files provided."});
        }

        await _fileService.UploadSectionFilesAsync(sectionId,sectionFileAdd, files);
        return Ok(new { message = "Files uploaded successfully."});
    }

    [HttpGet("download/lecture/{lectureFileId}")]
    public async Task<IActionResult> DownloadLectureFile(int lectureFileId)
    {
        try
        {
            var file = await _fileService.DownloadLectureFileAsync(lectureFileId);
            return File(file.FileData, "application/octet-stream",file.FileName);
        }
        catch (FileNotFoundException)
        {
            return NotFound(new { message = "File not found."});
        }
    }

    [HttpGet("download/section/{sectionFileId}")]
    public async Task<IActionResult> DownloadSectionFile(int sectionFileId)
    {
        try
        {
            var file = await _fileService.DownloadSectionFileAsync(sectionFileId);
            return File(file.FileData, "application/octet-stream",file.FileName);
        }
        catch (FileNotFoundException)
        {
            return NotFound(new { message = "File not found."});
        }
    }

    [HttpDelete("delete/lecture/{lectureFileId}")]
    public async Task<IActionResult> DeleteLectureFile(int lectureFileId)
    {
        var success = await _fileService.DeleteLectureFileAsync(lectureFileId);
        if (success)
        {
            return NoContent();
        }
        return NotFound(new { message = "File not found."});
    }

    [HttpDelete("delete/section/{sectionFileId}")]
    public async Task<IActionResult> DeleteSectionFile(int sectionFileId)
    {
        var success = await _fileService.DeleteSectionFileAsync(sectionFileId);
        if (success)
        {
            return NoContent();
        }
        return NotFound(new { message = "File not found."});
    }

    [HttpGet("list/lecture/{lectureId}")]
    public async Task<IActionResult> ListLectureFiles(int lectureId)
    {
        var lectureFiles = await _fileService.ListLectureFilesAsync(lectureId);
        return Ok(lectureFiles);
    }

    [HttpGet("list/section/{sectionId}")]
    public async Task<IActionResult> ListSectionFiles(int sectionId)
    {
        var sectionFiles = await _fileService.ListSectionFilesAsync(sectionId);
        return Ok(sectionFiles);
    }
}
