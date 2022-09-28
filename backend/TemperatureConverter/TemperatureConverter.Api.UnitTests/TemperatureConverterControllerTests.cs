namespace TemperatureConverter.Api.UnitTests;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TemperatureConverter.Api.Core;
using TemperatureConverter.Api.Controllers;

public class TemperatureConverterControllerTests
{
    [Theory]
    [InlineData("celcius", "kelvin", 0, typeof(OkObjectResult))]
    [InlineData("asdf", "asdf", 0, typeof(BadRequestObjectResult))]
    public void ReturnsCorrectStatusCode(string from, string to, double amount, Type expected)
    {
        var mockLogger = new Mock<IDomainLogger>();
        var sut = new TemperatureConverterController(mockLogger.Object);

        var actual = sut.Convert(from, to, amount);
        
        Assert.Equal(expected, actual.GetType());
    }

    [Fact]
    public void CreatesLogEntry()
    {
        var mockLogger = new Mock<IDomainLogger>();
        var sut = new TemperatureConverterController(mockLogger.Object);

        var actual = sut.Convert("celcius", "kelvin", 0);
        
        mockLogger.Verify(x => x.LogConversion(null, 0, "celcius", "kelvin"), Times.Once);
        mockLogger.VerifyNoOtherCalls();
    }
}