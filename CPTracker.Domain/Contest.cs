namespace CPTracker.Domain;

public class Contest
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Platform { get; set; } = string.Empty; // e.g. "Codeforces"
    public DateTime StartTime { get; set; }
    public List<Problem> Problems { get; set; } = new();
}