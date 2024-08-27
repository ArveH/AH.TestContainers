using AH.Model;
using Microsoft.EntityFrameworkCore;

namespace AH.Lib;

public class ContextFactory
{
    private readonly DbContextOptions<AhDbContext> _options;

    public ContextFactory(string connectionString)
    {
        _options = new DbContextOptionsBuilder<AhDbContext>()
            .UseNpgsql(connectionString, npgOptions =>
            {
                npgOptions.CommandTimeout(300);
            })
            .UseLowerCaseNamingConvention()
            .Options;
    }

    public AhDbContext CreateContext()
    {
        return new AhDbContext(_options);
    }
}