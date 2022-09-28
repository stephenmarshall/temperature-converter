using Microsoft.AspNetCore.Mvc;
using TemperatureConverter.Api.Core;

namespace TemperatureConverter.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TemperatureConverterController : ControllerBase
{
    private readonly IDomainLogger _logger;

    public TemperatureConverterController(IDomainLogger logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "convert")]
    public ActionResult Convert(string from, string to, double amount)
    {
        _logger.LogConversion(HttpContext?.User.Identity?.Name,
            amount, from, to);

        Unit fromUnit, toUnit;

        if (!Enum.TryParse(from, true, out fromUnit)
            || !Enum.TryParse(to, true, out toUnit))
            return BadRequest("Supported units are: Celcius, Kelvin or Fahrenheit");

        var result = new TemperatureConverter.Api.Core.TemperatureConverter()
            .Convert(fromUnit, toUnit, amount);

        return Ok(result);
    }
}

