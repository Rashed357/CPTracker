using CPTracker.Domain;

var problem = new Problem
{
    Id = 1,
    Name = "Watermelon",
    PlatformProblemId = "4A",
    Rating = 800,
    Url = "https://codeforces.com/problemset/problem/4/A",
    SolvedAt = new DateTime(2024, 3, 15)
};

var submission = new Submission
{
    Id = 1,
    ProblemId = problem.Id,
    Problem = problem,
    Verdict = SubmissionVerdict.Accepted,
    SubmittedAt = DateTime.Now
};

Console.WriteLine($"Submission for problem: {submission.Problem.Name}");
Console.WriteLine($"Verdict: {submission.Verdict}");
Console.WriteLine($"Problem rating: {submission.Problem.Rating}");