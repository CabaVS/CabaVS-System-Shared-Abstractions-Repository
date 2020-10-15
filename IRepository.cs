using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CabaVS.Shared.Abstractions.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate = null, string[] includes = null,
            int skip = 0, int take = 0);

        Task<List<TResult>> GetListAsync<TResult>(Expression<Func<TEntity, TResult>> selectExpression,
            Expression<Func<TEntity, bool>> predicate = null, string[] includes = null, int skip = 0, int take = 0);

        Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate = null, string[] includes = null);

        Task<TResult> GetFirstAsync<TResult>(Expression<Func<TEntity, TResult>> selectExpression,
            Expression<Func<TEntity, bool>> predicate = null, string[] includes = null);

        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);

        Task DeleteAsync(Expression<Func<TEntity, bool>> predicate);

        Task<bool> IsAnyAsync(Expression<Func<TEntity, bool>> predicate = null);

        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null);
    }
}