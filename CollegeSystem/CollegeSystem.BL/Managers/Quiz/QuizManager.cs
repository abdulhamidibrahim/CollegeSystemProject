using CollegeSystem.DAL.Models;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class QuizManager:IQuizManager
{
    private readonly IQuizRepo _quizRepo;

    public QuizManager(IQuizRepo quizRepo)
    {
        _quizRepo = quizRepo;
    }
    
    public void Add(QuizAddDto quizAddDto)
    {
        var quiz = new Quiz()
        {
            Name = quizAddDto.Name,
            Instructor = quizAddDto.Instructor,
            MaxDegree = quizAddDto.MaxDegree,
            MaxTime = quizAddDto.MaxTime,
            LectureId = quizAddDto.LectureId,
            SectionId = quizAddDto.SectionId,
            CourseId = quizAddDto.CourseId,
        };
        _quizRepo.Add(quiz);
    }

    public void Update(QuizUpdateDto quizUpdateDto)
    {
        var quiz = _quizRepo.GetById(quizUpdateDto.QuizId);
        if (quiz == null) return;
        quiz.Name = quizUpdateDto.Name;
        quiz.Instructor = quizUpdateDto.Instructor;
        quiz.MaxDegree = quizUpdateDto.MaxDegree;
        quiz.MaxTime = quizUpdateDto.MaxTime;
        quiz.SectionId = quizUpdateDto.SectionId;
        quiz.LectureId = quizUpdateDto.LectureId;
        quiz.CourseId = quizUpdateDto.CourseId;
        quiz.QuizId = quizUpdateDto.QuizId;        

        _quizRepo.Update(quiz);
    }

    public void Delete(QuizDeleteDto quizDeleteDto)
    {
        var quiz = _quizRepo.GetById(quizDeleteDto.Id);
        if (quiz == null) return;
        _quizRepo.Delete(quiz);
    }

    public QuizReadDto? Get(long id)
    {
        var quiz = _quizRepo.GetById(id);
        if (quiz == null) return null;
        return new QuizReadDto()
        {
            Name = quiz.Name,
            Instructor = quiz.Instructor,
            MaxDegree = quiz.MaxDegree,
            MaxTime = quiz.MaxTime,
            CourseId = quiz.CourseId,
            SectionId = quiz.SectionId,
            LectureId = quiz.LectureId,
        };
    }

    public List<QuizReadDto> GetAll(long courseId)
    {
        var quizs = _quizRepo.GetAll(courseId);
        return quizs.Select(quiz => new QuizReadDto()
        {
            Name = quiz.Name,
            Instructor = quiz.Instructor,
            MaxDegree = quiz.MaxDegree,
            MaxTime = quiz.MaxTime,
            CourseId = quiz.CourseId,
            SectionId = quiz.SectionId,
            LectureId = quiz.LectureId,
        }).ToList();
    }
    
    public QuizReadDto? GetByLectureId(long lectureId)
    {
        var quiz = _quizRepo.GetByLectureId(lectureId);
        if (quiz == null) return null;
        return new QuizReadDto()
        {
            Name = quiz.Name,
            Instructor = quiz.Instructor,
            MaxDegree = quiz.MaxDegree,
            MaxTime = quiz.MaxTime,
            CourseId = quiz.CourseId,
            SectionId = quiz.SectionId,
            LectureId = quiz.LectureId,
        };
    }
    
    public QuizReadDto? GetBySectionId(long sectionId)
    {
        var quiz = _quizRepo.GetBySectionId(sectionId);
        if (quiz == null) return null;
        return new QuizReadDto()
        {
            Name = quiz.Name,
            Instructor = quiz.Instructor,
            MaxDegree = quiz.MaxDegree,
            MaxTime = quiz.MaxTime,
            CourseId = quiz.CourseId,
            SectionId = quiz.SectionId,
            LectureId = quiz.LectureId,
        };
    }

    public void AddSectionQuiz(AddSectionQuizDto quizAddDto)
    {
        var quiz = new Quiz()
        {
            Name = quizAddDto.Name,
            Instructor = quizAddDto.Instructor,
            MaxDegree = quizAddDto.MaxDegree,
            MaxTime = quizAddDto.MaxTime,
            SectionId = quizAddDto.SectionId,
            CourseId = quizAddDto.CourseId,
        };
        _quizRepo.Add(quiz);
    }

    public void AddLectureQuiz(AddLectureQuizDto quizAddDto)
    {
        var quiz = new Quiz()
        {
            Name = quizAddDto.Name,
            Instructor = quizAddDto.Instructor,
            MaxDegree = quizAddDto.MaxDegree,
            MaxTime = quizAddDto.MaxTime,
            LectureId = quizAddDto.LectureId,
            CourseId = quizAddDto.CourseId,
        };
        _quizRepo.Add(quiz);
    }

    public List<QuizReadDto> GetAllSectionQuizzes(long courseId)
    {
        var quizzes = _quizRepo.GetAllSectionQuizzes(courseId);
        return quizzes!.Select(quiz => new QuizReadDto()
        {
            Name = quiz.Name,
            Instructor = quiz.Instructor,
            MaxDegree = quiz.MaxDegree,
            MaxTime = quiz.MaxTime,
            CourseId = quiz.CourseId,
            SectionId = quiz.SectionId,
            LectureId = quiz.LectureId,
        }).ToList();
    }
    
    public List<QuizReadDto> GetAllLectureQuizzes(long courseId)
    {
        var quizs = _quizRepo.GetAllLectureQuizzes(courseId);
        return quizs.Select(quiz => new QuizReadDto()
        {
            Name = quiz.Name,
            Instructor = quiz.Instructor,
            MaxDegree = quiz.MaxDegree,
            MaxTime = quiz.MaxTime,
            CourseId = quiz.CourseId,
            SectionId = quiz.SectionId,
            LectureId = quiz.LectureId,
        }).ToList();
    }
    
    
}