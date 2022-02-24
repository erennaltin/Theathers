using WebApi.DBOperations;
using WebApi.Models;
using WebApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace WebApi.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        #region Properties
        private readonly TheathersDbContext _context;
        public DbSet<T> Table { get; set; }
        #endregion

        #region Constructor
        public Repository(TheathersDbContext context)
        {
            _context = context;
            Table = _context.Set<T>();
        }
        #endregion

        public IEnumerable<T> GetAll()
        {
            return Table.ToList();
        }

        public IQueryable<T> GetAllQueryable()
        {
            return Table.AsQueryable();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return Table.Where(predicate);
        }

        public IQueryable<T> GetAvailable()
        {
            return Table.Where(x => !x.IsDeleted);
        }

        public IQueryable<T> GetAvailable(Expression<Func<T, bool>> predicate)
        {
            return Table.Where(x => !x.IsDeleted).Where(predicate);
        }

        public T GetById(int id)
        {
            return Table.FirstOrDefault(x => x.Id == id);
        }

        public T GetByRowId(Guid rowId)
        {
            return Table.FirstOrDefault(x => x.RowId == rowId);
        }

        public T GetFirst(Expression<Func<T, bool>> predicate)
        {
            return Table.FirstOrDefault(predicate);
        }

        public T Insert(T entity)
        {
            entity.DateCreatedUTC = DateTime.UtcNow;

            var item = Table.Add(entity);
            int result = SaveChanges();

            if (result > 0)
            {
                return item.Entity;
            }

            return null;
        }

        public void InsertRange(IEnumerable<T> entities)
        {
            IEnumerable<T> items = entities.Select(e =>
            {
                e.DateCreatedUTC = DateTime.UtcNow;
                return e;
            }).ToList();

            Table.AddRange(items);

            SaveChanges();
        }

        public bool DeletePermanently(T entity)
        {
            Table.Remove(entity);
            return SaveChanges() > 0;
        }

        public bool DeleteRangePermanently(IEnumerable<T> entities)
        {
            Table.RemoveRange(entities);
            return SaveChanges() > 0;
        }

        public T SoftDelete(T entity)
        {
            entity.IsDeleted = true;
            entity.DateDeletedUTC = DateTime.UtcNow;

            return Update(entity);
        }

        public T SoftDeleteById(int id)
        {
            T entityToDelete = GetById(id);

            if (entityToDelete != null)
            {
                return SoftDelete(entityToDelete);
            }

            return null;
        }

        public T SoftDeleteByRowId(Guid rowId)
        {
            T entityToDelete = GetByRowId(rowId);

            if (entityToDelete != null)
            {
                return SoftDelete(entityToDelete);
            }

            return null;
        }

        public T Update(T entity)
        {
            entity.DateUpdatedUTC = DateTime.UtcNow;

            var item = Table.Update(entity);
            int result = SaveChanges();

            if (result > 0)
            {
                return item.Entity;
            }

            return null;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
