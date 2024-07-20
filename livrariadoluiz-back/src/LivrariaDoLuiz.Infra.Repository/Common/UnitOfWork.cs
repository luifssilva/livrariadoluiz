using LivrariaDoLuiz.Domain.Interface.Repository.Common;
using LivrariaDoLuiz.Infra.Data.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace LivrariaDoLuiz.Infra.Repository.Common;
public class UnitOfWork(LivrariaDoLuizContext context) : IUnitOfWork
{
    private readonly LivrariaDoLuizContext Context = context;
    protected IDbContextTransaction Transaction = null!;

    public async Task BeginTransactionAsync()
    {
        Transaction = await Context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        if (Transaction is not null)
            await Context.Database.CommitTransactionAsync();
    }

    public async Task RollbackTransactionAsync()
    {
        if (Transaction is not null)
            await Context.Database.RollbackTransactionAsync();
    }
}