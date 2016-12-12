using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using Api.Architecture.Infra.Identity.Model;

namespace Api.Architecture.Infra.Identity.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IDisposable
    {
        public ApplicationDbContext()
            : base("cnsDataAccess", throwIfV1Schema: false)
        {
           
        }

        new public DbSet<ApplicationRole> Roles {get;set;}

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}