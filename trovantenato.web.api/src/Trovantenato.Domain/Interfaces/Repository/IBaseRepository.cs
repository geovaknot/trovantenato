using System.Linq.Expressions;
using Trovantenato.Domain.Common;

namespace Trovantenato.Domain.Interfaces.Repository
{
    public interface IBaseRepository<T> : IDisposable where T : AuditableEntity
    {
        Task<T> InsertAsync(T item, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> InsertRangeAsync(IEnumerable<T> itemCollection, CancellationToken cancellationToken = default);
        Task<T> UpdateAsync(T item, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
        Task<bool> DeleteRangeAsync(IEnumerable<T> itemCollection, CancellationToken cancellationToken = default);
        Task<T> SelectAsync(Expression<Func<T, bool>> predicate, List<string> include = null, bool Notracking = false, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> SelectAllAsync(Expression<Func<T, bool>> predicate = null, List<string> include = null, bool Notracking = false, CancellationToken cancellationToken = default);
        Task<bool> ExistAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
    }
}
