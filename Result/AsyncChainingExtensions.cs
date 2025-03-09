namespace Result;

public static class AsyncChainingExtensions
{
    public static async Task<Result> Chain(this Result result, Func<Task<Result>> func)
    {
        if (!result.IsSuccess)
        {
            return result.Error;
        }

        return await func.Invoke();
    }

    public static async Task<Result<TResult>> Chain<TResult>(this Result result, Func<Task<Result<TResult>>> func)
    {
        if (!result.IsSuccess)
        {
            return result.Error;
        }

        return await func.Invoke();
    }

    public static async Task<Result> Chain(this Task<Result> resultTask, Func<Task<Result>> func)
    {
        var result = await resultTask;
        
        if (!result.IsSuccess)
        {
            return result.Error;
        }

        return await func.Invoke();
    }

    public static async Task<Result<TResult>> Chain<TResult>(this Task<Result> resultTask, Func<Task<Result<TResult>>> func)
    {
        var result = await resultTask;
        
        if (!result.IsSuccess)
        {
            return result.Error;
        }

        return await func.Invoke();
    }
    
    public static async Task<Result> Chain(this Task<Result> resultTask, Func<Result> func)
    {
        var result = await resultTask;
        
        if (!result.IsSuccess)
        {
            return result.Error;
        }

        return func.Invoke();
    }

    public static async Task<Result<TResult>> Chain<TResult>(this Task<Result> resultTask, Func<Result<TResult>> func)
    {
        var result = await resultTask;
        
        if (!result.IsSuccess)
        {
            return result.Error;
        }

        return func.Invoke();
    }
    
    public static async Task<Result> Chain<TResult>(this Task<Result> resultTask, Action action)
    {
        var result = await resultTask;
        
        if (!result.IsSuccess)
        {
            return result.Error;
        }

        action.Invoke();
        return Results.Ok();
    }
    
    public static async Task<Result> Chain<TResult>(this Task<Result> resultTask, Func<Task> action)
    {
        var result = await resultTask;
        
        if (!result.IsSuccess)
        {
            return result.Error;
        }

        await action.Invoke();
        return Results.Ok();
    }

    public static async Task<Result> Chain<TValue>(this Result<TValue> result, Func<TValue, Task<Result>> func)
    {
        if (!result.IsSuccess)
        {
            return result.Error;
        }

        return await func.Invoke(result.Value);
    }

    public static async Task<Result<TResult>> Chain<TValue, TResult>(this Result<TValue> result,
        Func<TValue, Task<Result<TResult>>> func)
    {
        if (!result.IsSuccess)
        {
            return result.Error;
        }

        return await func.Invoke(result.Value);
    }

    public static async Task<Result> Chain<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, Task<Result>> func)
    {
        var result = await resultTask;
        
        if (!result.IsSuccess)
        {
            return result.Error;
        }

        return await func.Invoke(result.Value);
    }

    public static async Task<Result<TResult>> Chain<TValue, TResult>(this Task<Result<TValue>> resultTask,
        Func<TValue, Task<Result<TResult>>> func)
    {
        var result = await resultTask;
        
        if (!result.IsSuccess)
        {
            return result.Error;
        }

        return await func.Invoke(result.Value);
    }
    
    public static async Task<Result> Chain<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, Result> func)
    {
        var result = await resultTask;
        
        if (!result.IsSuccess)
        {
            return result.Error;
        }

        return func.Invoke(result.Value);
    }

    public static async Task<Result<TResult>> Chain<TValue, TResult>(this Task<Result<TValue>> resultTask,
        Func<TValue, Result<TResult>> func)
    {
        var result = await resultTask;
        
        if (!result.IsSuccess)
        {
            return result.Error;
        }

        return func.Invoke(result.Value);
    }
    
    public static async Task<Result> Chain<TValue>(this Task<Result<TValue>> resultTask, Action<TValue> action)
    {
        var result = await resultTask;
        
        if (!result.IsSuccess)
        {
            return result.Error;
        }

        action.Invoke(result.Value);
        return Results.Ok();
    }

    
    public static async Task<Result> Chain<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, Task> action)
    {
        var result = await resultTask;
        
        if (!result.IsSuccess)
        {
            return result.Error;
        }

        await action.Invoke(result.Value);
        return Results.Ok();
    }

}