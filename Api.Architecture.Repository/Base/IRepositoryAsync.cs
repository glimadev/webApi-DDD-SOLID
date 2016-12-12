using Api.Architecture.Infra.Data.Context.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Architecture.Infra.Repository.Base
{
    public interface IRepositoryAsync<TEntity> : IRepository<TEntity> where TEntity : class, IObjectState
    {
        Task<TEntity> FindByIdAsync(params object[] keyValues);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> query);

        Task<List<TEntity>> FindManyAsync(Expression<Func<TEntity, bool>> query);
        Task<List<TEntity>> GetAllAsync();
        Task<List<TEntity>> GetAllActivesAsync();
    }
}
