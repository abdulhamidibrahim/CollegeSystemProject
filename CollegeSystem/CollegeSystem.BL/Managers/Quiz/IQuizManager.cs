namespace CollegeSystem.DL;

public interface IQuizManager
{
    public void Add(QuizAddDto quizAddDto);
    public void Update(QuizUpdateDto quizUpdateDto);
    public void Delete(QuizDeleteDto quizDeleteDto);
    public QuizReadDto? Get(long id);
    public List<QuizReadDto> GetAll(long courseId);
    public List<QuizReadDto> GetAllSectionQuizzes(long courseId);
    public List<QuizReadDto> GetAllLectureQuizzes(long courseId);
    public QuizReadDto? GetByLectureId(long lectureId);
    public QuizReadDto? GetBySectionId(long sectionId);
    
    public void AddSectionQuiz(AddSectionQuizDto quizAddDto);
    public void AddLectureQuiz(AddLectureQuizDto quizAddDto);

}