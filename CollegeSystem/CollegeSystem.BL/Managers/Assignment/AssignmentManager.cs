using CollegeSystem.BL.Enums;
using CollegeSystem.BL.Utilities;
using CollegeSystem.DAL.Models;
using CollegeSystem.DAL.UnitOfWork;
using FCISystem.DAL;
using Microsoft.AspNetCore.Http;

namespace CollegeSystem.DL;

public class AssignmentManager : IAssignmentManager
{
    private readonly UserUtility _userUtility;
    private readonly IUnitOfWork _unitOfWork;


    public AssignmentManager(
                            IUnitOfWork unitOfWork, 
                            UserUtility userUtility)
    {
        _unitOfWork = unitOfWork;
        _userUtility = userUtility;
    }
    
    // public void UpdateAssignmentAsync(int courseId, IFormFile file, DateTime deadline)
    // {
    //     var fileModel = _assignmentFileRepo.GetById(courseId);
    //     // var assignment = _assignmentRepo.GetById(courseId);
    //     if (fileModel == null ) //|| assignment == null
    //         throw new InvalidDataException("File Not Found");
    //     fileModel.Name  = file.FileName;
    //     fileModel.Extension = file.ContentType;
    //     fileModel.CreatedAt= DateTime.Now;
    //     fileModel.Deadline = deadline;
    //     using (var ms = new MemoryStream()) 
    //     {
    //         file.CopyToAsync(ms);
    //         fileModel.Content = ms.ToArray();
    //     }
    //     
    //     _assignmentFileRepo.Update(fileModel);
    //     _unitOfWork.CompleteAsync();
    // }

    

    public void DeleteAssignment(int id)
    {
        var fileModel = _unitOfWork.Assignment.GetById(id);
        if (fileModel == null)
            throw new InvalidDataException("File Not Found");
        _unitOfWork.Assignment.Delete(fileModel);
        _unitOfWork.CompleteAsync();
    }

    public AssignmentReadDto GetAssignment(int id)
    {
        var fileModel = _unitOfWork.AssignmentFile.GetById(id);
        var assignment = _unitOfWork.Assignment.GetById(id);
        if (fileModel == null || assignment == null)
            throw new InvalidDataException("File Not Found");
        return new AssignmentReadDto()
        {
            Id = fileModel.Id,
            // FileName = fileModel.Name,
            // FileContent = fileModel.Content,
            // FileExtension = fileModel.Extension,
            CreatedAt =assignment.CreatedAt,
            Deadline = assignment.Deadline
        };
    }
    
    public List<AssignmentReadAllDto>? GetAllSectionAssignments(long groupId)
    {
        var assignments = _unitOfWork.Assignment.GetAll()
            .Where(x=>x.Type==AssignmentType.section && groupId == x.GroupId);
        
        var file= assignments?.Select(x => new AssignmentReadAllDto()
        {
           Id = x.AssignmentId,
           Title = x.Title,
           Description = x.Description,
           CreatedAt = x.CreatedAt,
           Deadline = x.Deadline
        }).ToList();
        
        return null;
    }
    
    public List<AssignmentReadAllDto>? GetAllLectureAssignments(long groupId)
    {
        var assignments = _unitOfWork.Assignment.GetAll()
            .Where(x=>x.Type==AssignmentType.lecture && groupId == x.GroupId);

        // var fileModel = _assignmentFileRepo.GetAllLectureAssignments();
        return assignments?.Select(x => new AssignmentReadAllDto()
        {
            Id = x.AssignmentId,
            Title = x.Title,
            Description = x.Description,
            Deadline = x.Deadline,
            CreatedAt = x.CreatedAt,
            IsSubmitted = x.IsSubmitted,
            
        }).ToList();

        return null;
    }


    // public List<AssignmentReadDto>? GetAllCourseAssignments(long courseId)
    // {
    //     var assignments = _assignmentRepo.GetAllCourseAssignments(courseId);
    //
    //     return assignments?.Where(s => s.GroupId == courseId).Select(x => new AssignmentReadDto()
    //     {
    //         GroupId = x.AssignmentId,
    //         Title = x.Title,
    //         Description = x.Description,
    //         Deadline = x.Deadline,
    //         CreatedAt = x.CreatedAt
    //
    //     }).ToList();
    // }

