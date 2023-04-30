using DataContext.Solutions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace BornToCodeWebApp.Controllers;

[ApiController]
[Route("/api/[controller]")]
[Produces("application/json")]
public class SolutionController : ControllerBase
{
    private readonly ISolutionsRepository _solutionsRepository;
    private readonly ILogger<SolutionController> _logger;

    public SolutionController(ISolutionsRepository solutionsRepository, ILogger<SolutionController> logger)
    {
        _solutionsRepository = solutionsRepository;
        _logger = logger;
    }

    [HttpGet]
    [SwaggerResponse(200, "solutionModel", typeof(List<SolutionModel>))]
    [SwaggerResponse(400, "use authorid={int} or exerciseid={int}")]
    public async Task<Results<Ok<List<SolutionModel>>, BadRequest>> GetSolutionsBy(int? authorId, int? exerciseId)
    {
        List<SolutionModel> solutionModels;

        if (authorId.HasValue)
        {
            solutionModels = await _solutionsRepository.FindByAuthorIdAsync(authorId.Value).ToListAsync();
            _logger.LogInformation("Got {SolutionModelsCount} SolutionModels for author {AuthorId}",
                solutionModels.Count, authorId);
        }
        else if (exerciseId.HasValue)
        {
            solutionModels = await _solutionsRepository.FindByExerciseIdAsync(exerciseId.Value).ToListAsync();
            _logger.LogInformation("Got {SolutionModelsCount} SolutionModels for exercise {ExerciseId}",
                solutionModels.Count, exerciseId);
        }
        else
            return TypedResults.BadRequest();

        return TypedResults.Ok(solutionModels);
    }

    [HttpPost]
    [SwaggerResponse(200, "solutionModel", typeof(SolutionModel))]
    [SwaggerResponse(400, type: typeof(CreateSolutionModel))]
    public async Task<Results<Created<SolutionModel>, BadRequest>> PostNewSolution(CreateSolutionModel newSolution)
    {
        var solutionModel = await _solutionsRepository.AddNewSolutionAsync(newSolution);

        if (solutionModel == null)
        {
            _logger.LogInformation("Error at creating new solution from AuthorId \"{AuthorId}\"", newSolution.AuthorId);
            return TypedResults.BadRequest();
        }

        _logger.LogInformation("Created new solution with id \"{SolutionId}\" for exercise {SolutionExerciseId}!",
            solutionModel.Id,
            solutionModel.ExerciseId);
        return TypedResults.Created($"{solutionModel.Id}", solutionModel);
    }
}