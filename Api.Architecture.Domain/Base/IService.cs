using Api.Architecture.Infra.Data.Context.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Api.Architecture.Domain.Base
{
    public interface IService<TEntity> where TEntity : IObjectState
    {
        #region [ Sync ]

        TEntity FindById(object keyValue);
        TEntity Find(Expression<Func<TEntity, bool>> query);
        IEnumerable<TEntity> FindMany(Expression<Func<TEntity, bool>> query);

        void Insert(TEntity entity);
        /*void InsertRange(IEnumerable<TEntity> entities);
        void InsertGraphRange(IEnumerable<TEntity> entities);
        void InsertOrUpdateGraph(TEntity entity);*/

        void Update(TEntity entity);
        void Delete(object id);
        void Delete(TEntity entity);

        #endregion

        #region [ Async ]

        Task<TEntity> FindByIdAsync(object keyValue);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> query);
        Task<List<TEntity>> FindManyAsync(Expression<Func<TEntity, bool>> query);
        Task<List<TEntity>> GetAllAsync();

        #endregion
    }
}
