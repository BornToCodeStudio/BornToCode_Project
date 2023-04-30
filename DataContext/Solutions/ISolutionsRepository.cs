namespace DataContext.Solutions;

public interface ISolutionsRepository
{
    public IQueryable<SolutionModel> FindByAuthorIdAsync(int id);
    public IQueryable<SolutionModel> FindByExerciseIdAsync(int id);
    
    public Task<SolutionModel?> FindByIdAsync(int id);
    public Task<SolutionModel?> AddNewSolutionAsync(CreateSolutionModel newSolution);
}