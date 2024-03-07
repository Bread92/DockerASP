using Microsoft.AspNetCore.Mvc;

namespace DokerASP.Controllers;

[ApiController]
public class DunnoController : ControllerBase
{
    [HttpPost("{filename}/{content}")]
    public async Task<IActionResult> CreateFile([FromRoute] string filename, [FromRoute] string content)
    {
        const string outputDir = "/output";

        Directory.CreateDirectory(outputDir);
        
        await using (StreamWriter sw = new(Path.Combine(outputDir, filename)))
        {
            await sw.WriteLineAsync(content);
        }

        return Ok();
    }
}