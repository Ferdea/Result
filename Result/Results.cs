namespace Result;

public static class Results
{
    public static Result Error(Error error)
        => new(error);

    public static Result Error(IErrorCode errorCode, string? message = null, params Error[] details)
        => new Error(errorCode, message, details);
    
    public static Result Ok()
        => new(null);
    
    public static Result<TValue> Error<TValue>(Error error)
        => new(error);
    
    public static Result<TValue> Error<TValue>(IErrorCode errorCode, string? message = null, params Error[] details)
        => new Error(errorCode, message, details);
    
    public static Result<TValue> FromValue<TValue>(TValue value)
        => new(value);
    
    public static Result<TValue> FromFunc<TValue>(Func<TValue> func)
        => new(func.Invoke());
}