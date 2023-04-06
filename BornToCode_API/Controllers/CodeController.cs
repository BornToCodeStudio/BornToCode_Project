using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace BornToCode_API.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class CodeController : ControllerBase
{
    private static string LastCodeFromUser = "<div>Тут ничего не было</div>";

    private readonly ILogger<CodeController> _logger;

    public CodeController(ILogger<CodeController> logger) => _logger = logger;

    [HttpGet(Name = "Get")]
    public JsonResult Get() => new(LastCodeFromUser);

    [HttpPost(Name = "Post")]
    public void Post([FromBody] JObject html) => LastCodeFromUser = html["html"]?.ToString() ?? "string.Empty";
}