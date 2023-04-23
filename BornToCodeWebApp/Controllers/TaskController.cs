using DataContext.Postgresql;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Task = EntityModels.Postgresql.Task;

namespace BornToCodeWebApp.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class TaskController : ControllerBase
{
    private BornToCodeContext _db;
    private readonly ILogger<TaskController> _logger;

    public TaskController(BornToCodeContext db, ILogger<TaskController> logger)
    {
        _db = db;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult GetTasks() => Ok(_db.Tasks.ToList());

    [HttpPost]
    public async void PostNewTask([FromBody] JObject taskObject)
    {
        try
        {
            var task = new Task
            {
                Title = taskObject["title"].ToString(),
                AuthorId = int.Parse(taskObject["authorId"].ToString()),
                ShortDescription = taskObject["shortDescription"].ToString(),
                FullDescription = taskObject["fullDescription"].ToString(),
                CreatedAt = DateTime.Parse(taskObject["createdAt"].ToString()),
                CodeExample = taskObject["codeExample"].ToString(),
            };
            await _db.Tasks.AddAsync(task);
            await _db.SaveChangesAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            _logger.LogError(taskObject.ToString());
            Console.WriteLine(e);
        }
    }
}