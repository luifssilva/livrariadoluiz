using LivrariaDoLuiz.Domain.Interface.Service;
using LivrariaDoLuiz.Domain.Service;

namespace LivrariaDoLuiz.API.Configurations.DependencyInjections;
public static class ServicesConfiguration
{
    public static IServiceCollection AddServicesConfiguration(this IServiceCollection services)
    {
        return services        
                .AddScoped<IAuthorService, AuthorService>()
                .AddScoped<IBookService, BookService>()
                .AddScoped<IGenderService, GenderService>();
    }          
}