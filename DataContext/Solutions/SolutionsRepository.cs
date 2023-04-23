using EntityModels.Postgresql;
using Microsoft.EntityFrameworkCore;

namespace DataContext.Solutions;

public class SolutionsRepository : ISolutionsRepository
{
    private readonly BornToCodePostgresqlContext _db;

    public SolutionsRepository(BornToCodePostgresqlContext dc)
    {
        _db = dc;
    }

    public IQueryable<SolutionModel> FindByAuthorIdAsync(int id) =>
        _db.Solutions
            .Where(solution => solution.AuthorId == id)
            .Select(solution => solution.MapToModel());

    public IQueryable<SolutionModel> FindByExerciseIdAsync(int id) =>
        _db.Solutions
            .Where(solution => solution.ExerciseId == id)
            .Select(solution => solution.MapToModel());

    public async Task<SolutionModel?> FindByIdAsync(int id) =>
        (await _db.Solutions.FirstOrDefaultAsync(t => t.Id == id))?.MapToModel();

    public async Task<SolutionModel?> AddNewSolutionAsync(CreateSolutionModel newSolution)
    {
        //  TODO: Solution validation
        

        var solution = new Solution
        {
            ExerciseId = newSolution.ExerciseId,
            AuthorId = newSolution.AuthorId,

            CreatedAt = newSolution.CreatedAt,
            IsCurrent = true,
            VersionDescription = newSolution.VersionDescription,
            FromSolution = newSolution.FromSolution,

            Html = newSolution.Html,
            Css = newSolution.Css,
            Js = newSolution.Js,
        };

        await _db.Solutions.AddAsync(solution);
        await _db.SaveChangesAsync();

        return solution.MapToModel();
    }
}