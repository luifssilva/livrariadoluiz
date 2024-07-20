using LivrariaDoLuiz.API.Configurations.DependencyInjections;

namespace LivrariaDoLuiz.API.Configurations;
public static class DependencyInjectionConfiguration
{
    public static IServiceCollection AddDependecyInjectionConfiguration(this IServiceCollection services)
    {
        return services
                .AddAppServicesConfiguration()
                .AddServicesConfiguration()
                .AddRepositoriesConfiguration();
    }          
}  