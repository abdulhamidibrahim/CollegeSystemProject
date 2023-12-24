using CollegeSystem.DAL.Models;
using FCISystem.DAL;

namespace CollegeSystem.DL;

public class AllQuizManager : IAllQuizManager
{
    private readonly IAllQuizRepo _allQuizRepo;

    public AllQuizManager(IAllQuizRepo allQuizRepo)
    {
        _allQuizRepo = allQuizRepo;
    }

    public void Add(AllQuizAddDto allQuizAddDto)
    {
        var user = new AllQuiz()
        {
            Name = allQuizAddDto.Name,
            Instructor = allQuizAddDto.Instructor,
            MaxDegree = allQuizAddDto.MaxDegree,
           MaxTime = allQuizAddDto.MaxTime,

        };
        _allQuizRepo.Add(user);
    }

    public void Update(AllQuizUpdateDto allQuizUpdateDto)
    {
        var user = _allQuizRepo.GetById(allQuizUpdateDto.Id);
        if (user == null) return;
        user.Name = allQuizUpdateDto.Name;
        user.Instructor = allQuizUpdateDto.Instructor;
        user.MaxTime = allQuizUpdateDto.MaxTime;
        user.MaxDegree = allQuizUpdateDto.MaxDegree;


        _allQuizRepo.Update(user);
    }

    public void Delete(AllQuizDeleteDto allQuizDeleteDto)
    {
        var user = _allQuizRepo.GetById(allQuizDeleteDto.Id);
        if (user == null) return;
        _allQuizRepo.Delete(user);
    }

    public AllQuizReadDto? Get(long id)
    {
        var user = _allQuizRepo.GetById(id);
        if (user == null) return null;
        return new AllQuizReadDto()
        {
            Name = user.Name,
            Instructor = user.Instructor,
            MaxDegree = user.MaxDegree,
            MaxTime = user.MaxTime,


        };
    }

    public List<AllQuizReadDto> GetAll()
    {
        var user = _allQuizRepo.GetAll();
        return user.Select(user => new AllQuizReadDto()
        {
            Name = user.Name,
            Instructor = user.Instructor,
            MaxDegree = user.MaxDegree,
            MaxTime = user.MaxTime,

        }).ToList();
    }


}

