using Api.Architecture.Infra.Data.Context.Base;
using Api.Architecture.Infra.Repository.Base;
using System;
using System.Data;

namespace Api.Architecture.Infra.Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
        void Dispose(bool disposing);
        IRepository<TEntity> Repository<TEntity>() where TEntity : class, IObjectState;
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified);
        bool Commit();
        void Rollback();
    }
}
