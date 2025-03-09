namespace Result;

public class AsyncResults
{
    public static async Task<Result<TValue>> Ok<TValue>(Func<Task<TValue>> func)
        => new(await func.Invoke());
}