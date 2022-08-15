using Microsoft.EntityFrameworkCore;
using MutationProjection.Access;
using MutationProjection.Access.Model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TestDbContext>(opts => opts.UseInMemoryDatabase("test-db"));
builder.Services.AddGraphQLServer()
    .RegisterDbContext<TestDbContext>()
    .AddQueryType<Queries>()
    .AddMutationType<Mutations>()
    .AddProjections();

var app = builder.Build();

// Seed data
using (IServiceScope scope = app.Services.CreateScope())
{
    TestDbContext dbContext = scope.ServiceProvider.GetRequiredService<TestDbContext>();
    Owner owner1 = new()
    {
        Name = "John Doe",
        Cars = new[]
        {
            new Car
            {
                LicensePlate = "AZ50"
            },
            new Car
            {
                LicensePlate = "LA6954"
            }
        }
    };
    Owner owner2 = new()
    {
        Name = "marry Doe",
        Cars = new[]
        {
            new Car
            {
                LicensePlate = "ASP62"
            },
            new Car
            {
                LicensePlate = "YAKHN1465"
            }
        }
    };
    dbContext.Add(owner1);
    dbContext.Add(owner2);
    dbContext.SaveChanges();
} 

// Configure pipeline and run
app.MapGraphQL();
app.Run();

