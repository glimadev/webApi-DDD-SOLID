using Api.Architecture.Infra.Data.Context.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Api.Architecture.Infra.Repository.Base
{
    public interface IRepository<TEntity> where TEntity : class, IObjectState
    {
        TEntity UnDeleteLogic(TEntity entity);
        TEntity DeleteLogic(TEntity entity);

        TEntity FindById(params object[] keyValues);
        TEntity Find(Expression<Func<TEntity, bool>> query);
        IEnumerable<TEntity> FindMany(Expression<Func<TEntity, bool>> query);

        TEntity Insert(TEntity entity);
        //IEnumerable<TEntity> InsertRange(IEnumerable<TEntity> entities);
        //TEntity InsertOrUpdateGraph(TEntity entity);
        //TEntity InsertGraph(TEntity entity);
        //IEnumerable<TEntity> InsertGraphRange(IEnumerable<TEntity> entities);
        //IEnumerable<TEntity> UpdateGraphRange(IEnumerable<TEntity> entities);

        TEntity Update(TEntity entity);

        void Delete(object id);
        void Delete(TEntity entity);

        TEntity Detach(TEntity entity);
    }
}
