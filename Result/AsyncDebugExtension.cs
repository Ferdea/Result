namespace Result;

public static class AsyncDebugExtension
{
    public static async Task<Result> DebugIfOk(this Task<Result> resultTask, Action action)
    {
        var result = await resultTask;
        
        if (!result.IsSuccess)
        {
            return result;
        }
        
        action.Invoke();
        return result;
    }
    
    public static async Task<Result> DebugIfError(this Task<Result> resultTask, Action<Error> action)
    {
        var result = await resultTask;
        
        if (!result.IsSuccess)
        {
            action.Invoke(result.Error);
            return result;
        }
        
        return result;
    }
    
    public static async Task<Result<TValue>> DebugIfOk<TValue>(this Task<Result<TValue>> resultTask, Action<TValue> action)
    {
        var result = await resultTask;
        
        if (!result.IsSuccess)
        {
            return result;
        }
        
        action.Invoke(result.Value);
        return result;
    }
    
    public static async Task<Result<TValue>> DebugIfError<TValue>(this Task<Result<TValue>> resultTask, Action<Error> action)
    {
        var result = await resultTask;
        
        if (!result.IsSuccess)
        {
            action.Invoke(result.Error);
            return result;
        }
        
        return result;
    }
}