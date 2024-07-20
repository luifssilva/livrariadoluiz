using LivrariaDoLuiz.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace LivrariaDoLuiz.API.Configurations;

public class LivrariaDoLuizMigration : IDisposable
{
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public async Task RunMigrations(WebApplication app)
    {
        await using var scope = app.Services.CreateAsyncScope();
        await using var db = scope.ServiceProvider.GetService<LivrariaDoLuizContext>();
        await db!.Database.MigrateAsync();        
    }
}