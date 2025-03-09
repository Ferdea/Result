namespace Result;

public class Error
{
    public IErrorCode Code { get; }
    public string? Message { get; }
    public Error[] Details { get; }

    public Error(IErrorCode code, string? message = null, params Error[] details)
    {
        Code = code;
        Message = message;
        Details = details;
    }
}