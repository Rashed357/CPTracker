using CPTracker.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CPTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContestsController : ControllerBase
{
    private readonly CPTrackerDbContext _dbContext;

    public ContestsController(CPTrackerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult<List<Contest>>> GetContests()
    {
        var contests = await _dbContext.Contests.Include(c => c.Problems).ToListAsync();
        return Ok(contests);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Contest>> GetContest(int id)
    {
        var contest = await _dbContext.Contests.Include(c => c.Problems).FirstOrDefaultAsync(c => c.Id == id);
        if (contest == null) return NotFound();
        return Ok(contest);
    }

    [HttpPost]
    public async Task<ActionResult<Contest>> CreateContest(Contest contest)
    {
        _dbContext.Contests.Add(contest);
        await _dbContext.SaveChangesAsync();
        return CreatedAtAction(nameof(GetContest), new { id = contest.Id }, contest);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContest(int id)
    {
        var contest = await _dbContext.Contests.FindAsync(id);
        if (contest == null) return NotFound();
        _dbContext.Contests.Remove(contest);
        await _dbContext.SaveChangesAsync();
        return NoContent();
    }
}