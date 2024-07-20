namespace LivrariaDoLuiz.Domain.Interface.Repository.Common;
public interface IRepositoryReadOnly<T> where T : class
{
    Task<IEnumerable<T?>> GetAsync();
    Task<T?> GetAsync(Guid Id);
}