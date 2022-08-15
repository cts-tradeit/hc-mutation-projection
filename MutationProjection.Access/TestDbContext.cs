using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MutationProjection.Access;

public class TestDbContext: DbContext
{
    public TestDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}