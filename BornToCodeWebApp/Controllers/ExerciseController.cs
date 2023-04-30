using DataContext.Exercises;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace BornToCodeWebApp.Controllers;

[ApiController]
[Route("/api/[controller]")]
[Produces("application/json")]
public class ExerciseController : ControllerBase
{
    private readonly IExercisesRepository _exercisesRepository;
    private readonly ILogger<ExerciseController> _logger;

    public ExerciseController(IExercisesRepository exercisesRepository, ILogger<ExerciseController> logger)
    {
        _exercisesRepository = exercisesRepository;
        _logger = logger;
    }

    [HttpGet]
    [SwaggerResponse(200, "exerciseModel", typeof(List<ExerciseModel>))]
    [SwaggerResponse(204, "no exercises")]
    public async Task<Results<Ok<List<ExerciseModel>>, NoContent>> GetExercises()
    {
        var exerciseModels = await _exercisesRepository.GetAll().ToListAsync();
        _logger.LogInformation("Got {ExerciseModelsCount} ExerciseModels", exerciseModels.Count);

        if (exerciseModels.Count > 0)
            return TypedResults.Ok(exerciseModels);

        return TypedResults.NoContent();
    }

    [HttpPost]
    [SwaggerResponse(200, "exerciseModel", typeof(ExerciseModel))]
    [SwaggerResponse(400, type: typeof(CreateExerciseModel))]
    public async Task<Results<Created<ExerciseModel>, BadRequest>> PostNewExercise(CreateExerciseModel newExercise)
    {
        var exerciseModel = await _exercisesRepository.AddNewExerciseAsync(newExercise);
        if (exerciseModel == null)
        {
            _logger.LogInformation("Error at creating new exercise from AuthorId \"{AuthorId}\"", newExercise.AuthorId);
            return TypedResults.BadRequest();
        }

        _logger.LogInformation("Created new exercise with title \"{ExerciseModel}\"!", exerciseModel.Title);
        return TypedResults.Created($"{exerciseModel.Id}", exerciseModel);
    }
}