    /////////////////////
   
   public async Task<IEnumerable<AssignmentReadDto>?> GetAssignmentsByCourseAsync(long courseId)
        {
            var assignments = await _unitOfWork.Assignment.GetAssignmentsByCourseAsync(courseId);

            return assignments?.Select(x => new AssignmentReadDto
            {
                Id = x.AssignmentId,
                Title = x.Title,
                Description = x.Description,
                Deadline = x.Deadline,
                CreatedAt = x.CreatedAt,
                IsSubmitted = x.IsSubmitted,
            }).ToList();
        }

        public async Task<AssignmentReadDto> GetAssignmentByIdAsync(long assignmentId)
        {
            var assignment = await _unitOfWork.Assignment.GetAssignmentByIdAsync(assignmentId);

            return new AssignmentReadDto
            {
                Id = assignment.AssignmentId,
                Title = assignment.Title,
                Description = assignment.Description,
                Deadline = assignment.Deadline,
                CreatedAt = assignment.CreatedAt,
                IsSubmitted = assignment.IsSubmitted,
                FileName = assignment.AssignmentFiles.FirstOrDefault()?.Name ?? string.Empty,
                FileExtension = assignment.AssignmentFiles.FirstOrDefault()?.Extension ?? string.Empty,
                FileContent = assignment.AssignmentFiles.FirstOrDefault()?.Content ?? Array.Empty<byte>()
            };
        }

        public async Task AddAssignmentAsync(AssignmentAddDto assignment)
        {
            if (assignment.Files != null)
            {
                var assignmentModel = new Assignment
                {
                    Title = assignment.Title,
                    Description = assignment.Description,
                    // GroupId = assignment.GroupId,
                    GroupId = assignment.GroupId,
                    Deadline = assignment.Deadline,
                    CreatedAt = DateTime.Now,
                    IsSubmitted = false,
                    
                    AssignmentFiles = assignment.Files.Select(x =>
                    {
                        using var memoryStream = new MemoryStream();
                        x.CopyTo(memoryStream);
                        return new AssignmentFile
                        {
                            Name = x.FileName,
                            Extension = Path.GetExtension(x.FileName),
                            Content = memoryStream.ToArray()
                        };
                    }).ToList()
                };
                await _unitOfWork.Assignment.AddAssignmentAsync(assignmentModel);
            }
        }

        public async Task UpdateAssignmentAsync(AssignmentUpdateDto assignment)
        {
            var assignmentModel = new Assignment
            {
                AssignmentId = assignment.AssignmentId,
                Title = assignment.Title,
                Description = assignment.Description,
                
                AssignmentFiles = new List<AssignmentFile>
                {
                    new AssignmentFile
                    {
                        Name = assignment.FileName,
                        Extension = assignment.FileExtension,
                        Content = assignment.FileContent
                    }
                }
            };
            await _unitOfWork.Assignment.UpdateAssignmentAsync(assignmentModel);
        }

        public async Task DeleteAssignmentAsync(long assignmentId)
        {
            await _unitOfWork.Assignment.DeleteAssignmentAsync(assignmentId);
        }

        public async Task SubmitAssignmentAnswerAsync(IFormFile answer, long assignmentId, long studentId)
        {
            using var memoryStream = new MemoryStream();
            await answer.CopyToAsync(memoryStream);
            var answerModel = new AssignmentAnswer
            {
                AssignmentId = assignmentId,
                StudentId = studentId, // Assuming this property exists
                FileName = answer.FileName,
                FileExtension = answer.ContentType,
                FileContent = memoryStream.ToArray()
            };
            await _unitOfWork.Assignment.SubmitAssignmentAnswerAsync(answerModel);
        }

        public Task<IEnumerable<AssignmentFileReadDto>?> GetAssignmentFilesAsync(long assignmentId)
        {
            var assignment=  _unitOfWork.Assignment.GetAssignmentFilesAsync(assignmentId);
            return Task.FromResult<IEnumerable<AssignmentFileReadDto>?>(assignment?.Result.Select(x => new AssignmentFileReadDto
            {
                Id = x.Id,
                FileName = x.Name,
                FileExtension = x.Extension,
            }).ToList());
        }
}
