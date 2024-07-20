using LivrariaDoLuiz.Domain.Interface.Repository.Common;

namespace LivrariaDoLuiz.Domain.Interface.Service.Common;
public interface IService<T> : IUnitOfWork, IServiceReadOnly<T> where T : class  
{
    Task<T> AddAsync(T entity);
    Task SaveAsync();
    Task EditAsync(T entity);
    Task DeleteAsync(T entity);
}