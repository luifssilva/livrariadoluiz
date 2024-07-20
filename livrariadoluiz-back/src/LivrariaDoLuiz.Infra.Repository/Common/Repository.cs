using LivrariaDoLuiz.Domain.Interface.Repository.Common;
using LivrariaDoLuiz.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace LivrariaDoLuiz.Infra.Repository.Common;
public class Repository<T>(LivrariaDoLuizContext context) : UnitOfWork(context), IRepository<T>, IDisposable
    where T : class
{
    private readonly LivrariaDoLuizContext Context = context;

    public void Dispose()
    {
        GC.SuppressFinalize(this);  
    }
    public async Task<IEnumerable<T?>> GetAsync()
    {
        return await Context.Set<T>().ToListAsync();
    }    
    public async Task<T?> GetAsync(Guid Id)
    {
        return await Context.Set<T>().FindAsync(Id);
    }

    public async Task<T> AddAsync(T entity)
    {
        await Context.Set<T>().AddAsync(entity);
        return entity;
    }

    public async Task SaveAsync()
    {
        await Context.SaveChangesAsync();
    }

    public async Task EditAsync(T entity)
    {
        context.ChangeTracker.Clear();
        await Task.FromResult(context.Set<T>().Update(entity!));
    }    

    public async Task DeleteAsync(T entity)
    {
        context.ChangeTracker.Clear();
        await Task.FromResult(context.Set<T>().Remove(entity!));
    }        
}