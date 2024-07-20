using LivrariaDoLuiz.Domain.Entity;
using LivrariaDoLuiz.Domain.Interface.Repository;
using LivrariaDoLuiz.Domain.Interface.Service;
using LivrariaDoLuiz.Domain.Service.Common;

namespace LivrariaDoLuiz.Domain.Service;
public class BookService(IBookRepository bookRepository)
    : ServiceBase<Book>(bookRepository), IBookService
{
    private readonly IBookRepository _bookRepository = bookRepository;
    public async Task<IEnumerable<Book>?> GetBooksAsync()
    {
        return await _bookRepository.GetBooksAsync();
    }
    public async Task<Book?> GetBookAsync(Guid Id)
    {
        return await _bookRepository.GetBookAsync(Id);
    }    
}
