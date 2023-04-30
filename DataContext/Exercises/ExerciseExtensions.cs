using EntityModels.Postgresql;

namespace DataContext.Exercises;

public static class ExerciseExtensions
{
    public static ExerciseModel MapToModel(this Exercise exercise) =>
        new()
        {
            Id = exercise.Id,
            Title = exercise.Title,
            AuthorId = exercise.AuthorId,
            ShortDescription = exercise.ShortDescription,
            FullDescription = exercise.FullDescription,
            CreatedAt = exercise.CreatedAt,
            CodeExample = exercise.CodeExample,
        };

    public static IEnumerable<ExerciseModel> MapToModels(this IEnumerable<Exercise> exercises) =>
        exercises.Select(exercise => exercise.MapToModel());
}