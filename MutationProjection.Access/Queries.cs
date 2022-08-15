using MutationProjection.Access.Model;

namespace MutationProjection.Access;

public class Queries
{
    [UseProjection]
    public IQueryable<Car> GetCars(TestDbContext dbContext)
        => dbContext.Set<Car>();
    
    [UseProjection]
    public IQueryable<Owner> GetOwners(TestDbContext dbContext)
        => dbContext.Set<Owner>();
}