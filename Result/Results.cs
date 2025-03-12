namespace Result;

public static class Results
{
    public static Result Error(Error error)
        => new(error);

    public static Result Error<TErrorCode>(TErrorCode errorCode, string? message = null, params Error[] details)
        where TErrorCode : IErrorCode
        => new Error(errorCode, message, details);
    
    public static Result Ok()
        => new(null);
    
    public static Result<TValue> Error<TValue>(Error error)
        => new(error);
    
    public static Result<TValue> Error<TValue, TErrorCode>(TErrorCode errorCode, string? message = null, params Error[] details)
        where TErrorCode : IErrorCode
        => new Error(errorCode, message, details);
    
    public static Result<TValue> Ok<TValue>(TValue value)
        => new(value);
    
    public static Result<TValue> Ok<TValue>(Func<TValue> func)
        => new(func.Invoke());
}