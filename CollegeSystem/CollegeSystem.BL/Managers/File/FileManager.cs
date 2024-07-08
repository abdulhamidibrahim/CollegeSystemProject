using System.ComponentModel.DataAnnotations;
using System.Net;
using CollegeSystem.DAL.Context;
using CollegeSystem.DAL.Models;
using CollegeSystem.DL;
using FCISystem.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static CollegeSystem.DAL.Models.File;

namespace CollegeSystem.BL.Managers.File;

public class FileManager : IFileManager
{
    private readonly CollegeSystemDbContext _context;

    public FileManager(CollegeSystemDbContext context)
    {
        _context = context;
    }

    public async Task UploadLectureFilesAsync(long lectureId,[Required] LectureFileAddDto lectureFileDto, IEnumerable<IFormFile> files)
    {
        var lecture = await _context.Lectures.FindAsync(lectureId);
        if (lecture == null)
        {
            throw new ArgumentException("Lecture not found.");
        }

        foreach (var file in files)
        {
            if (file.Length > 0)
            {
                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    var fileBytes = stream.ToArray();

                    var lectureFile = new LectureFile
                    {
                        LectureID = lectureId,
                        FileName = file.FileName,
                        FileData = fileBytes,
                        Description = lectureFileDto.Description,
                    };

                    _context.LectureFiles.Add(lectureFile);
                }
            }
        }

        await _context.SaveChangesAsync();
    }

    public async Task UploadSectionFilesAsync(long sectionId, SectionFileAddDto sectionFileDto, IEnumerable<IFormFile> files)
    {
        var section = await _context.Sections.FindAsync(sectionId);
        if (section == null)
        {
            throw new ArgumentException("Section not found.");
        }

        foreach (var file in files)
        {
            if (file.Length > 0)
            {
                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    var fileBytes = stream.ToArray();

                    var sectionFile = new SectionFile
                    {
                        SectionID = sectionId,
                        FileName = file.FileName,
                        FileData = fileBytes,
                        Description = sectionFileDto.Description,
                    };

                    _context.SectionFiles.Add(sectionFile);
                }
            }
        }

        await _context.SaveChangesAsync();
    }

    public async Task<LectureFileDownloadDto> DownloadLectureFileAsync(long lectureFileId)
    {
        var lectureFile = await _context.LectureFiles.FindAsync(lectureFileId);
        if (lectureFile == null)
        {
            throw new FileNotFoundException("Lecture file not found.");
        }

        var lectureFileDto = new LectureFileDownloadDto()
        {
            FileName = lectureFile.FileName,
            FileData = lectureFile.FileData
        };
        return lectureFileDto;//TODO 
    }

    public async Task<SectionFileDownloadDto> DownloadSectionFileAsync(long sectionFileId)
    {
        var sectionFile = await _context.SectionFiles.FindAsync(sectionFileId);
        if (sectionFile == null)
        {
            throw new FileNotFoundException("Section file not found.");
        }

        var sectionFileDto = new SectionFileDownloadDto()
        {
            FileData = sectionFile.FileData,
            FileName = sectionFile.FileName
        };
        return sectionFileDto; //TODO 
    }

    public async Task<bool> DeleteLectureFileAsync(long lectureFileId)
    {
        var lectureFile = await _context.LectureFiles.FindAsync(lectureFileId);
        if (lectureFile == null)
        {
            return false;
        }

        _context.LectureFiles.Remove(lectureFile);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteSectionFileAsync(long sectionFileId)
    {
        var sectionFile = await _context.SectionFiles.FindAsync(sectionFileId);
        if (sectionFile == null)
        {
            return false;
        }

        _context.SectionFiles.Remove(sectionFile);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<LectureFileReadDto>> ListLectureFilesAsync(long lectureId)
    {
        return await _context.LectureFiles
            .Where(lf => lf.LectureID == lectureId).Select(lf => new LectureFileReadDto()
            {
                Id = lf.Id,
                FileName = lf.FileName,
                Description = lf.Description,
            })
            .ToListAsync();
    }

    public async Task<List<SectionFileReadDto>> ListSectionFilesAsync(long sectionId)
    {
        return await _context.SectionFiles
            .Where(sf => sf.SectionID == sectionId).Select( sf => new SectionFileReadDto
            {
                Id = sf.Id,
                FileName = sf.FileName,
                Description = sf.Description,
            })
            .ToListAsync();
    }
    
    ///////
//     public async Task<List<string>> UploadFilesAsync(IEnumerable<IFormFile> files)
//     {
//         var fileUrls = new List<string>();
//
//         foreach (var file in files)
//         {
//             var filePath = Path.Combine("uploads", file.FileName);
//             using (var stream = new FileStream(filePath, FileMode.Create))
//             {
//                 await file.CopyToAsync(stream);
//             }
//             fileUrls.Add(filePath);
//         }
//
//         return fileUrls;
//     }
//
//     public Task DeleteFileAsync(string fileUrl)
//     {
//         if (File.Exists(fileUrl))
//         {
//             File.Delete(fileUrl);
//         }
//         return Task.CompletedTask;
//     }
// }
}
