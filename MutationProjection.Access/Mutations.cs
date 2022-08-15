using HotChocolate.Data.Projections.Expressions;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using MutationProjection.Access.Model;

namespace MutationProjection.Access
{
    public class Mutations
    {
        [UseProjection]
        public async Task<Car> ChangeLicensePlateAsync(int id, string newPlate, TestDbContext dbContext, IResolverContext ctx)
        {
            Car car = await dbContext.Set<Car>().SingleAsync(c => c.Id == id);
            car.LicensePlate = newPlate;
            dbContext.Update(car);
            await dbContext.SaveChangesAsync();

            return await dbContext.Set<Car>().Where(c => c.Id == id).Project(ctx).SingleAsync();
        }
    }
}
