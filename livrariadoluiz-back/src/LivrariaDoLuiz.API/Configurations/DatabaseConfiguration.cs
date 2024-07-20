using LivrariaDoLuiz.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace LivrariaDoLuiz.API.Configurations;
public static class DatabaseConfiguration
{
    public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {   
        return services
                .AddDbContext<LivrariaDoLuizContext>(options => 
                    options.UseSqlServer(configuration!.GetSection("ConnectionStrings:LivrariaConnection").Value));
    }
}  