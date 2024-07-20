using LivrariaDoLuiz.Application.Entity;
using LivrariaDoLuiz.Domain.DTO;

namespace LivrariaDoLuiz.Application.Interface;
public interface IBookAppService
{
    Task<Response> GetAsync();
    Task<Response> GetAsync(Guid Id);
    Task<Response> Post(BookRequest req);
    Task<Response> Put(BookRequest req);
    Task<Response> Delete(Guid Id);
}