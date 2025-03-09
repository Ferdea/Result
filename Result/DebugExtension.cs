namespace Result;

public static class DebugExtension
{
    public static Result DebugWrite(this Result result, TextWriter? writer = null)
    {
        writer ??= Console.Out;
        
        if (!result.IsSuccess)
        {
            writer.WriteLine($"Error: {result.Error.Message}");
            return result;
        }
        
        writer.WriteLine("Ok");
        return result;
    }
    
    public static Result<TValue> DebugWrite<TValue>(this Result<TValue> result, TextWriter? writer = null)
    {
        writer ??= Console.Out;
        
        if (!result.IsSuccess)
        {
            writer.WriteLine($"Error: {result.Error.Message}");
            return result;
        }
        
        writer.WriteLine($"Ok: \"{result.Value}\"");
        return result;
    }
    
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