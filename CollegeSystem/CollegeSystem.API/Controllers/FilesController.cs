// using CollegeSystem.BL.Managers.File;
// using CollegeSystem.DL;
// using FileUploadingWebAPI.Filter;
// using Microsoft.AspNetCore.Mvc;
//
// namespace CollegeSystem.API.Controllers;
//
// [ApiController]
// public class FileController : ControllerBase
// {
//     private readonly IFileManager _fileManager;
//
//     public FileController(IFileManager fileManager)
//     {
//         _fileManager = fileManager;
//     }
//
//     [HttpPost]
//     public IActionResult Upload(IFormFile file)
//     {
//         if (file == null || file.Length == 0)
//             return Content("file not selected");
//
//         var fileModel = new FileAddDto()
//         {
//             Name = file.FileName
//         };
//
//         using (var ms = new MemoryStream())
//         {
//             file.CopyTo(ms);
//             fileModel.Content = ms.ToArray();
//         }
//
//         _fileManager.Add(fileModel);
//         _fileManager.SaveChanges();
//
//         return Ok(new { fileModel.Id });
//     }
//
//     [HttpGet("{id}")]
//     public IActionResult Download(int id)
//     {
//         var fileModel = _fileManager.Files.FirstOrDefault(e => e.Id == id);
//         if (fileModel == null)
//             return NotFound();
//
//         return File(fileModel.FileContent, "application/octet-stream", fileModel.FileName);
//     }
//
//     [HttpGet]
//     public IActionResult List()
//     {
//         var fileModels = _fileManager.Files.Select(x => x.FileName);
//         return Ok(fileModels);
//     }
//
//     [HttpDelete("{id}")]
//     public IActionResult Delete(int id)
//     {
//         var fileModel = _fileManager.Files.FirstOrDefault(e => e.Id == id);
//         if (fileModel == null)
//             return NotFound();
//
//         _fileManager.Files.Remove(fileModel);
//         _fileManager.SaveChanges();
//
//         return Ok();
//     }
//
//     [HttpPut("{id}")]
//     public IActionResult Update(int id, IFormFile file)
//     {
//         var fileModel = _fileManager.Files.FirstOrDefault(e => e.Id == id);
//         if (fileModel == null)
//             return NotFound();
//         fileModel.FileName = file.FileName;
//         using (var ms = new MemoryStream()) 
//         {
//             file.CopyTo(ms);
//             fileModel.FileContent = ms.ToArray();
//         }
//
//         _fileManager.SaveChanges();
//
//         return Ok();
//     }
//
//     [HttpPost]
//     [ImageValidator]
//     public IActionResult UploadImage(IFormFile iamge)
//     {
//         var fileModel = new FileModel
//         {
//             FileName = iamge.FileName
//         };
//
//         using (var ms = new MemoryStream())
//         {
//             iamge.CopyTo(ms);
//             fileModel.FileContent = ms.ToArray();
//         }
//
//         _fileManager.Files.Add(fileModel);
//         _fileManager.SaveChanges();
//
//         return Ok(new { fileModel.Id });
//     }
//
//     [HttpPost]
//     public IActionResult UploadMultibleFiles(List<IFormFile> files)
//     {
//         if (files == null || files.Count == 0)
//             return Content("files not selected");
//
//         foreach (var file in files)
//         {
//             var fileModel = new FileModel
//             {
//                 FileName = file.FileName
//             };
//
//             using (var ms = new MemoryStream())
//             {
//                 file.CopyTo(ms);
//                 fileModel.FileContent = ms.ToArray();
//             }
//             _fileManager.Files.Add(fileModel);
//         }
//         _fileManager.SaveChanges();
//
//         return Ok();
//     }
// }
//
// }