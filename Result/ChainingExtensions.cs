namespace Result;

public static class ChainingExtensions
{
    public static Result Chain(this Result result, Func<Result> func)
    {
        if (!result.IsSuccess)
        {
            return result.Error;
        }
        
        return func.Invoke();
    }

    public static Result<TResult> Chain<TResult>(this Result result, Func<Result<TResult>> func)
    {
        if (!result.IsSuccess)
        {
            return result.Error;
        }
        
        return func.Invoke();
    }
    
    public static Result Chain(this Result result, Action action)
    {
        if (!result.IsSuccess)
        {
            return result.Error;
        }

        action.Invoke();
        return Results.Ok();
    }
    
    public static Result Chain<TValue>(this Result<TValue> result, Func<TValue, Result> func)
    {
        if (!result.IsSuccess)
        {
            return result.Error;
        }
        
        return func.Invoke(result.Value);
    }

    public static Result<TResult> Chain<TValue, TResult>(this Result<TValue> result, Func<TValue, Result<TResult>> func)
    {
        if (!result.IsSuccess)
        {
            return result.Error;
        }
        
        return func.Invoke(result.Value);
    }
    
    public static Result Chain<TValue>(this Result<TValue> result, Action<TValue> action)
    {
        if (!result.IsSuccess)
        {
            return result.Error;
        }
        
        action.Invoke(result.Value);
        return Results.Ok();
    }
}