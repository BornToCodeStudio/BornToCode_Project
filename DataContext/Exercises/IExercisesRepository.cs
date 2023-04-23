namespace DataContext.Exercises;

public interface IExercisesRepository
{
    public IQueryable<ExerciseModel> GetAll();
    public Task<ExerciseModel?> FindByIdAsync(int id);
    public Task<ExerciseModel?> FindByNameAsync(string name);
    public Task<ExerciseModel> AddNewExerciseAsync(CreateExerciseModel newExercise);
}