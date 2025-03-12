# Result
Result library for C# on .NET 6

Use result for wrap errors
```csharp
var result = Results.Ok(); // or Results.Error(new ErrorCode())

if (!result.IsSuccess) 
{
    Logger.Error("Error result: {0}", result.Error.Code);
}
else 
{
    Logger.Info("Result is success");   
}
```
You can also wrap the value
```csharp
var result = Results.FromValue(value); // or Results.Error(new ErrorCode())

if (!result.IsSuccess) 
{
    Logger.Error("Error result: {0}", result.Error.Code);
}
else 
{
    Logger.Info("Result is success: {0}", result.Value);   
}
```
Use chaining for sequential data processing
```csharp
var result = Results.FromValue(userId)
    .Chain<Guid, User>(userId => repository.GetUserById(userId))
    .Chain<User, Phone>(user => user.Phone)
    .Chain(phone => smsService.SendSms(phone));

if (result.IsSuccess)
{
    Logger.Info("Sms sent");
}
```
