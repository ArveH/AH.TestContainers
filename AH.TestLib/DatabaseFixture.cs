using Testcontainers.PostgreSql;

namespace AH.TestLib;

public class DatabaseFixture : IAsyncLifetime
{
    private PostgreSqlContainer? _pgContainer;

    private string _connectionString = string.Empty;

    public string PgConnectionString => _connectionString
        ?? throw new ArgumentNullException(nameof(PgConnectionString));

    public async Task InitializeAsync()
    {
        _pgContainer = new PostgreSqlBuilder()
            .WithImage("postgres:latest")
            .Build();
        await _pgContainer.StartAsync();
        _connectionString = _pgContainer.GetConnectionString();
    }

    public async Task DisposeAsync()
    {
        if (_pgContainer != null)
        {
            await _pgContainer.DisposeAsync();
            _pgContainer = null;
        }
    }
}