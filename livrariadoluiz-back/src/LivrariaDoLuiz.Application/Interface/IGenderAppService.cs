using LivrariaDoLuiz.Application.Entity;
using LivrariaDoLuiz.Domain.DTO;

namespace LivrariaDoLuiz.Application.Interface;
public interface IGenderAppService
{
    Task<Response> GetAsync();
    Task<Response> GetAsync(Guid Id);
    Task<Response> Post(GenderRequest req);
    Task<Response> Put(GenderRequest req);
    Task<Response> Delete(Guid Id);    
}
