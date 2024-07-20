using LivrariaDoLuiz.Domain.Entity;
using LivrariaDoLuiz.Infra.Data.Context.Mapping.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LivrariaDoLuiz.Infra.Data.Mapping;

public class AuthorMapping : EntityBaseMapping<Author>
{
    public override void Configure(EntityTypeBuilder<Author> builder)
    {
        base.Configure(builder);

        builder
            .ToTable("Author");
    }
}