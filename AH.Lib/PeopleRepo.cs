using AH.Database.Entities;
using AH.Model;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace AH.Lib
{
    public class PeopleRepo(
        ILogger logger,
        AhDbContext context) : IDisposable, IPeopleRepo
    {
        private readonly ILogger _logger = logger.ForContext<PeopleRepo>();

        public async Task<IEnumerable<Person>> GetPeopleAsync()
        {
            _logger.Information("Getting all people");
            return await context.People.ToListAsync();
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _logger.Information("Disposing PeopleRepo");
                context.Dispose();
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
