using api_cadastro_backend.Domain.Interfaces.Transactions;
using api_cadastro_backend.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace api_cadastro_backend.Infrastructure.Data.UnitOfWork;

public class UnitOfWorkEF : IUnitOfWork
{
    private readonly DataContext _context;
    public IDbContextTransaction Transaction { get; set; }

    public UnitOfWorkEF(DataContext context)
    {
        _context = context;
    }


    public void Begin() 
        => Transaction = _context.Database.BeginTransaction();

    public void Commit()
        => Transaction.Commit();

    public void CallBack()
        => Transaction.Rollback();

}