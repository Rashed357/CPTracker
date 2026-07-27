namespace CPTracker.Domain;

public class Problem
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string PlatformProblemId { get; set; } = string.Empty; // e.g. "1234A" on Codeforces
    public int Rating { get; set; } // e.g. 1500
    public string Url { get; set; } = string.Empty;
    public DateTime SolvedAt { get; set; }
}