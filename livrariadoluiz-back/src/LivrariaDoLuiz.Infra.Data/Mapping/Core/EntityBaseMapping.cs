using LivrariaDoLuiz.Domain.Entity.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LivrariaDoLuiz.Infra.Data.Context.Mapping.Core;

public abstract class EntityBaseMapping<T> : IEntityTypeConfiguration<T>
    where T : EntityBase
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .HasColumnOrder(0);           

        builder
            .Property(x => x.CreatedAt)
            .HasColumnType("datetime")
            .IsRequired()
            .HasColumnOrder(1);

        builder
            .Property(x => x.Name)
            .HasColumnType("varchar(255)")
            .IsRequired()            
            .HasColumnOrder(2);
    }
}