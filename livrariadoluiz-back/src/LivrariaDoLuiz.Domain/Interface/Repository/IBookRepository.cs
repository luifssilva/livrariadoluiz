using LivrariaDoLuiz.Domain.Entity;
using LivrariaDoLuiz.Domain.Interface.Repository.Common;

namespace LivrariaDoLuiz.Domain.Interface.Repository;

public interface IBookRepository : IRepository<Book>
{
    Task<IEnumerable<Book>?> GetBooksAsync();
    Task<Book?> GetBookAsync(Guid Id);
}