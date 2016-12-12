using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using Api.Architecture.Infra.Data.Context.Base;
using LinqKit;
using Api.Architecture.Infra.Repository.UnitOfWork;
using System.Threading.Tasks;

namespace Api.Architecture.Infra.Repository.Base
{
    public class Repository<TEntity> : IRepositoryAsync<TEntity> where TEntity : class, IObjectState
    {
        #region [ Private Fields ]

        private readonly IDataContext _context;
        private readonly DbSet<TEntity> _dbSet;
        private readonly IUnitOfWorkAsync _unitOfWork;

        #endregion Private Fields

        public Repository(IDataContext context, IUnitOfWorkAsync unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;

            // Temporarily for FakeDbContext, Unit Test and Fakes
            var dbContext = context as DbContext;

            _dbSet = dbContext.Set<TEntity>();
        }

        public virtual TEntity FindById(params object[] keyValues)
        {
            return _dbSet.Find(keyValues);
        }

        public virtual TEntity Find(Expression<Func<TEntity, bool>> query)
        {
            return _dbSet.AsExpandable().Where(query).FirstOrDefault();
        }

        public virtual IEnumerable<TEntity> FindMany(Expression<Func<TEntity, bool>> query)
        {
            return _dbSet.AsExpandable().Where(query).AsEnumerable();
        }

        public virtual TEntity Insert(TEntity entity)
        {
            entity.ObjectState = ObjectState.Added;
            entity.CreatedDate = DateTime.Now;
            _dbSet.Attach(entity);
            _context.SyncObjectState(entity);
            _context.SaveChanges();

            return entity;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual TEntity Detach(TEntity entity)
        {
            entity.ObjectState = ObjectState.Detached;
            _context.SyncObjectState(entity);
            _context.SaveChanges();

            return entity;
        }

        public virtual TEntity Update(TEntity entity)
        {
            entity.ObjectState = ObjectState.Modified;
            entity.EditedDate = DateTime.Now;
            _dbSet.Attach(entity);
            _context.SyncObjectState(entity);
            _context.SaveChanges();
            return entity;
        }

        public virtual TEntity UnDeleteLogic(TEntity entity)
        {
            entity.ObjectState = ObjectState.Modified;
            entity.Deleted = false;
            _dbSet.Attach(entity);
            _context.SyncObjectState(entity);
            _context.SaveChanges();
            return entity;
        }

        public virtual TEntity DeleteLogic(TEntity entity)
        {
            entity.ObjectState = ObjectState.Modified;
            entity.DeletedDate = DateTime.Now;
            entity.Deleted = true;
            _dbSet.Attach(entity);
            _context.SyncObjectState(entity);
            _context.SaveChanges();
            return entity;
        }

        public virtual void Delete(object id)
        {
            var entity = _dbSet.Find(id);
            Delete(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            entity.ObjectState = ObjectState.Deleted;
            _dbSet.Attach(entity);
            _context.SyncObjectState(entity);
            _context.SaveChanges();
        }

        #region [ Select ]

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<List<TEntity>> GetAllActivesAsync()
        {
            return await _dbSet.Where(x => x.Deleted == false && x.Active == true).ToListAsync();
        }

        #endregion

        public virtual async Task<TEntity> FindByIdAsync(params object[] keyValues)
        {
            return await _dbSet.FindAsync(keyValues);
        }

        public virtual async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> query)
        {
            return await _dbSet.Where(query).FirstOrDefaultAsync();
        }

        public virtual async Task<List<TEntity>> FindManyAsync(Expression<Func<TEntity, bool>> query)
        {
            return await _dbSet.AsExpandable().Where(query).ToListAsync();
        }
    }
}
