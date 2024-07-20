namespace LivrariaDoLuiz.Domain.DTO;

public class GenderResponse
{
    public Guid Id { get; set; }     
    public DateTime CreatedAt { get;set; }
    public string Name { get; set; } = null!;    
}