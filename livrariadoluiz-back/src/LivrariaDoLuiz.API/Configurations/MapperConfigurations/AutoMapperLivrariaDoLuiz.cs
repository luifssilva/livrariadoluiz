using AutoMapper;
using LivrariaDoLuiz.Domain.DTO;
using LivrariaDoLuiz.Domain.Entity;

namespace LivrariaDoLuiz.API.Configurations.MapperConfigurations;

public class AutoMapperLivrariaDoLuiz : Profile
{
    public AutoMapperLivrariaDoLuiz()
    {
        CreateMap<Author, AuthorResponse>()
            .ReverseMap();            

        CreateMap<AuthorRequest, Author>()
            .AfterMap((src, dest) => {
                if (src.Id == Guid.Empty)
                {
                    dest.Id = Guid.NewGuid();
                    dest.CreatedAt = DateTime.UtcNow;
                }
                src.Name = dest.Name;
            });

        CreateMap<Book, BookResponse>()
            .ReverseMap();            

        CreateMap<BookRequest, Book>()
            .AfterMap((src, dest) => {
                if (src.Id == Guid.Empty)
                {
                    dest.Id = Guid.NewGuid();
                    dest.CreatedAt = DateTime.UtcNow;
                }
            }); 

        CreateMap<Gender, GenderResponse>()
            .ReverseMap();            

        CreateMap<GenderRequest, Gender>()
            .AfterMap((src, dest) => {
                if (src.Id == Guid.Empty)
                {
                    dest.Id = Guid.NewGuid();
                    dest.CreatedAt = DateTime.UtcNow;
                }
            }); 
                        
            
                       
    }
}  