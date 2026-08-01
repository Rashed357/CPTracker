using CPTracker.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CPTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubmissionsController : ControllerBase
{
    private readonly CPTrackerDbContext _dbContext;

    public SubmissionsController(CPTrackerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult<List<Submission>>> GetSubmissions()
    {
        var submissions = await _dbContext.Submissions.Include(s => s.Problem).ToListAsync();
        return Ok(submissions);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Submission>> GetSubmission(int id)
    {
        var submission = await _dbContext.Submissions.Include(s => s.Problem).FirstOrDefaultAsync(s => s.Id == id);
        if (submission == null) return NotFound();
        return Ok(submission);
    }

    [HttpPost]
    public async Task<ActionResult<Submission>> CreateSubmission(Submission submission)
    {
        _dbContext.Submissions.Add(submission);
        await _dbContext.SaveChangesAsync();
        return CreatedAtAction(nameof(GetSubmission), new { id = submission.Id }, submission);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSubmission(int id)
    {
        var submission = await _dbContext.Submissions.FindAsync(id);
        if (submission == null) return NotFound();
        _dbContext.Submissions.Remove(submission);
        await _dbContext.SaveChangesAsync();
        return NoContent();
    }
}