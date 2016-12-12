using System.Data.Entity.ModelConfiguration;
using Api.Architecture.Infra.Identity.Model;

namespace Api.Architecture.Infra.Identity.Mapping
{
    public class ApplicationUserConfig : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfig()
        {
            HasKey(u => u.Id);

            Property(u => u.Id)
                .IsRequired()
                .HasMaxLength(128);

            Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(256);

            Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(256);

            ToTable("AspNetUsers");
        }
    }
}
