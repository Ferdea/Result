using System.Diagnostics.CodeAnalysis;

namespace Result;

public sealed class Result
{
    public Error? Error { get; }
    
    [MemberNotNullWhen(false, nameof(Error))]
    public bool IsSuccess => Error == null;
    
    internal Result(Error? error)
    {
        Error = error;
    }

    public void EnsureSuccess()
    {
        if (!IsSuccess)
        {
            throw new InvalidOperationException("Result is not success");
        }
    }
    
    public static implicit operator Result(Error error)
        => new(error);
}