namespace LivrariaDoLuiz.Domain.Interface.Repository.Common;
public interface IRepository<T> : IUnitOfWork, IRepositoryReadOnly<T> where T : class
{
    Task<T> AddAsync(T entity);
    Task SaveAsync();
    Task EditAsync(T entity);
    Task DeleteAsync(T entity);

}