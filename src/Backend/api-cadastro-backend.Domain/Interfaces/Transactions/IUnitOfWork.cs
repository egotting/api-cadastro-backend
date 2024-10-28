namespace api_cadastro_backend.Domain.Interfaces.Transactions;

public interface IUnitOfWork
{
    void Begin();
    void Commit();
    void CallBack();
}