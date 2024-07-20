namespace LivrariaDoLuiz.Domain.Interface.Repository.Common;
public interface IUnitOfWork
{
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}