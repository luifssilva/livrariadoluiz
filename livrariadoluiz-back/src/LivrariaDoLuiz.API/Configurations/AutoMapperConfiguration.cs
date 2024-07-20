using System.Reflection;

namespace LivrariaDoLuiz.API.Configurations;

public static class AutoMapperConfiguration
{
    public static IServiceCollection AddAutoMapperConfigurations(this IServiceCollection services)
    {   
        return services.AddAutoMapper(Assembly.GetExecutingAssembly());
    }
}  
