namespace LivrariaDoLuiz.Domain.DTO;

public class AuthorRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;    
}