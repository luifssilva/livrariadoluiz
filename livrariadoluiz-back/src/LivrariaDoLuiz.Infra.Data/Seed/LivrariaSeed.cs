using LivrariaDoLuiz.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace LivrariaDoLuiz.Infra.Data.Seed;

public static class LivrariaSeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        Random numAleatorio = new Random();

        var authors = new List<Author>();

        for (int i = 1; i <= 5; i++)
        {
            authors.Add(new()
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
                Name = $"Author {i}"   
            });
        }

        authors.ForEach(item => modelBuilder.Entity<Author>().HasData(item));

        var genders = new List<Gender>();

        for (int i = 1; i <= 5; i++)
        {
            genders.Add(new()
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
                Name = $"Gender {i}"   
            });
        }        

        genders.ForEach(item => modelBuilder.Entity<Gender>().HasData(item));

        var books = new List<Book>
        {
            new()
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
                AuthorId = authors.Where(x => x.Name.Contains('1')).First().Id,
                GenderId = genders.Where(x => x.Name.Contains('3')).First().Id,
                Edition = 1,
                ISBN = "Xpto",
                Language = "Portuguese",
                Name = "Game of Thrones: As Crônicas de Gelo e Fogo",
                Pages = 700
            }
        };

        books.ForEach(item => modelBuilder.Entity<Book>().HasData(item));
    }
}