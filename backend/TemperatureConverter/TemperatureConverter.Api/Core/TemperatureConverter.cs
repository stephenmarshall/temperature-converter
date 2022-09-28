namespace TemperatureConverter.Api.Core;

public enum Unit
{
    Celcius,
    Kelvin,
    Fahrenheit
}

public class TemperatureConverter
{
    public double Convert(Unit from, Unit to, double amount)
    => from switch
    {
        Unit.Celcius when to is Unit.Kelvin => amount + 273.15,
        Unit.Celcius when to is Unit.Fahrenheit => amount * 1.8 + 32,
        Unit.Kelvin when to is Unit.Celcius => amount - 273.15,
        Unit.Kelvin when to is Unit.Fahrenheit => (amount - 273.15) * 1.8 + 32,
        Unit.Fahrenheit when to is Unit.Celcius => (amount - 32) / 1.8,
        Unit.Fahrenheit when to is Unit.Kelvin => (amount - 32) / 1.8 + 273.15,
        _ => amount
    };
}