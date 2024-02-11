namespace CollegeSystem.DL;

public interface IAnswerManager
{
    public void Add(AnswerAddDto answerAddDto);
    public void Update(AnswerUpdateDto answerUpdateDto);
    public void Delete(AnswerDeleteDto answerDeleteDto);
    public AnswerReadDto? Get(long id);
    public List<AnswerReadDto> GetAll();
    public List<AnswerReadDto> GetAllQuizAnswers(long quizId);
    public List<AnswerReadDto> GetAllStudentAnswers(long studentId);
    
}
