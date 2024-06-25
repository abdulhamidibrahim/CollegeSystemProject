using CollegeSystem.DL;
using FCISystem.DAL;
using Microsoft.AspNetCore.Http;
using static CollegeSystem.DAL.Models.File;

namespace CollegeSystem.BL.Managers.File;

public class FileManager : IFileManager
{
    private readonly IFileRepo _fileRepo;
    
    public FileManager(IFileRepo fileRepo)
    {
        _fileRepo = fileRepo;
    }
    // public Task UploadAsync(IFormFile file)
    // {
    //     throw new NotImplementedException();
    //
    // }
    //
    // public Task DownloadAsync(string filePath, string fileName)
    // {
    //     throw new NotImplementedException();
    // }
}