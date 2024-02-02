using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Trovantenato.Domain.Common;
using Trovantenato.Domain.Interfaces.Repository;
using Trovantenato.Infrastructure.Context;

namespace Trovantenato.Infrastructure.Common
{
    public partial class BaseRepository<T> : IBaseRepository<T> where T : AuditableEntity
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dataset;
        public BaseRepository(ApplicationDbContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
            _dataset = context.Set<T>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id of the item</param>
        /// <returns>false for not found item and true if completed the delete</returns>
        public async Task<bool> DeleteAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            var result = await _dataset.SingleOrDefaultAsync(predicate, cancellationToken);
            if (result == null)
                return false;

            _dataset.Remove(result);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
        public async Task<bool> DeleteRangeAsync(IEnumerable<T> itemCollection, CancellationToken cancellationToken = default)
        {
            _dataset.RemoveRange(itemCollection);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> ExistAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default) =>
            await _dataset.AnyAsync(predicate, cancellationToken);

        public async Task<T> InsertAsync(T item, CancellationToken cancellationToken)
        {
            await _dataset.AddAsync(item, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return item;
        }

        public async Task<IEnumerable<T>> InsertRangeAsync(IEnumerable<T> item, CancellationToken cancellationToken = default)
        {
            await _dataset.AddRangeAsync(item, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return item;
        }

        public async Task<T> SelectAsync(Expression<Func<T, bool>> predicate, List<string> include = null, bool Notracking = false, CancellationToken cancellationToken = default)
        {
            var q = _dataset.AsQueryable();

            if (include != null)
            {
                foreach (string inc in include)
                    q = q.Include(inc);
            }

            if (Notracking)
                q.AsNoTracking();

            return await q.SingleOrDefaultAsync(predicate, cancellationToken);
        }

        public async Task<IEnumerable<T>> SelectAllAsync(Expression<Func<T, bool>> predicate = null, List<string> include = null, bool Notracking = false, CancellationToken cancellationToken = default)
        {
            var q = _dataset.AsQueryable();
            if (include != null)
            {
                foreach (string inc in include)
                    q = q.Include(inc);
            }

            if (Notracking)
                q.AsNoTracking();

            return predicate == null
                ? await q.ToListAsync(cancellationToken)
                : await q.Where(predicate)
                               .ToListAsync();
        }

        public async Task<T> UpdateAsync(T item, CancellationToken cancellationToken = default)
        {
            _context.Update(item);
            await _context.SaveChangesAsync(cancellationToken);
            return item;
        }

        #region DisposePattern
        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                    _context.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
