using AH.Lib;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Xunit.Abstractions;

namespace AH.TestLib
{
    [Collection(nameof(DatabaseCollection))]
    public class PeopleRepoShould
    {
        private readonly DatabaseFixture _dbFixture;
        private readonly ILogger _testLogger;

        public PeopleRepoShould(
            DatabaseFixture dbFixture, ITestOutputHelper output)
        {
            _dbFixture = dbFixture;

            var loggerConfig = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .MinimumLevel.Verbose()
                .WriteTo.TestOutput(output);
            _testLogger = loggerConfig.CreateLogger();
        }

        [Fact]
        public async Task GetAllPeople()
        {
            // Arrange
            await using var context = new ContextFactory(
                    _testLogger, _dbFixture.PgConnectionString)
                .CreateContext();
            using var cut = new PeopleRepo(_testLogger, context);

            // Act
            var people = (await cut.GetPeopleAsync()).ToList();

            // Assert
            people.Should().NotBeEmpty();
            people.Select(p => p.FirstName).Should().Contain("John");
        }

        [Fact]
        public async Task GetAnError()
        {
            // Arrange
            await using var context = new ContextFactory(
                    _testLogger, _dbFixture.PgConnectionString)
                .CreateContext();

            // Act
            var rows = await context.Database.ExecuteSqlAsync($"delete from does_not_exist");

            // Assert
            rows.Should().Be(0);
        }
    }
}