using Api.Architecture.Infra.Data.Context.Base;
using Api.Architecture.Infra.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Architecture.Infra.Repository.UnitOfWork
{
    public interface IUnitOfWorkAsync : IUnitOfWork
    {
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        IRepositoryAsync<TEntity> RepositoryAsync<TEntity>() where TEntity : class, IObjectState;
    }
}
