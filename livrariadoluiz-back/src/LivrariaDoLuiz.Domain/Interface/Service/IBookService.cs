using LivrariaDoLuiz.Domain.Entity;
using LivrariaDoLuiz.Domain.Interface.Service.Common;

namespace LivrariaDoLuiz.Domain.Interface.Service;

public interface IBookService : IService<Book>
{
    Task<IEnumerable<Book>?> GetBooksAsync();
    Task<Book?> GetBookAsync(Guid Id);
}