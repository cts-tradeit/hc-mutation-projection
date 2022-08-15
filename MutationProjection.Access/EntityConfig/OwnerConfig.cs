using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MutationProjection.Access.Model;

namespace MutationProjection.Access.EntityConfig;

public class OwnerConfig: IEntityTypeConfiguration<Owner>
{
    public void Configure(EntityTypeBuilder<Owner> builder)
    {
        builder.HasKey(x => x.Id);
    }
}