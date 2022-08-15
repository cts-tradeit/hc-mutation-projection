using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MutationProjection.Access.Model;

namespace MutationProjection.Access.EntityConfig;

public class CarConfig: IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Owner).WithMany(x => x.Cars).HasForeignKey(x => x.OwnerId);
    }
}