using EntityModels.Postgresql;
using Microsoft.EntityFrameworkCore;

namespace DataContext.Exercises;

public class ExercisesRepository : IExercisesRepository
{
    private readonly BornToCodePostgresqlContext _db;

    public ExercisesRepository(BornToCodePostgresqlContext dc)
    {
        _db = dc;
    }

    public IQueryable<ExerciseModel> GetAll() =>
        _db.Exercises.Select(exercise => exercise.MapToModel());

    public async Task<ExerciseModel?> FindByIdAsync(int id) =>
        (await _db.Exercises.FirstOrDefaultAsync(t => t.Id == id))?.MapToModel();

    public async Task<ExerciseModel?> FindByNameAsync(string name) =>
        (await _db.Exercises.FirstOrDefaultAsync(t => t.Title == name))?.MapToModel();

    public async Task<ExerciseModel> AddNewExerciseAsync(CreateExerciseModel newExercise)
    {
        //  TODO: Exercise validation

        var exercise = new Exercise
        {
            Title = newExercise.Title,
            AuthorId = newExercise.AuthorId,
            ShortDescription = newExercise.ShortDescription,
            FullDescription = newExercise.FullDescription,
            CodeExample = newExercise.CodeExample,
        };

        await _db.Exercises.AddAsync(exercise);
        await _db.SaveChangesAsync();

        return exercise.MapToModel();
    }
}