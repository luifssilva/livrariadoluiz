using LivrariaDoLuiz.Domain.Entity;
using LivrariaDoLuiz.Domain.Interface.Repository;
using LivrariaDoLuiz.Infra.Data.Context;
using LivrariaDoLuiz.Infra.Repository.Common;
using Microsoft.EntityFrameworkCore;

namespace LivrariaDoLuiz.Infra.Repository;

public class BookRepository : Repository<Book>, IBookRepository
{
    private LivrariaDoLuizContext _livrariaDoLuizContext;
    public BookRepository(LivrariaDoLuizContext livrariaDoLuizContext)
        : base(livrariaDoLuizContext)
    {
        _livrariaDoLuizContext = livrariaDoLuizContext;
    }

    public async Task<IEnumerable<Book>?> GetBooksAsync()
    {
        return await _livrariaDoLuizContext
                        .Book
                        .AsNoTracking()
                            .Include(x => x.Author)
                            .Include(x => x.Gender)
                        .ToListAsync();
    }

    public async Task<Book?> GetBookAsync(Guid Id)
    {
        return await _livrariaDoLuizContext
                        .Book
                        .AsNoTracking()
                            .Include(x => x.Author)
                            .Include(x => x.Gender)                        
                        .FirstOrDefaultAsync(x => x.Id == Id)!;
    }    
}