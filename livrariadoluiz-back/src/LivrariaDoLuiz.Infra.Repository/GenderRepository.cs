using LivrariaDoLuiz.Domain.Entity;
using LivrariaDoLuiz.Domain.Interface.Repository;
using LivrariaDoLuiz.Infra.Data.Context;
using LivrariaDoLuiz.Infra.Repository.Common;

namespace LivrariaDoLuiz.Infra.Repository;

public class GenderRepository : Repository<Gender>, IGenderRepository
{
    public GenderRepository(LivrariaDoLuizContext livrariaDoLuizContext)
        : base(livrariaDoLuizContext)
    {
        
    }
}