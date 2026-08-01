using CPTracker.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CPTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProblemsController : ControllerBase
{
    private readonly CPTrackerDbContext _dbContext;

    public ProblemsController(CPTrackerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult<List<Problem>>> GetProblems()
    {
        var problems = await _dbContext.Problems.ToListAsync();
        return Ok(problems);
    }

    [HttpPost]
public async Task<ActionResult<Problem>> CreateProblem(Problem problem)
{
    _dbContext.Problems.Add(problem);
    await _dbContext.SaveChangesAsync();

    return CreatedAtAction(nameof(GetProblem), new { id = problem.Id }, problem);
}

[HttpPut("{id}")]
public async Task<IActionResult> UpdateProblem(int id, Problem updatedProblem)
{
    var problem = await _dbContext.Problems.FindAsync(id);
    if (problem == null) return NotFound();

    problem.Name = updatedProblem.Name;
    problem.PlatformProblemId = updatedProblem.PlatformProblemId;
    problem.Rating = updatedProblem.Rating;
    problem.Url = updatedProblem.Url;
    problem.SolvedAt = updatedProblem.SolvedAt;

    await _dbContext.SaveChangesAsync();
    return NoContent();
}

[HttpDelete("{id}")]
public async Task<IActionResult> DeleteProblem(int id)
{
    var problem = await _dbContext.Problems.FindAsync(id);
    if (problem == null) return NotFound();

    _dbContext.Problems.Remove(problem);
    await _dbContext.SaveChangesAsync();
    return NoContent();
}

    [HttpGet("{id}")]
public async Task<ActionResult<Problem>> GetProblem(int id)
{
    var problem = await _dbContext.Problems.FindAsync(id);

    if (problem == null)
    {
        return NotFound();
    }

    return Ok(problem);
}
}