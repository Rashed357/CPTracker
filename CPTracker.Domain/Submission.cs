namespace CPTracker.Domain;

public class Submission
{
    public int Id { get; set; }
    public int ProblemId { get; set; }
    public Problem Problem { get; set; } = null!;
    public SubmissionVerdict Verdict { get; set; }
    public DateTime SubmittedAt { get; set; }
}