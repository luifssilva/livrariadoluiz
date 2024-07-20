using LivrariaDoLuiz.Domain.Entity;
using LivrariaDoLuiz.Infra.Data.Context.Mapping.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LivrariaDoLuiz.Infra.Data.Mapping;

public class GenderMapping : EntityBaseMapping<Gender>
{
    public override void Configure(EntityTypeBuilder<Gender> builder)
    {
        base.Configure(builder);

        builder
            .ToTable("Gender");
    }
}