using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using Api.Architecture.Application;
using Api.Architecture.Application.Interface;
using Api.Architecture.Domain.Entities.Repository;
using Api.Architecture.Domain.Services;
using Api.Architecture.Domain.Services.Interface;
using Api.Architecture.Infra.Data.Models;
using Api.Architecture.Infra.Identity.Configuration;
using Api.Architecture.Infra.Identity.Context;
using Api.Architecture.Infra.Identity.Model;
using Api.Architecture.Repository.UserRepository;
using Api.Framework.Repository.DataContext;
using Api.Framework.Repository.Entity;
using Api.Framework.Repository.Repositories;
using Api.Framework.Repository.UnitOfWork;

namespace Api.Architecture.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            #region [ Context ]

            var registration = Lifestyle.Scoped.CreateRegistration<SempreAquiContext>(container);
            container.AddRegistration(typeof(IDataContextAsync), registration);

            container.RegisterPerWebRequest<IUnitOfWorkAsync, UnitOfWork>();


            #endregion

            #region [ Identity ]

            container.Register<ApplicationDbContext>(new WebRequestLifestyle());
            container.RegisterPerWebRequest<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(new ApplicationDbContext()));
            container.RegisterPerWebRequest<IRoleStore<ApplicationRole, string>>(() => new RoleStore<ApplicationRole>(new ApplicationDbContext()));
            container.RegisterPerWebRequest<ApplicationRoleManager>();
            container.RegisterPerWebRequest<ApplicationUserManager>();
            container.RegisterPerWebRequest<ApplicationSignInManager>();

            #endregion

            #region [ Services and Repositories ]

            container.Register(typeof(IRepositoryAsync<>), typeof(Repository<>), new WebRequestLifestyle());
            container.Register(typeof(IUserRepository), typeof(UserRepository), new WebRequestLifestyle());
            container.Register(typeof(IUserService), typeof(UserService), new WebRequestLifestyle());
            container.Register(typeof(IClientApp), typeof(ClientApp), new WebRequestLifestyle());

            #endregion
        }
    }
}
