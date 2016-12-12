using System.Data.Entity;
using Api.Architecture.Infra.Data.Models.Mapping;
using Api.Architecture.Infra.Data.Context;

namespace Api.Architecture.Infra.Data.Models
{
    public partial class ApiContext : DataContext
    {
        static ApiContext()
        {
            Database.SetInitializer<ApiContext>(null);
        }

        public ApiContext()
            : base("Name=cnsDataAccess")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClientMap());
        }
    }
}
