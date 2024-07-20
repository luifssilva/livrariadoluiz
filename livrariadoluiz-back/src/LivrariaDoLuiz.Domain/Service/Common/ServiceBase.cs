using LivrariaDoLuiz.Domain.Interface.Repository.Common;
using LivrariaDoLuiz.Domain.Interface.Service.Common;

namespace LivrariaDoLuiz.Domain.Service.Common;
public class ServiceBase<T>(IRepository<T> repository) : IService<T>, IDisposable where T : class
{
        private readonly IRepository<T> Repository = repository;
        public void Dispose() => GC.SuppressFinalize(this);
        public async Task BeginTransactionAsync() => await Repository.BeginTransactionAsync();
        public async Task CommitTransactionAsync() => await Repository.CommitTransactionAsync();
        public async Task RollbackTransactionAsync() => await Repository.RollbackTransactionAsync();
        public async Task<IEnumerable<T?>> GetAsync() =>  await Repository.GetAsync();
        public async Task<T?> GetAsync(Guid id) =>  await Repository.GetAsync(id);
        public async Task<T> AddAsync(T entity) => await Repository.AddAsync(entity);
        public async Task SaveAsync() => await Repository.SaveAsync();
        public async Task EditAsync(T entity) => await Repository.EditAsync(entity);
        public async Task DeleteAsync(T entity) => await Repository.DeleteAsync(entity);
}