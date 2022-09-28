namespace TemperatureConverter.Api.UnitTests;
using TemperatureConverter.Api.Core;

public class TemperatureConverterTests
{
    [Theory]
    [InlineData(Unit.Celcius, Unit.Kelvin, 0, 273.15)]
    [InlineData(Unit.Celcius, Unit.Fahrenheit, 0, 32)]
    [InlineData(Unit.Celcius, Unit.Fahrenheit, 100, 212)]
    [InlineData(Unit.Celcius, Unit.Celcius, 0, 0)]
    [InlineData(Unit.Kelvin, Unit.Celcius, 0, -273.15)]
    [InlineData(Unit.Kelvin, Unit.Fahrenheit, 273.15, 32)]
    [InlineData(Unit.Kelvin, Unit.Fahrenheit, 373.15, 212)]
    [InlineData(Unit.Kelvin, Unit.Kelvin, 0, 0)]
    [InlineData(Unit.Fahrenheit, Unit.Celcius, 32, 0)]
    [InlineData(Unit.Fahrenheit, Unit.Kelvin, 32, 273.15)]
    [InlineData(Unit.Fahrenheit, Unit.Celcius, 212, 100)]
    [InlineData(Unit.Fahrenheit, Unit.Kelvin, 212, 373.15)]
    [InlineData(Unit.Fahrenheit, Unit.Fahrenheit, 0, 0)]
    public void ConvertTemperature(Unit from, Unit to, double amount, double expected)
    {
        var sut = new TemperatureConverter();

        var actual = sut.Convert(from, to, amount);

        Assert.Equal(expected, actual);
    }
}