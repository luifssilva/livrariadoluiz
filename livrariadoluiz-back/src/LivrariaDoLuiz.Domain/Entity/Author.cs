using LivrariaDoLuiz.Domain.Entity.Core;

namespace LivrariaDoLuiz.Domain.Entity;

public class Author : EntityBase
{
    public IEnumerable<Book> Books { get; set; } = null!;
}
