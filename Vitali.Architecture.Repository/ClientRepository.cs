using Api.Architecture.Infra.Repository.Base;
using Api.Architecture.Infra.Repository.Interfaces;
using Api.Architecture.Infra.Data.Context.Base;
using Api.Architecture.Infra.Repository.UnitOfWork;
using Api.Architecture.Infra.Data.Models;

namespace Api.Architecture.Repository.UserRepository
{
    public class ClienRepository : Repository<Client>, IClientRepository
    {
        #region [ DI ]

        readonly IRepositoryAsync<Client> _repository;
        readonly IDataContext _context;
        readonly IUnitOfWorkAsync _unitOfWork;

        public ClienRepository(IRepositoryAsync<Client> repository,
            IDataContext context,
            IUnitOfWorkAsync unitOfWork)
            : base(context, unitOfWork)
        {
            this._context = context;
            this._unitOfWork = unitOfWork;
            this._repository = repository;
        }

        #endregion
    }
}
