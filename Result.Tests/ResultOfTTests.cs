using FluentAssertions;
using NUnit.Framework;

namespace Result.Tests;

public class ResultOfTTests
{
    [Test]
    public void Should_ResultOfT_IsSuccess_WhenHaveValue()
    {
        var result = Results.FromValue("value");
        result.IsSuccess.Should().BeTrue();
    }
    
    [Test]
    public void Should_ResultOfT_IsSuccess_WhenHaveError()
    {
        var result = Results.Error<string>(new ErrorCode("errorCode"));
        result.IsSuccess.Should().BeFalse();
    }
    
    [Test]
    public void Should_Result_ReturnValue_OnEnsureValue_WhenNotHaveError()
    {
        var value = "value";
        var result = Results.FromValue(value);
        var valueFromResult = result.EnsureValue();
        valueFromResult.Should().Be(value);
    }
    
    [Test]
    public void Should_Result_ThrowException_OnEnsureValue_WhenHaveError()
    {
        var result = Results.Error<string>(new ErrorCode("errorCode"));
        var ensureSuccess = () => result.EnsureValue();
        ensureSuccess.Should().Throw<InvalidOperationException>();
    }
}