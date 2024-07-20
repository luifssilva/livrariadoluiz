namespace LivrariaDoLuiz.Domain.Entity.Core;

public class EntityBase
{
    public Guid Id { get; set; }     
    public DateTime CreatedAt { get;set; }
    public string Name { get; set; } = null!;
}
