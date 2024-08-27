using AH.Database.Entities;
using AH.Model;
using Microsoft.EntityFrameworkCore;

namespace AH.Lib
{
    public class PeopleRepo(AhDbContext context) : IDisposable, IPeopleRepo
    {
        public async Task<IEnumerable<Person>> GetPeopleAsync()
        {
            return await context.People.ToListAsync();
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
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
