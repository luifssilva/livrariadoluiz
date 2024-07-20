using LivrariaDoLuiz.Domain.Entity.Core;

namespace LivrariaDoLuiz.Domain.Entity;

public class Book : EntityBase
{
    public Book() { }    
    public int Pages { get; set; }
    public string Language { get; set; } = null!;
    public int Edition { get; set; }
    public string ISBN { get; set; } = null!;
    public Guid GenderId { get; set; }
    public Gender Gender { get; set; }  = null!;
    public Guid AuthorId { get; set; }
    public Author Author { get; set; } = null!;
}
