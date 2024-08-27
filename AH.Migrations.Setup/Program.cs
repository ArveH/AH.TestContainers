using AH.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

const string ConnectionString = "";

var builder = Host.CreateDefaultBuilder(args);
builder.ConfigureServices((context, services) =>
{
    services.AddDbContext<AhDbContext>(options =>
    {
        options.UseNpgsql(context.Configuration.GetConnectionString(
            ConnectionString), 
            npgOptions =>
            {
                npgOptions.MigrationsAssembly(typeof(AH.Migrations.Postgres.Marker).Assembly.GetName().Name);
                npgOptions.CommandTimeout(300);
            });
    });
});
builder.Build();
