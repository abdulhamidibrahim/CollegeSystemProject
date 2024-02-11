﻿using CollegeSystem.DAL.Models;
using FCISystem.DAL;
using Microsoft.AspNetCore.Http;

namespace CollegeSystem.DL;

public class AssignmentManager : IAssignmentManager
{
    private readonly IAssignmentRepo _assignmentRepo;
    private readonly IAssignmentFileRepo _assignmentFileRepo;
    

    public AssignmentManager(IAssignmentRepo assignmentRepo, IAssignmentFileRepo assignmentFileRepo)
    {
        _assignmentRepo = assignmentRepo;
        _assignmentFileRepo = assignmentFileRepo;
    }
    
    public void UpdateAssignmentAsync(int id, IFormFile file, DateTime deadline)
    {
        var fileModel = _assignmentFileRepo.GetById(id);
        // var assignment = _assignmentRepo.GetById(id);
        if (fileModel == null ) //|| assignment == null
            throw new InvalidDataException("File Not Found");
        fileModel.Name  = file.FileName;
        fileModel.Extension = file.ContentType;
        fileModel.CreatedAt= DateTime.Now;
        fileModel.Deadline = deadline;
        using (var ms = new MemoryStream()) 
        {
            file.CopyToAsync(ms);
            fileModel.Content = ms.ToArray();
        }
        
        _assignmentFileRepo.Update(fileModel);
    }

    

    public void DeleteAssignment(int id)
    {
        var fileModel = _assignmentRepo.GetById(id);
        if (fileModel == null)
            throw new InvalidDataException("File Not Found");
        _assignmentRepo.Delete(fileModel);
    }

    public AssignmentReadDto GetAssignment(int id)
    {
        var fileModel = _assignmentFileRepo.GetById(id);
        var assignment = _assignmentRepo.GetById(id);
        if (fileModel == null || assignment == null)
            throw new InvalidDataException("File Not Found");
        return new AssignmentReadDto()
        {
            FileName = fileModel.Name,
            FileContent = fileModel.Content,
            FileExtension = fileModel.Extension,
            CreatedAt =assignment.CreatedAt,
            Deadline = assignment.Deadline
        };
    }
    
    public List<AssignmentReadDto>? GetAllSectionAssignments()
    {
        var assignments = _assignmentRepo.GetAll()
            .Where(x => x.SectionId != null);
        
        var file= assignments?.Select(x => new AssignmentReadDto()
        {
           AssignmentId = x.AssignmentId,
           Title = x.Title,
           Description = x.Description,
           CreatedAt = x.CreatedAt,
           Deadline = x.Deadline
        }).ToList();
        
        return null;
    }
    
    public List<AssignmentReadDto>? GetAllLectureAssignments()
    {
        var assignments = _assignmentRepo.GetAll().Where(x=>x.LectureId!=null);

        // var fileModel = _assignmentFileRepo.GetAllLectureAssignments();
        return assignments?.Select(x => new AssignmentReadDto()
        {
            AssignmentId = x.AssignmentId,
            Title = x.Title,
            Description = x.Description,
            Deadline = x.Deadline,
            CreatedAt = x.CreatedAt
        }).ToList();

        return null;
    }

    public void AddSectionAssignmentFileAsync(IFormFile file, long assignmentId)
    {
    var fileModel = new AssignmentFile()
    {
        Name = file.FileName,
        Extension = file.ContentType,
        AssignmentId = assignmentId,
    };

    using (var ms = new MemoryStream())
    {
        file.CopyToAsync(ms);
        fileModel.Content = ms.ToArray();
    }
    

    _assignmentFileRepo.Add(fileModel);
    }

    public void AddSectionAssignmentAsync( SectionAssignmentAddDto assignmentAddDto)
    {
        var assignment = new Assignment()
        {
            SectionId = assignmentAddDto.SectionId,
            Title = assignmentAddDto.Title,
            Description = assignmentAddDto.Description,
            Deadline = assignmentAddDto.Deadline,
            CreatedAt = DateTime.Now,
        };
    }

    public void AddLectureAssignmentFileAsync(IFormFile file, long assignmentId)
    {
    var fileModel = new AssignmentFile()
    {
        Name = file.FileName,
        Extension = file.ContentType,
        AssignmentId = assignmentId
    };

    using (var ms = new MemoryStream())
    {
        file.CopyToAsync(ms);
        fileModel.Content = ms.ToArray();
    }
    
    _assignmentFileRepo.Add(fileModel);
    }
    

    public void AddLectureAssignmentAsync(LectureAssignmentAddDto assignmentAddDto)
    {
        var assignment = new Assignment()
        {
            Title = assignmentAddDto.Title,
            Description = assignmentAddDto.Description,
            Deadline = assignmentAddDto.Deadline,
            LectureId = assignmentAddDto.LectureId
        };
    }

    public List<AssignmentReadDto>? GetAllCourseAssignments(long courseId)
    {
        var assignments = _assignmentRepo.GetAllCourseAssignments(courseId);
        
        return assignments?.Where(s=>s.CourseId == courseId).Select(x => new AssignmentReadDto()
        {
            AssignmentId = x.AssignmentId,
            Title = x.Title,
            Description = x.Description,
            Deadline = x.Deadline,
            CreatedAt = x.CreatedAt
            
        }).ToList();

        return null;
    }
}