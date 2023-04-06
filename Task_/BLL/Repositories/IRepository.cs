using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<IReadOnlyList<TEntity>> ListAllAsync(CancellationToken cancellationToken);
        Task<Nullable<int>> DeleteAsyncreturn(TEntity entity, CancellationToken cancellationToken);
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
        Task<TEntity> UpdateAsync_Return(TEntity entity, CancellationToken cancellationToken);
        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);
        Task<TEntity> GetByIdAsync(CancellationToken cancellationToken,Expression<Func<TEntity, bool>>? value = null);
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null);
        IEnumerable<TEntity> ExecStoreProcedure(string sql, params object[] parameters);
        IEnumerable<TEntity> ExecQuery(string query);
        public Task<TEntity> GetByIdAsync_AsNotracking(CancellationToken cancellationToken, Expression<Func<TEntity, bool>>? value = null);
        Task<ICollection<TEntity>> AddAsync(ICollection< TEntity> entity, CancellationToken cancellationToken);
        Task UpdateAsync(ICollection<TEntity> entity, CancellationToken cancellationToken);
    }
}
