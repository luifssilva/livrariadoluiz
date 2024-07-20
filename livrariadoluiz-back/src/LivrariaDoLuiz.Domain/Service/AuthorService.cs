using LivrariaDoLuiz.Domain.Entity;
using LivrariaDoLuiz.Domain.Interface.Repository;
using LivrariaDoLuiz.Domain.Interface.Service;
using LivrariaDoLuiz.Domain.Service.Common;

namespace LivrariaDoLuiz.Domain.Service;
public class AuthorService(IAuthorRepository authorRepository) 
    : ServiceBase<Author>(authorRepository), IAuthorService
{

}
