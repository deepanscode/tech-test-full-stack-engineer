namespace TradieApp.Application.UnitOfWork;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}