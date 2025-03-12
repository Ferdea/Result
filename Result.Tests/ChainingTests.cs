using FluentAssertions;
using NUnit.Framework;

namespace Result.Tests;

public class ChainingTests
{
    [Test]
    public void Should_ExecuteAllChainElements_WhenNotHaveErrors()
    {
        var counter = 0;
        var initialValue = "value";
        
        var chainResult = Results.FromFunc(() =>
            {
                counter++;
                return initialValue;
            })
            .Chain<string, string>(value =>
            {
                counter++;
                return value;
            })
            .Chain<string, string>(value =>
            {
                counter++;
                return value;
            });
        
        chainResult.IsSuccess.Should().BeTrue();
        chainResult.Value.Should().Be(initialValue);
        counter.Should().Be(3);
    }
    
    [Test]
    public void Should_NotExecuteChainElements_WhenHaveErrors()
    {
        var counter = 0;
        
        var chainResult = Results.Error<string>(new ErrorCode("errorCode"))
            .Chain<string, string>(value =>
            {
                counter++;
                return value;
            })
            .Chain<string, string>(value =>
            {
                counter++;
                return value;
            });
        
        chainResult.IsSuccess.Should().BeFalse();
        chainResult.Error.Should().NotBeNull();
        chainResult.Error.Code.Should().BeEquivalentTo(new ErrorCode("errorCode"));
        counter.Should().Be(0);
    }
}