using DataContext.Exercises;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BornToCodeWebApp.Controllers;

[ApiController]
[Route("[controller]/[action]")]
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
    public async Task<List<ExerciseModel>> GetExercises()
    {
        var exerciseModels = await _exercisesRepository.GetAll().ToListAsync();
        _logger.LogInformation("Got {ExerciseModelsCount} ExerciseModels", exerciseModels.Count);
        return exerciseModels;
    }

    [HttpPost]
    public async Task<ActionResult> PostNewExercise(CreateExerciseModel newExercise)
    {
        var exerciseModel = await _exercisesRepository.AddNewExerciseAsync(newExercise);
        _logger.LogInformation("Created new exercise with title \"{ExerciseModel}\"!", exerciseModel.Title);
        return Created($"{exerciseModel.Id}", exerciseModel);
    }
}