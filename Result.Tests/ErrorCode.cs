namespace Result.Tests;

public class ErrorCode : IErrorCode
{
    public string Code { get; }

    public ErrorCode(string code)
    {
        Code = code;
    }
}