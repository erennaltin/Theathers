using WebApi.Models;


namespace WebApi.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : BaseEntity;
    }
}
