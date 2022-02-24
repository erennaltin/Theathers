using WebApi.Models;
using System.Linq.Expressions;

namespace WebApi.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(int id);
        T GetByRowId(Guid rowId);
        T GetFirst(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll();
        IQueryable<T> GetAvailable();
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAvailable(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAllQueryable();

        T Insert(T entity);
        void InsertRange(IEnumerable<T> entities);

        T Update(T entity);

        T SoftDeleteById(int id);
        T SoftDeleteByRowId(Guid rowId);
        T SoftDelete(T entity);
        bool DeletePermanently(T entity);
        bool DeleteRangePermanently(IEnumerable<T> entities);
        int SaveChanges();
    }
}
