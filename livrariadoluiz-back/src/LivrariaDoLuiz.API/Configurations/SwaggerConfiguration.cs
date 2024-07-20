using System.Reflection;

namespace LivrariaDoLuiz.API.Configurations;
public static class SwaggerConfiguration
{
    public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
    {
        return services
                .AddSwaggerGen(options =>
                {
                    string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    options.IncludeXmlComments(xmlPath);                    
                })
                .AddApiVersioning(x => 
                {
                    x.ReportApiVersions = true;    
                })
                .AddVersionedApiExplorer(x => 
                {
                    x.GroupNameFormat = "'v'VVV";
                    x.SubstituteApiVersionInUrl = true;
                });
    } 
}
