using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DbContext _context;
        private DbSet<TEntity> dbSet;

        public Repository(DbContext context)
        {
            this._context = context;
            this.dbSet = context.Set<TEntity>();
        }
        public virtual IQueryable<TEntity> Query(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return query.AsNoTracking(); ;
        }
        public virtual async Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Set<TEntity>().FindAsync(id, cancellationToken);
        }
        public virtual IEnumerable<TEntity> ExecStoreProcedure(string sql, params object[] parameters)
        {
            var result = _context.Set<TEntity>().FromSqlRaw(sql, parameters);
            // _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            return result;
        }
        public virtual IEnumerable<TEntity> ExecQuery(string query)
        {
            var result = _context.Set<TEntity>().FromSqlRaw(query);
            return result;
        }

        public async Task<IReadOnlyList<TEntity>> ListAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Set<TEntity>().ToListAsync(cancellationToken);
        }

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            await _context.Set<TEntity>().AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }
        public async Task<ICollection<TEntity>> AddAsync(ICollection<TEntity> entity, CancellationToken cancellationToken)
        {
            foreach(var item  in entity)
            {
                await _context.Set<TEntity>().AddAsync(item, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
            }
            

            return entity;
        }
        public async Task UpdateAsync(ICollection<TEntity> entity, CancellationToken cancellationToken)
        {
            foreach (var item in entity)
            {
                _context.Entry(item).State = EntityState.Modified;
            }
            await _context.SaveChangesAsync(cancellationToken);

        }

        public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);

        }
        public async Task<TEntity> UpdateAsync_Return(TEntity entity, CancellationToken cancellationToken)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
            return entity;

        }
        public async Task<Nullable<int>> DeleteAsyncreturn(TEntity entity, CancellationToken cancellationToken)
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return default(int?);
        }
        public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken)
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task<TEntity> GetByIdAsync(CancellationToken cancellationToken,Expression<Func<TEntity, bool>>? value = null)
        {

            return await _context.Set<TEntity>().FirstOrDefaultAsync(value, cancellationToken);
        }
        public async Task<TEntity> GetByIdAsync_AsNotracking(CancellationToken cancellationToken, Expression<Func<TEntity, bool>>? value = null)
        {

            return await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(value, cancellationToken);
        }
    }
}
