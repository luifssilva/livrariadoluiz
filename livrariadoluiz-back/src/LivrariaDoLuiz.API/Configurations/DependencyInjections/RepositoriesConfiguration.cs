using LivrariaDoLuiz.Domain.Interface.Repository;
using LivrariaDoLuiz.Domain.Interface.Repository.Common;
using LivrariaDoLuiz.Infra.Repository;
using LivrariaDoLuiz.Infra.Repository.Common;

namespace LivrariaDoLuiz.API.Configurations.DependencyInjections;
public static class RepositoriesConfiguration
{
    public static IServiceCollection AddRepositoriesConfiguration(this IServiceCollection services)
    {
        return services
                .AddScoped<IUnitOfWork, UnitOfWork>()        
                .AddScoped<IAuthorRepository, AuthorRepository>()
                .AddScoped<IBookRepository, BookRepository>()
                .AddScoped<IGenderRepository, GenderRepository>();
    }         
}