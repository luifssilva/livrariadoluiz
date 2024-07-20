namespace LivrariaDoLuiz.Domain.Interface.Service.Common;
public interface IServiceReadOnly<T> where T : class
{
    Task<IEnumerable<T?>> GetAsync();
    Task<T?> GetAsync(Guid id);
}