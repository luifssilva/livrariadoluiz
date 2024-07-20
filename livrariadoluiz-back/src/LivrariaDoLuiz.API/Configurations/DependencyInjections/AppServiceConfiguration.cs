using LivrariaDoLuiz.Application.Interface;
using LivrariaDoLuiz.Application.Service;

namespace LivrariaDoLuiz.API.Configurations.DependencyInjections;
public static class AppServiceConfiguration
{
    public static IServiceCollection AddAppServicesConfiguration(this IServiceCollection services)
    {
        return services
                .AddScoped<IAuthorAppService, AuthorAppService>()
                .AddScoped<IBookAppService, BookAppService>()
                .AddScoped<IGenderAppService, GenderAppService>();                
    }          
}