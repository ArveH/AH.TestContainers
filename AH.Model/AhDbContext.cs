using AH.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace AH.Model;

public class AhDbContext : DbContext
{
    public AhDbContext(DbContextOptions<AhDbContext> options)
        : base(options)
    { }

    public DbSet<Person> People => Set<Person>();

}