using LivrariaDoLuiz.Domain.Entity;
using LivrariaDoLuiz.Infra.Data.Context.Mapping.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LivrariaDoLuiz.Infra.Data.Mapping;

public class BookMapping : EntityBaseMapping<Book>
{
    public override void Configure(EntityTypeBuilder<Book> builder)
    {
        base.Configure(builder);

        builder
            .ToTable("Book");

        builder
            .HasOne(x => x.Author)
            .WithMany(x => x.Books)
            .HasForeignKey(x => x.AuthorId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(x => x.Gender)
            .WithMany(x => x.Books)
            .HasForeignKey(x => x.GenderId)
            .OnDelete(DeleteBehavior.NoAction);            
    }
}