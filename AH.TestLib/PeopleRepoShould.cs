using AH.Lib;
using FluentAssertions;

namespace AH.TestLib
{
    public class PeopleRepoShould
    {
        private const string ConnectionString = "Host=localhost;Port=5432;Database=AHTestContainers;Username=postgres;Include Error Detail=true";

        [Fact]
        public async Task GetAllPeople()
        {
            // Arrange
            await using var context = new ContextFactory(ConnectionString).CreateContext();
            using var cut = new PeopleRepo(context);

            // Act
            var people = (await cut.GetPeopleAsync()).ToList();

            // Assert
            people.Should().NotBeEmpty();
            people.Select(p => p.FirstName).Should().Contain("John");
        }
    }
}