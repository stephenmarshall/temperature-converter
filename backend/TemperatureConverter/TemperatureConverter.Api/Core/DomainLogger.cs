namespace TemperatureConverter.Api.Core;

public interface IDomainLogger
{
    void LogConversion(string? user, double amount, string to, string from);
}

public class DomainLogger : IDomainLogger
{
    private readonly ILogger<DomainLogger> _logger;

    public DomainLogger(ILogger<DomainLogger> logger)
    {
        _logger = logger;
    }

    public void LogConversion(string? user, double amount, string from, string to)
    {
        _logger.LogInformation("{user} converted {amount} from {from} to {to} at {time}",
            user ?? "unknown_user", amount, from, to, DateTimeOffset.Now);
    }
}