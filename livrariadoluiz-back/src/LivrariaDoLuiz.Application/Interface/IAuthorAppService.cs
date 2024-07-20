using LivrariaDoLuiz.Application.Entity;
using LivrariaDoLuiz.Domain.DTO;

namespace LivrariaDoLuiz.Application.Interface;
public interface IAuthorAppService
{
    Task<Response> GetAsync();
    Task<Response> GetAsync(Guid Id);
    Task<Response> Post(AuthorRequest req);
    Task<Response> Put(AuthorRequest req);
    Task<Response> Delete(Guid Id);
}