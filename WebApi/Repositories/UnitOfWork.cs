using WebApi.DBOperations;
using WebApi.Models;
using WebApi.Repositories.Interfaces;

namespace WebApi.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        #region Properties
        private bool _disposed = false;
        private TheathersDbContext _context { get; }
        #endregion

        #region Constructor
        public UnitOfWork(TheathersDbContext context)
        {
            _context = context;
        }
        #endregion

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new Repository<T>(_context);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing && _context != null)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
