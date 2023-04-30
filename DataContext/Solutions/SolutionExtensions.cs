using EntityModels.Postgresql;

namespace DataContext.Solutions;

public static class SolutionExtensions
{
    public static SolutionModel MapToModel(this Solution solution) =>
        new()
        {
            Id = solution.Id,
            ExerciseId = solution.ExerciseId,
            AuthorId = solution.AuthorId,

            CreatedAt = solution.CreatedAt,
            IsCurrent = solution.IsCurrent,
            VersionDescription = solution.VersionDescription,
            FromSolution = solution.FromSolution,

            Html = solution.Html,
            Css = solution.Css,
            Js = solution.Js,
        };

    public static IEnumerable<SolutionModel> MapToModels(this IEnumerable<Solution> solutions) =>
        solutions.Select(solution => solution.MapToModel());
}