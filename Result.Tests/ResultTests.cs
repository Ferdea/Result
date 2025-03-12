using FluentAssertions;
using NUnit.Framework;

namespace Result.Tests;

public class ResultTests
{
    [Test]
    public void Should_Result_IsSuccess_WhenNotHaveError()
    {
        var result = Results.Ok();
        result.IsSuccess.Should().BeTrue();
    }
    
    [Test]
    public void Should_Result_IsSuccess_WhenHaveError()
    {
        var result = Results.Error(new ErrorCode("errorCode"));
        result.IsSuccess.Should().BeFalse();
    }

    [Test]
    public void Should_Result_NotThrowException_OnEnsureSuccess_WhenNotHaveError()
    {
        var result = Results.Ok();
        result.EnsureSuccess();
    }
    
    [Test]
    public void Should_Result_ThrowException_OnEnsureSuccess_WhenHaveError()
    {
        var result = Results.Error(new ErrorCode("errorCode"));
        var ensureSuccess = () => result.EnsureSuccess();
        ensureSuccess.Should().Throw<InvalidOperationException>();
    }
}