namespace CPTracker.Domain;

public enum SubmissionVerdict
{
    Accepted,
    WrongAnswer,
    TimeLimitExceeded,
    RuntimeError,
    CompilationError
}