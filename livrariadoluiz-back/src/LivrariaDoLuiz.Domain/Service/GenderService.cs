using LivrariaDoLuiz.Domain.Entity;
using LivrariaDoLuiz.Domain.Interface.Repository;
using LivrariaDoLuiz.Domain.Interface.Service;
using LivrariaDoLuiz.Domain.Service.Common;

namespace LivrariaDoLuiz.Domain.Service;
public class GenderService(IGenderRepository genderRepository) 
    : ServiceBase<Gender>(genderRepository), IGenderService
{
    
}
