using LivrariaDoLuiz.Domain.Entity.Core;

namespace LivrariaDoLuiz.Domain.Entity;

public class Gender : EntityBase
{
    public IEnumerable<Book> Books { get; set; } = null!;
}