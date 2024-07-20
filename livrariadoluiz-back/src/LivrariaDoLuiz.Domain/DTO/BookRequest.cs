namespace LivrariaDoLuiz.Domain.DTO;

public class BookRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;   
    public int Pages { get; set; }
    public string Language { get; set; } = null!;
    public int Edition { get; set; }
    public string ISBN { get; set; } = null!;  
    public Guid AuthorId { get; set; }       
    public Guid GenderId { get; set; }       
}