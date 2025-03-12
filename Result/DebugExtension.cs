namespace Result;

public static class DebugExtension
{
    public static Result DebugIfOk(this Result result, Action action)
    {
        if (!result.IsSuccess)
        {
            return result;
        }
        
        action.Invoke();
        return result;
    }
    
    public static Result DebugIfError(this Result result, Action<Error> action)
    {
        if (!result.IsSuccess)
        {
            action.Invoke(result.Error);
            return result;
        }
        
        return result;
    }
    
    public static Result<TValue> DebugIfOk<TValue>(this Result<TValue> result, Action<TValue> action)
    {
        if (!result.IsSuccess)
        {
            return result;
        }
        
        action.Invoke(result.Value);
        return result;
    }
    
    public static Result<TValue> DebugIfError<TValue>(this Result<TValue> result, Action<Error> action)
    {
        if (!result.IsSuccess)
        {
            action.Invoke(result.Error);
            return result;
        }
        
        return result;
    }
}