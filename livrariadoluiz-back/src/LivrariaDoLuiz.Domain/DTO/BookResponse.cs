namespace LivrariaDoLuiz.Domain.DTO;

public class BookResponse
{
    public Guid Id { get; set; }     
    public DateTime CreatedAt { get;set; }
    public string Name { get; set; } = null!;    
    public int Pages { get; set; }
    public string Language { get; set; } = null!;
    public int Edition { get; set; }
    public string ISBN { get; set; } = null!;   
    public GenderResponse Gender { get; set; }  = null!;
    public AuthorResponse Author { get; set; } = null!;     
}