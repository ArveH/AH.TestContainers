using AH.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace AH.Model;

public class AhDbContext : DbContext
{
    private const string CIAICollation = "en_ci_ai";
    private const string CIASCollation = "en_ci_as";

    public AhDbContext(DbContextOptions<AhDbContext> options)
        : base(options)
    {
    }

    public DbSet<Person> People => Set<Person>();

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<string>().UseCollation(CIAICollation);
        base.ConfigureConventions(configurationBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasCollation(CIAICollation,
            provider: "icu",
            locale: "en-u-ks-level1",
            deterministic: false);
        modelBuilder.HasCollation(CIASCollation,
            provider: "icu",
            locale: "en-u-ks-level2",
            deterministic: false);

        modelBuilder.Entity<Person>().HasData(
            new Person { Id = 1, FirstName = "John", LastName = "Doe" },
            new Person { Id = 2, FirstName = "Jane", LastName = "Doe" }
        );
    }
}