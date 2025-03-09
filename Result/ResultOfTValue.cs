using System.Diagnostics.CodeAnalysis;

namespace Result;

public sealed class Result<TValue>
{
    public Error? Error { get; }
    public TValue? Value { get; }
    
    [MemberNotNullWhen(false, nameof(Error))]
    [MemberNotNullWhen(true, nameof(Value))]
    public bool IsSuccess => Error == null;

    internal Result(Error error)
    {
        Error = error;
        Value = default;
    }

    internal Result(TValue value)
    {
        Error = null;
        Value = value;
    }
    
    public TValue EnsureValue()
    {
        if (!IsSuccess)
        {
            throw new InvalidOperationException("Result is not success");
        }
        
        return Value;
    }
    
    public static implicit operator Result<TValue>(Error error)
        => new(error);
    
    public static implicit operator Result<TValue>(TValue value)
        => new(value);
}