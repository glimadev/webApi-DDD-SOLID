using Api.Architecture.Infra.Data.Context.Base;
using Api.Architecture.Infra.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Api.Architecture.Domain.Base
{
    public abstract class Service<TEntity> : IService<TEntity> where TEntity : class, IObjectState
    {
        #region [ Private Fields ]
        private readonly IRepositoryAsync<TEntity> _repository;
        #endregion Private Fields

        #region [ Constructor ]

        protected Service(IRepositoryAsync<TEntity> repository)
        {
            _repository = repository;
        }

        #endregion Constructor

        #region [ Find ]

        public virtual TEntity FindById(object keyValue)
        {
            return _repository.FindById(keyValue);
        }

        public TEntity Find(Expression<Func<TEntity, bool>> query)
        {
            return _repository.Find(query);
        }

        public IEnumerable<TEntity> FindMany(Expression<Func<TEntity, bool>> query)
        {
            return _repository.FindMany(query);
        }

        #endregion

        public virtual void Insert(TEntity entity) { _repository.Insert(entity); }

        public virtual void Update(TEntity entity) { _repository.Update(entity); }

        public virtual void Delete(object id) { _repository.Delete(id); }

        public virtual void Delete(TEntity entity) { _repository.Delete(entity); }

        public virtual async Task<TEntity> FindByIdAsync(object keyValue) { return await _repository.FindByIdAsync(keyValue); }

        public Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> query)
        {
            return _repository.FindAsync(query);
        }

        public Task<List<TEntity>> FindManyAsync(Expression<Func<TEntity, bool>> query)
        {
            return _repository.FindManyAsync(query);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}