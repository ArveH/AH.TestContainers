using AH.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;
using ILogger = Serilog.ILogger;

namespace AH.Lib;

public class ContextFactory
{
    private readonly ILogger _logger;
    private readonly DbContextOptions<AhDbContext> _options;

    public ContextFactory(
        ILogger logger,
        string connectionString)
    {
        _logger = logger;
        _logger.Information("Setting up context for connection: {ConnectionString}",
            connectionString);
        _options = new DbContextOptionsBuilder<AhDbContext>()
            .UseNpgsql(connectionString, npgOptions =>
            {
                npgOptions.CommandTimeout(300);
            })
            .UseLoggerFactory(new LoggerFactory().AddSerilog(_logger))
            .UseLowerCaseNamingConvention()
            .Options;

        using var context = CreateContext();
        context.Database.EnsureCreated();
    }

    public AhDbContext CreateContext()
    {
        _logger.Information("Creating context");
        return new AhDbContext(_options);
    }
}